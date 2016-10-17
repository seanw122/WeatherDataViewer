namespace WeatherUnderground
{

    public class Hourly10DayData
    {
        public Hourly10DayResponse response { get; set; }
        public Hourly_Forecast[] hourly_forecast { get; set; }
    }

    public class Hourly10DayResponse
    {
        public string version { get; set; }
        public string termsofService { get; set; }
        public Hourly10DayFeatures features { get; set; }
    }

    public class Hourly10DayFeatures
    {
        public int hourly10day { get; set; }
    }

    public class Hourly_Forecast
    {
        public FCTTIME FCTTIME { get; set; }
        public Temp temp { get; set; }
        public Dewpoint dewpoint { get; set; }
        public string condition { get; set; }
        public string icon { get; set; }
        public string icon_url { get; set; }
        public string fctcode { get; set; }
        public string sky { get; set; }
        public Wspd wspd { get; set; }
        public Wdir wdir { get; set; }
        public string wx { get; set; }
        public string uvi { get; set; }
        public string humidity { get; set; }
        public Windchill windchill { get; set; }
        public Heatindex heatindex { get; set; }
        public Feelslike feelslike { get; set; }
        public Qpf qpf { get; set; }
        public Snow snow { get; set; }
        public string pop { get; set; }
        public Mslp mslp { get; set; }
    }

    public class FCTTIME
    {
        public int hour { get; set; }
        public string hour_padded { get; set; }
        public int min { get; set; }
        public string min_unpadded { get; set; }
        public int sec { get; set; }
        public int year { get; set; }
        public int mon { get; set; }
        public string mon_padded { get; set; }
        public string mon_abbrev { get; set; }
        public int mday { get; set; }
        public string mday_padded { get; set; }
        public string yday { get; set; }
        public string isdst { get; set; }
        public string epoch { get; set; }
        public string pretty { get; set; }
        public string civil { get; set; }
        public string month_name { get; set; }
        public string month_name_abbrev { get; set; }
        public string weekday_name { get; set; }
        public string weekday_name_night { get; set; }
        public string weekday_name_abbrev { get; set; }
        public string weekday_name_unlang { get; set; }
        public string weekday_name_night_unlang { get; set; }
        public string ampm { get; set; }
        public string tz { get; set; }
        public string age { get; set; }
        public string UTCDATE { get; set; }
    }

    public class Temp
    {
        public short english { get; set; }
        public string metric { get; set; }
    }

    public class Dewpoint
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Wspd
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Wdir
    {
        public string dir { get; set; }
        public string degrees { get; set; }
    }

    public class Windchill
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Heatindex
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Feelslike
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Qpf
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Snow
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

    public class Mslp
    {
        public string english { get; set; }
        public string metric { get; set; }
    }

}
