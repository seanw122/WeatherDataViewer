using Newtonsoft.Json;

namespace WeatherDataViewer.Common
{
    public class Deserializer
    {
        public static T Deserialize<T>(string weatherData)
        {
            var result = JsonConvert.DeserializeObject<T>(weatherData);
            return result;
        }
    }
}
