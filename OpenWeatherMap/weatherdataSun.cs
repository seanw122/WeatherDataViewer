namespace OpenWeatherMap
{
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
}