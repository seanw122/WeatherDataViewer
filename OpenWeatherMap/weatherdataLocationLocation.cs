namespace OpenWeatherMap
{
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
}