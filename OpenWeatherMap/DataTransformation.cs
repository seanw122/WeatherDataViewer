using System;
using System.Threading.Tasks;
using WeatherDataViewer.Common;

namespace OpenWeatherMap
{
    internal class DataTransformation
    {
        private readonly string _name;

        public DataTransformation(string name)
        {
            _name = name;
        }

        public IWeatherData TransformData(Forecast16DayData wx)
        {
            var returnData = new WeatherData { DataSourceName = _name };

            Parallel.ForEach(wx.list, (forecast) =>
            {
                var newDate = new DateTime(1970, 1, 1).AddSeconds(forecast.dt);
                var wd = new WeatherDataDetails
                {
                    Conditions = forecast.weather[0].description,
                    Date = newDate,
                    Temp = (short)forecast.temp.day,
                    High = (short)forecast.temp.max,
                    Low = (short)forecast.temp.min
                };
                returnData.Records.Add(wd);
            });

            return returnData;
        }

        public IWeatherData TransformData(ForecastData wx)
        {
            var returnData = new WeatherData { DataSourceName = _name };

            Parallel.ForEach(wx.list, (forecast) =>
            {
                var wd = new WeatherDataDetails
                {
                    Conditions = forecast.weather[0].description,
                    Date = DateTime.Parse(forecast.dt_txt),
                    High = (short)forecast.main.temp_max,
                    Low = (short)forecast.main.temp_min
                };
                returnData.Records.Add(wd);
            });

            return returnData;
        }
    }
}
