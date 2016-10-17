using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherDataViewer
{
    internal class WeatherDataFactory
    {
        private readonly List<Type> _weatherDataClasses;
 
        public WeatherDataFactory()
        {
            _weatherDataClasses = GetWeatherDataClasses();
        }
        public List<Type> GetWeatherDataClasses()
        {
            var type = typeof(IWeatherDataGetter);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            return types.ToList();
        }

        public IWeatherDataGetter GetWeatherDataClass(string name)
        {
            if (_weatherDataClasses == null)
                return null;

            return Activator.CreateInstance(_weatherDataClasses.Find(x => x.Name == name)) as IWeatherDataGetter;
        }
    }
}
