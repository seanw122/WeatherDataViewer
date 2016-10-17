using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WeatherDataViewer
{
    internal class WeatherDataFactory
    {
        private readonly List<Type> _weatherDataClasses;
 
        public WeatherDataFactory()
        {
            _weatherDataClasses = LoadWeatherDataClasses();
        }

        public List<Type> LoadedWeatherDataClasses => _weatherDataClasses;

        private List<Type> LoadWeatherDataClasses()
        {
            var type = typeof(IWeatherDataGetter);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            var typeList = types.ToList();

            foreach (var loadPlugInAssembly in LoadPlugInAssemblies())
            {
                var pluginTypes = loadPlugInAssembly.GetTypes()
                    .Where(p => type.IsAssignableFrom(p) && p.IsClass);
                foreach (var pluginType in pluginTypes)
                {
                    typeList.Add(pluginType);
                }
            }
            return typeList;
        }

        public IWeatherDataGetter GetWeatherDataClass(string name)
        {
            if (_weatherDataClasses == null)
                return null;

            return Activator.CreateInstance(_weatherDataClasses.Find(x => x.Name == name)) as IWeatherDataGetter;
        }

        private List<Assembly> LoadPlugInAssemblies()
        {
            var dInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            FileInfo[] files = dInfo.GetFiles("*.dll");
            var plugInAssemblyList = new List<Assembly>();

            if (files.Any())
            {
                foreach (FileInfo file in files)
                {
                    plugInAssemblyList.Add(Assembly.LoadFile(file.FullName));
                }
            }

            return plugInAssemblyList;

        }
    }
}
