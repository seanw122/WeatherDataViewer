
namespace OpenWeatherMap
{
    internal class ForecastData
    {
        public City city { get; set; }
        public string cod { get; set; }
        public float message { get; set; }
        public int cnt { get; set; }
        public List[] list { get; set; }
    }

    internal class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
        public Sys sys { get; set; }
    }

    internal class Coord
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }

    internal class Sys
    {
        public int population { get; set; }
    }

    internal class List
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public Weather[] weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys1 sys { get; set; }
        public string dt_txt { get; set; }
        public Rain rain { get; set; }
    }

    internal class Main
    {
        public float temp { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public float pressure { get; set; }
        public float sea_level { get; set; }
        public float grnd_level { get; set; }
        public int humidity { get; set; }
        public float temp_kf { get; set; }
    }

    internal class Clouds
    {
        public int all { get; set; }
    }

    internal class Wind
    {
        public float speed { get; set; }
        public float deg { get; set; }
    }

    internal class Sys1
    {
        public string pod { get; set; }
    }

    internal class Rain
    {
        public float _3h { get; set; }
    }

    internal class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

}
