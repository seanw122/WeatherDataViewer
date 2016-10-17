using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using WeatherDataViewer;

namespace OpenWeatherMap
{
    internal class OpenWeatherMap : IWeatherDataGetter
    {
        public string GetWeatherData()
        {
            var owdKey = ConfigurationManager.AppSettings["OpenWeatherMapKey"];
            string commandString = "http://api.openweathermap.org/data/2.5/forecast?q=Tulsa,us&mode=xml&appid=" + owdKey;

            var owdata = new WebClient().DownloadString(commandString);

            var owSerializer = new XmlSerializer(typeof(weatherdata));
            weatherdata wd;
            using (var sr = new StringReader(owdata))
                wd = (weatherdata)owSerializer.Deserialize(sr);

            var sb = new StringBuilder();
            sb.AppendLine("From OpenWeatherMap----------------------------");
            sb.AppendFormat("{0,20}{1,45}\r\n", "Date", "Temp");

            foreach (var f in wd.forecast)
            {
                sb.AppendLine(String.Format("{0,-35}{1,-30}", f.from.ToString(), ConvertToFahrenheit(f.temperature.value).ToString()));
            }

            return sb.ToString();
        }
        
        private decimal ConvertToFahrenheit(decimal value)
        {
            return value * (9 / 5) + 32;
        }
    }
}