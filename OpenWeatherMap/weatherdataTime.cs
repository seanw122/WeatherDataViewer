namespace OpenWeatherMap
{
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
}