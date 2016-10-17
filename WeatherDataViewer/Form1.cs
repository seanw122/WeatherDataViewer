using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WeatherDataViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

            //Make call to Weather UnderGround for data
            var key = ConfigurationManager.AppSettings["WeatherUnderGroundKey"];
            var client = new WebClient();
            var commandString = "http://api.wunderground.com/api/"
                                + key + "/hourly10day/q/OK/Tulsa.xml";
            var weatherData = client.DownloadString(commandString);

            //Inflate XML data to classes
            var serializer = new XmlSerializer(typeof (response));
            response wx;
            using (var sr = new StringReader(weatherData))
                wx = (response) serializer.Deserialize(sr);


            //Format data
            var sb = new StringBuilder();

            sb.AppendLine("From WeatherUnderground");
            sb.Append($"{"Date",20}{"Conditions",45}{"Temp",10}\r\n");

            foreach (var forecast in wx.hourly_forecast)
            {
                var prettyDate = forecast.FCTTIME.pretty;
                sb.Append($"{prettyDate,-35}");
                sb.Append($"{forecast.condition,-30}");
                sb.AppendLine($"{forecast.temp.english,-5}");
            }

            //Output data
            tbData.Text = sb.ToString();
            sb.Clear();


            //Get OpenWeatherData
            var owdKey = ConfigurationManager.AppSettings["OpenWeatherMapKey"];
            commandString = "http://api.openweathermap.org/data/2.5/forecast?q=Tulsa,us&mode=xml&appid=" + owdKey;

            var owdata = client.DownloadString(commandString);

            var owSerializer = new XmlSerializer(typeof (weatherdata));
            weatherdata wd;
            using (var sr = new StringReader(owdata))
                wd = (weatherdata) owSerializer.Deserialize(sr);

            sb.AppendLine("From OpenWeatherMap");
            sb.AppendFormat("{0,20}{1,45}\r\n", "Date", "Temp");

            foreach (var f in wd.forecast)
            {
                sb.AppendLine(String.Format("{0,-35}{1,-30}", f.from.ToString(), ConvertToFahrenheit(f.temperature.value).ToString()));
            }

            tbData.Text += "\r\n\r\n" + sb.ToString();
        }

        private decimal ConvertToFahrenheit(decimal value)
        {
            return value * (9/5) + 32;
        }
}

    #region WeatherUnderground Data

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class response
    {

        private decimal versionField;

        private string termsofServiceField;

        private responseFeatures featuresField;

        private responseForecast[] hourly_forecastField;

        /// <remarks/>
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public string termsofService
        {
            get
            {
                return this.termsofServiceField;
            }
            set
            {
                this.termsofServiceField = value;
            }
        }

        /// <remarks/>
        public responseFeatures features
        {
            get
            {
                return this.featuresField;
            }
            set
            {
                this.featuresField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("forecast", IsNullable = false)]
        public responseForecast[] hourly_forecast
        {
            get
            {
                return this.hourly_forecastField;
            }
            set
            {
                this.hourly_forecastField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseFeatures
    {

        private string featureField;

        /// <remarks/>
        public string feature
        {
            get
            {
                return this.featureField;
            }
            set
            {
                this.featureField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecast
    {

        private responseForecastFCTTIME fCTTIMEField;

        private responseForecastTemp tempField;

        private responseForecastDewpoint dewpointField;

        private string conditionField;

        private string iconField;

        private string icon_urlField;

        private byte fctcodeField;

        private byte skyField;

        private responseForecastWspd wspdField;

        private responseForecastWdir wdirField;

        private string wxField;

        private byte uviField;

        private byte humidityField;

        private responseForecastWindchill windchillField;

        private responseForecastHeatindex heatindexField;

        private responseForecastFeelslike feelslikeField;

        private responseForecastQpf qpfField;

        private responseForecastSnow snowField;

        private byte popField;

        private responseForecastMslp mslpField;

        /// <remarks/>
        public responseForecastFCTTIME FCTTIME
        {
            get
            {
                return this.fCTTIMEField;
            }
            set
            {
                this.fCTTIMEField = value;
            }
        }

        /// <remarks/>
        public responseForecastTemp temp
        {
            get
            {
                return this.tempField;
            }
            set
            {
                this.tempField = value;
            }
        }

        /// <remarks/>
        public responseForecastDewpoint dewpoint
        {
            get
            {
                return this.dewpointField;
            }
            set
            {
                this.dewpointField = value;
            }
        }

        /// <remarks/>
        public string condition
        {
            get
            {
                return this.conditionField;
            }
            set
            {
                this.conditionField = value;
            }
        }

        /// <remarks/>
        public string icon
        {
            get
            {
                return this.iconField;
            }
            set
            {
                this.iconField = value;
            }
        }

        /// <remarks/>
        public string icon_url
        {
            get
            {
                return this.icon_urlField;
            }
            set
            {
                this.icon_urlField = value;
            }
        }

        /// <remarks/>
        public byte fctcode
        {
            get
            {
                return this.fctcodeField;
            }
            set
            {
                this.fctcodeField = value;
            }
        }

        /// <remarks/>
        public byte sky
        {
            get
            {
                return this.skyField;
            }
            set
            {
                this.skyField = value;
            }
        }

        /// <remarks/>
        public responseForecastWspd wspd
        {
            get
            {
                return this.wspdField;
            }
            set
            {
                this.wspdField = value;
            }
        }

        /// <remarks/>
        public responseForecastWdir wdir
        {
            get
            {
                return this.wdirField;
            }
            set
            {
                this.wdirField = value;
            }
        }

        /// <remarks/>
        public string wx
        {
            get
            {
                return this.wxField;
            }
            set
            {
                this.wxField = value;
            }
        }

        /// <remarks/>
        public byte uvi
        {
            get
            {
                return this.uviField;
            }
            set
            {
                this.uviField = value;
            }
        }

        /// <remarks/>
        public byte humidity
        {
            get
            {
                return this.humidityField;
            }
            set
            {
                this.humidityField = value;
            }
        }

        /// <remarks/>
        public responseForecastWindchill windchill
        {
            get
            {
                return this.windchillField;
            }
            set
            {
                this.windchillField = value;
            }
        }

        /// <remarks/>
        public responseForecastHeatindex heatindex
        {
            get
            {
                return this.heatindexField;
            }
            set
            {
                this.heatindexField = value;
            }
        }

        /// <remarks/>
        public responseForecastFeelslike feelslike
        {
            get
            {
                return this.feelslikeField;
            }
            set
            {
                this.feelslikeField = value;
            }
        }

        /// <remarks/>
        public responseForecastQpf qpf
        {
            get
            {
                return this.qpfField;
            }
            set
            {
                this.qpfField = value;
            }
        }

        /// <remarks/>
        public responseForecastSnow snow
        {
            get
            {
                return this.snowField;
            }
            set
            {
                this.snowField = value;
            }
        }

        /// <remarks/>
        public byte pop
        {
            get
            {
                return this.popField;
            }
            set
            {
                this.popField = value;
            }
        }

        /// <remarks/>
        public responseForecastMslp mslp
        {
            get
            {
                return this.mslpField;
            }
            set
            {
                this.mslpField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastFCTTIME
    {

        private byte hourField;

        private byte hour_paddedField;

        private byte minField;

        private byte min_unpaddedField;

        private byte secField;

        private ushort yearField;

        private byte monField;

        private byte mon_paddedField;

        private string mon_abbrevField;

        private byte mdayField;

        private byte mday_paddedField;

        private ushort ydayField;

        private byte isdstField;

        private uint epochField;

        private string prettyField;

        private string civilField;

        private string month_nameField;

        private string month_name_abbrevField;

        private string weekday_nameField;

        private string weekday_name_nightField;

        private string weekday_name_abbrevField;

        private string weekday_name_unlangField;

        private string weekday_name_night_unlangField;

        private string ampmField;

        private object tzField;

        private object ageField;

        private object uTCDATEField;

        /// <remarks/>
        public byte hour
        {
            get
            {
                return this.hourField;
            }
            set
            {
                this.hourField = value;
            }
        }

        /// <remarks/>
        public byte hour_padded
        {
            get
            {
                return this.hour_paddedField;
            }
            set
            {
                this.hour_paddedField = value;
            }
        }

        /// <remarks/>
        public byte min
        {
            get
            {
                return this.minField;
            }
            set
            {
                this.minField = value;
            }
        }

        /// <remarks/>
        public byte min_unpadded
        {
            get
            {
                return this.min_unpaddedField;
            }
            set
            {
                this.min_unpaddedField = value;
            }
        }

        /// <remarks/>
        public byte sec
        {
            get
            {
                return this.secField;
            }
            set
            {
                this.secField = value;
            }
        }

        /// <remarks/>
        public ushort year
        {
            get
            {
                return this.yearField;
            }
            set
            {
                this.yearField = value;
            }
        }

        /// <remarks/>
        public byte mon
        {
            get
            {
                return this.monField;
            }
            set
            {
                this.monField = value;
            }
        }

        /// <remarks/>
        public byte mon_padded
        {
            get
            {
                return this.mon_paddedField;
            }
            set
            {
                this.mon_paddedField = value;
            }
        }

        /// <remarks/>
        public string mon_abbrev
        {
            get
            {
                return this.mon_abbrevField;
            }
            set
            {
                this.mon_abbrevField = value;
            }
        }

        /// <remarks/>
        public byte mday
        {
            get
            {
                return this.mdayField;
            }
            set
            {
                this.mdayField = value;
            }
        }

        /// <remarks/>
        public byte mday_padded
        {
            get
            {
                return this.mday_paddedField;
            }
            set
            {
                this.mday_paddedField = value;
            }
        }

        /// <remarks/>
        public ushort yday
        {
            get
            {
                return this.ydayField;
            }
            set
            {
                this.ydayField = value;
            }
        }

        /// <remarks/>
        public byte isdst
        {
            get
            {
                return this.isdstField;
            }
            set
            {
                this.isdstField = value;
            }
        }

        /// <remarks/>
        public uint epoch
        {
            get
            {
                return this.epochField;
            }
            set
            {
                this.epochField = value;
            }
        }

        /// <remarks/>
        public string pretty
        {
            get
            {
                return this.prettyField;
            }
            set
            {
                this.prettyField = value;
            }
        }

        /// <remarks/>
        public string civil
        {
            get
            {
                return this.civilField;
            }
            set
            {
                this.civilField = value;
            }
        }

        /// <remarks/>
        public string month_name
        {
            get
            {
                return this.month_nameField;
            }
            set
            {
                this.month_nameField = value;
            }
        }

        /// <remarks/>
        public string month_name_abbrev
        {
            get
            {
                return this.month_name_abbrevField;
            }
            set
            {
                this.month_name_abbrevField = value;
            }
        }

        /// <remarks/>
        public string weekday_name
        {
            get
            {
                return this.weekday_nameField;
            }
            set
            {
                this.weekday_nameField = value;
            }
        }

        /// <remarks/>
        public string weekday_name_night
        {
            get
            {
                return this.weekday_name_nightField;
            }
            set
            {
                this.weekday_name_nightField = value;
            }
        }

        /// <remarks/>
        public string weekday_name_abbrev
        {
            get
            {
                return this.weekday_name_abbrevField;
            }
            set
            {
                this.weekday_name_abbrevField = value;
            }
        }

        /// <remarks/>
        public string weekday_name_unlang
        {
            get
            {
                return this.weekday_name_unlangField;
            }
            set
            {
                this.weekday_name_unlangField = value;
            }
        }

        /// <remarks/>
        public string weekday_name_night_unlang
        {
            get
            {
                return this.weekday_name_night_unlangField;
            }
            set
            {
                this.weekday_name_night_unlangField = value;
            }
        }

        /// <remarks/>
        public string ampm
        {
            get
            {
                return this.ampmField;
            }
            set
            {
                this.ampmField = value;
            }
        }

        /// <remarks/>
        public object tz
        {
            get
            {
                return this.tzField;
            }
            set
            {
                this.tzField = value;
            }
        }

        /// <remarks/>
        public object age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        public object UTCDATE
        {
            get
            {
                return this.uTCDATEField;
            }
            set
            {
                this.uTCDATEField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastTemp
    {

        private byte englishField;

        private sbyte metricField;

        /// <remarks/>
        public byte english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public sbyte metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastDewpoint
    {

        private byte englishField;

        private sbyte metricField;

        /// <remarks/>
        public byte english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public sbyte metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastWspd
    {

        private byte englishField;

        private byte metricField;

        /// <remarks/>
        public byte english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public byte metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastWdir
    {

        private string dirField;

        private ushort degreesField;

        /// <remarks/>
        public string dir
        {
            get
            {
                return this.dirField;
            }
            set
            {
                this.dirField = value;
            }
        }

        /// <remarks/>
        public ushort degrees
        {
            get
            {
                return this.degreesField;
            }
            set
            {
                this.degreesField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastWindchill
    {

        private short englishField;

        private short metricField;

        /// <remarks/>
        public short english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public short metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastHeatindex
    {

        private short englishField;

        private short metricField;

        /// <remarks/>
        public short english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public short metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastFeelslike
    {

        private byte englishField;

        private sbyte metricField;

        /// <remarks/>
        public byte english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public sbyte metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastQpf
    {

        private decimal englishField;

        private byte metricField;

        /// <remarks/>
        public decimal english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public byte metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastSnow
    {

        private decimal englishField;

        private byte metricField;

        /// <remarks/>
        public decimal english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public byte metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class responseForecastMslp
    {

        private decimal englishField;

        private ushort metricField;

        /// <remarks/>
        public decimal english
        {
            get
            {
                return this.englishField;
            }
            set
            {
                this.englishField = value;
            }
        }

        /// <remarks/>
        public ushort metric
        {
            get
            {
                return this.metricField;
            }
            set
            {
                this.metricField = value;
            }
        }
    }


    #endregion

    #region OpenWeatherMap Data
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class weatherdata
    {

        private weatherdataLocation locationField;

        private object creditField;

        private weatherdataMeta metaField;

        private weatherdataSun sunField;

        private weatherdataTime[] forecastField;

        /// <remarks/>
        public weatherdataLocation location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        public object credit
        {
            get
            {
                return this.creditField;
            }
            set
            {
                this.creditField = value;
            }
        }

        /// <remarks/>
        public weatherdataMeta meta
        {
            get
            {
                return this.metaField;
            }
            set
            {
                this.metaField = value;
            }
        }

        /// <remarks/>
        public weatherdataSun sun
        {
            get
            {
                return this.sunField;
            }
            set
            {
                this.sunField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("time", IsNullable = false)]
        public weatherdataTime[] forecast
        {
            get
            {
                return this.forecastField;
            }
            set
            {
                this.forecastField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataLocation
    {

        private string nameField;

        private object typeField;

        private string countryField;

        private object timezoneField;

        private weatherdataLocationLocation locationField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public object type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public object timezone
        {
            get
            {
                return this.timezoneField;
            }
            set
            {
                this.timezoneField = value;
            }
        }

        /// <remarks/>
        public weatherdataLocationLocation location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataLocationLocation
    {

        private byte altitudeField;

        private decimal latitudeField;

        private decimal longitudeField;

        private string geobaseField;

        private byte geobaseidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte altitude
        {
            get
            {
                return this.altitudeField;
            }
            set
            {
                this.altitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string geobase
        {
            get
            {
                return this.geobaseField;
            }
            set
            {
                this.geobaseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte geobaseid
        {
            get
            {
                return this.geobaseidField;
            }
            set
            {
                this.geobaseidField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataMeta
    {

        private object lastupdateField;

        private decimal calctimeField;

        private object nextupdateField;

        /// <remarks/>
        public object lastupdate
        {
            get
            {
                return this.lastupdateField;
            }
            set
            {
                this.lastupdateField = value;
            }
        }

        /// <remarks/>
        public decimal calctime
        {
            get
            {
                return this.calctimeField;
            }
            set
            {
                this.calctimeField = value;
            }
        }

        /// <remarks/>
        public object nextupdate
        {
            get
            {
                return this.nextupdateField;
            }
            set
            {
                this.nextupdateField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataSun
    {

        private System.DateTime riseField;

        private System.DateTime setField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime rise
        {
            get
            {
                return this.riseField;
            }
            set
            {
                this.riseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime set
        {
            get
            {
                return this.setField;
            }
            set
            {
                this.setField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTime
    {

        private weatherdataTimeSymbol symbolField;

        private weatherdataTimePrecipitation precipitationField;

        private weatherdataTimeWindDirection windDirectionField;

        private weatherdataTimeWindSpeed windSpeedField;

        private weatherdataTimeTemperature temperatureField;

        private weatherdataTimePressure pressureField;

        private weatherdataTimeHumidity humidityField;

        private weatherdataTimeClouds cloudsField;

        private System.DateTime fromField;

        private System.DateTime toField;

        /// <remarks/>
        public weatherdataTimeSymbol symbol
        {
            get
            {
                return this.symbolField;
            }
            set
            {
                this.symbolField = value;
            }
        }

        /// <remarks/>
        public weatherdataTimePrecipitation precipitation
        {
            get
            {
                return this.precipitationField;
            }
            set
            {
                this.precipitationField = value;
            }
        }

        /// <remarks/>
        public weatherdataTimeWindDirection windDirection
        {
            get
            {
                return this.windDirectionField;
            }
            set
            {
                this.windDirectionField = value;
            }
        }

        /// <remarks/>
        public weatherdataTimeWindSpeed windSpeed
        {
            get
            {
                return this.windSpeedField;
            }
            set
            {
                this.windSpeedField = value;
            }
        }

        /// <remarks/>
        public weatherdataTimeTemperature temperature
        {
            get
            {
                return this.temperatureField;
            }
            set
            {
                this.temperatureField = value;
            }
        }

        /// <remarks/>
        public weatherdataTimePressure pressure
        {
            get
            {
                return this.pressureField;
            }
            set
            {
                this.pressureField = value;
            }
        }

        /// <remarks/>
        public weatherdataTimeHumidity humidity
        {
            get
            {
                return this.humidityField;
            }
            set
            {
                this.humidityField = value;
            }
        }

        /// <remarks/>
        public weatherdataTimeClouds clouds
        {
            get
            {
                return this.cloudsField;
            }
            set
            {
                this.cloudsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime from
        {
            get
            {
                return this.fromField;
            }
            set
            {
                this.fromField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime to
        {
            get
            {
                return this.toField;
            }
            set
            {
                this.toField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimeSymbol
    {

        private ushort numberField;

        private string nameField;

        private string varField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string var
        {
            get
            {
                return this.varField;
            }
            set
            {
                this.varField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimePrecipitation
    {

        private string unitField;

        private decimal valueField;

        private bool valueFieldSpecified;

        private string typeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueSpecified
        {
            get
            {
                return this.valueFieldSpecified;
            }
            set
            {
                this.valueFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimeWindDirection
    {

        private decimal degField;

        private string codeField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal deg
        {
            get
            {
                return this.degField;
            }
            set
            {
                this.degField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimeWindSpeed
    {

        private decimal mpsField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal mps
        {
            get
            {
                return this.mpsField;
            }
            set
            {
                this.mpsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimeTemperature
    {

        private string unitField;

        private decimal valueField;

        private decimal minField;

        private decimal maxField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal min
        {
            get
            {
                return this.minField;
            }
            set
            {
                this.minField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal max
        {
            get
            {
                return this.maxField;
            }
            set
            {
                this.maxField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimePressure
    {

        private string unitField;

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimeHumidity
    {

        private byte valueField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class weatherdataTimeClouds
    {

        private string valueField;

        private byte allField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte all
        {
            get
            {
                return this.allField;
            }
            set
            {
                this.allField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

#endregion
}
