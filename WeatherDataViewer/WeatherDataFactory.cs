using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using WeatherDataViewer.Common;

namespace WeatherDataViewer
{
    internal class WeatherDataFactory
    {
        public WeatherDataFactory()
        {
            var aggCat = new AggregateCatalog();
            var dirCat = new DirectoryCatalog(Path.Combine(Environment.CurrentDirectory, "Plugins"));
            var asmCat = new AssemblyCatalog(Assembly.GetExecutingAssembly());

            aggCat.Catalogs.Add(dirCat);
            aggCat.Catalogs.Add(asmCat);

            var compContainer = new CompositionContainer(aggCat);
            compContainer.ComposeParts(this);

            BuildGetters();
        }

        private void BuildGetters()
        {
            WeatherGetters = new Dictionary<string, IWeatherDataGetter>();
            foreach (var weatherDataGetter in _weatherGetters)
            {
                WeatherGetters.Add(weatherDataGetter.Name, weatherDataGetter);
            }
        }

        [ImportMany(typeof(IWeatherDataGetter))]
        private IEnumerable<IWeatherDataGetter> _weatherGetters;

        public Dictionary<string, IWeatherDataGetter> WeatherGetters { get; set; }
    }
}
