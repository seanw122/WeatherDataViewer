using System;
using System.Collections.Generic;

namespace WeatherDataViewer.Common
{
    public interface IWeatherDataGetter
    {
        string Name { get; }
        IEnumerable<string> Offerings { get; }
        IWeatherData GetWeatherData(string requestType);
    }

    public interface IWeatherData
    {
        string DataSourceName { get; set; }
        List<IWeatherDataDetails> Records { get; set; }
    }

    public interface IWeatherDataDetails
    {
        DateTime Date { get; set; }
        string Conditions { get; set; }
        short? Temp { get; set; }
        short High { get; set; }
        short Low { get; set; }
    }

    public class WeatherData : IWeatherData
    {
        public string DataSourceName { get; set; }
        public List<IWeatherDataDetails> Records { get; set; }

        public WeatherData()
        {
            Records = new List<IWeatherDataDetails>();
        }
    }

    public class WeatherDataDetails : IWeatherDataDetails
    {
        public DateTime Date { get; set; }
        public string Conditions { get; set; }
        public short? Temp { get; set; }
        public short High { get; set; }
        public short Low { get; set; }
    }
}