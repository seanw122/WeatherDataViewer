using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherDataViewer.Common;

namespace WeatherUnderground
{
    [Export(typeof(IWeatherDataGetter))]
    internal class WeatherUnderground : IWeatherDataGetter
    {
        public string Name => "Weather Underground";
        private readonly string _dataStoragePath;
        private readonly DataTransformation _dataTransformation;

        public IEnumerable<string> Offerings { get; }
        private readonly Dictionary<string, string> _wuLinks;

        public WeatherUnderground()
        {
            _dataTransformation = new DataTransformation(Name);
            Offerings = new List<string>() { "Forecast 10 Day", "Hourly 10 Day" };
            _wuLinks = new Dictionary<string, string>() { { "Forecast 10 Day", "forecast10day" }, { "Hourly 10 Day", "hourly10day" } };
            _dataStoragePath = Path.Combine(Environment.CurrentDirectory, "Plugins");
        }

        public IWeatherData GetWeatherData(string requestType)
        {
            var key = ConfigurationManager.AppSettings["WeatherUnderGroundKey"];
            var requestLink = _wuLinks[requestType];

            var commandString = "http://api.wunderground.com/api/"
                                + key + "/" + requestLink + "/q/AR/Fort_Smith.json";

            IWeatherData returnData = null;

            var t = Task.Run(() =>
            {
                try
                {
                    var owData = new WebClient().DownloadString(commandString);
                    var wd = Deserialize(requestType, owData);
                    returnData = _dataTransformation.TransformData(wd);
                    StoreData(requestLink, owData);
                }
                catch (Exception ex)
                {
                    returnData = RetrievePreviousData(requestType).Result;
                }

            });

            if (!t.Wait(5000))
            {
                //retrive last known data
                returnData = RetrievePreviousData(requestType).Result;
            }

            return returnData;
        }

        private dynamic Deserialize(string weatherType, string weatherData)
        {
            switch (weatherType)
            {
                case "Forecast 10 Day":
                    return JsonConvert.DeserializeObject<ForecastData>(weatherData);
                case "Hourly 10 Day":
                    return JsonConvert.DeserializeObject<Hourly10DayData>(weatherData);
            }
            return null;
        }

        private async Task<IWeatherData> RetrievePreviousData(string requestType)
        {
            try
            {
                IWeatherData returnData = null;
                var storagePath = Path.Combine(_dataStoragePath, requestType + "_wu.txt");
                var t = new Task(() =>
                {
                    var previousData = File.ReadAllText(storagePath);
                    returnData = _dataTransformation.TransformData(Deserialize(requestType, previousData));
                });

                await t;
                return returnData;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private async void StoreData(string requestType, string value)
        {
            var storagePath = Path.Combine(_dataStoragePath, requestType + "_wu.txt");

            if (File.Exists(storagePath))
                File.Delete(storagePath);

            await Task.Run(() => File.WriteAllText(storagePath, value));
        }

        
    }
}
