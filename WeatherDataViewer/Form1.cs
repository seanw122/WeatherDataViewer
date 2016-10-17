using System;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var results = String.Empty;
            btnGetData.Enabled = false;

            var weatherDataFactory = new WeatherDataFactory();

            var weatherUnderground = weatherDataFactory.GetWeatherDataClass("WeatherUnderground");
            var openWeatherMap = weatherDataFactory.GetWeatherDataClass("OpenWeatherMap");

            var t = new Task(() =>
            {
                results = weatherUnderground.GetWeatherData();
                results += "\r\n\r\n" + openWeatherMap.GetWeatherData();
            });

            var t2 = t.ContinueWith((antecedent) =>
            {
                tbData.Text = results;
                btnGetData.Enabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());

            t.Start();
        }
    }
}
