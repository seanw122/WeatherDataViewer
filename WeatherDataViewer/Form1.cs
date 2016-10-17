using System;
using System.Configuration;
using System.IO;
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
            //Go get data
            var key = ConfigurationManager.AppSettings["WeatherUnderGroundKey"];
            var client = new WebClient();
            var commandString = "http://api.wunderground.com/api/"
                        + key + "/hourly10day/q/AR/Fort_Smith.xml";
            var weatherData = client.DownloadString(commandString);

            //Inflate XML data to classes
            var serializer = new XmlSerializer(typeof(response));
            response wx;
            using (var sr = new StringReader(weatherData))
                wx = (response)serializer.Deserialize(sr);

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

            //Format and Output data
            tbData.Text = sb.ToString();
        }
    }



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
    public partial class responseForecastDewpoint
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





}
