namespace OpenWeatherMap
{
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
}