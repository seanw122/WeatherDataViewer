using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using WeatherDataViewer.Common;

namespace OpenWeatherMap
{
    [Export(typeof(IWeatherDataGetter))]
    public class OpenWeatherMap : IWeatherDataGetter
    {
        public string Name => "Open Weather Map";
        private readonly DataTransformation _dataTransformation;

        public IEnumerable<string> Offerings { get; }

        private readonly Dictionary<string, string> _oWMLinks;

        public OpenWeatherMap()
        {
            _dataTransformation = new DataTransformation(Name);
            _oWMLinks = new Dictionary<string, string>()
            {
                { "Forecast", "forecast" },
                { "Forecast 16 Day", "forecast/daily" }
            };
            Offerings = _oWMLinks.Keys;
        }

        public IWeatherData GetWeatherData(string requestType)
        {
            var owdKey = ConfigurationManager.AppSettings["OpenWeatherMapKey"];
            var requestLink = _oWMLinks.Single(x => x.Key == requestType).Value;

            var commandString = "http://api.openweathermap.org/data/2.5/" + requestLink + "?q=FortSmith,us&mode=json&units=imperial&appid=" + owdKey;

            var owData = new WebClient().DownloadString(commandString);
            var wd = Deserialize(requestType, owData);
            IWeatherData returnData = _dataTransformation.TransformData(wd);

            return returnData;
        }

        private dynamic Deserialize(string weatherType, string weatherData)
        {
            switch (weatherType)
            {
                case "Forecast":
                    return JsonConvert.DeserializeObject<ForecastData>(weatherData);
                case "Forecast 16 Day":
                    return JsonConvert.DeserializeObject<Forecast16DayData>(weatherData);
            }
            return null;
        }

        private decimal ConvertToFahrenheit(decimal value)
        {
            return value * (9 / 5) + 32;
        }
    }
}