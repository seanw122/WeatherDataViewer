namespace OpenWeatherMap
{
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
}