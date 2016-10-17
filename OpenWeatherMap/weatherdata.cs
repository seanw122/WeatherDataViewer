namespace OpenWeatherMap
{
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
}