using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataViewer.Common;

namespace WeatherUnderground
{
    internal class DataTransformation
    {
        private string _name;

        public DataTransformation(string name)
        {
            _name = name;
        }

        public IWeatherData TransformData(Hourly10DayData wx)
        {
            var returnData = new WeatherData { DataSourceName = _name };

            Parallel.ForEach(wx.hourly_forecast, (forecast) =>
            {
                var newDate = new DateTime(forecast.FCTTIME.year, forecast.FCTTIME.mon, forecast.FCTTIME.mday,
                    forecast.FCTTIME.hour, forecast.FCTTIME.min, forecast.FCTTIME.sec);
                var wd = new WeatherDataDetails
                {
                    Conditions = forecast.condition,
                    Date = newDate,
                    Temp = forecast.temp.english
                };
                returnData.Records.Add(wd);
            });

            return returnData;
        }

        public IWeatherData TransformData(ForecastData wx)
        {
            var returnData = new WeatherData { DataSourceName = _name };

            Parallel.ForEach(wx.forecast.simpleforecast.forecastday, (forecast) =>
            {
                var wd = new WeatherDataDetails
                {
                    Conditions = forecast.conditions,
                    Date = forecast.date.ToDateTime(),
                    High = short.Parse(forecast.high.fahrenheit),
                    Low = short.Parse(forecast.low.fahrenheit)
                };
                returnData.Records.Add(wd);
            });

            return returnData;
        }
    }
}
