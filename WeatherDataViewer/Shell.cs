using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeatherDataViewer.Common;

namespace WeatherDataViewer
{
    public partial class Shell : Form
    {
        private readonly BackgroundWorker _worker;
        private readonly Dictionary<string, IWeatherDataGetter> _dataGetters;

        public Shell()
        {
            InitializeComponent();

            _worker = new BackgroundWorker();
            _worker.DoWork += DoBackGroundWork;
            _worker.RunWorkerCompleted += BackgroundWorkCompleted;

            var foo = new WeatherDataFactory();
            _dataGetters = foo.WeatherGetters;
            LoadPlugins();

            btnGetData.Enabled = false;
        }

        private void BackgroundWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = (string)e.Result;
            tbData.Text = result;
            btnGetData.Enabled = true;
        }

        private void DoBackGroundWork(object sender, DoWorkEventArgs e)
        {
            var sb = new StringBuilder();

            foreach (Panel panel in pnlOptions.Controls)
            {
                foreach (CheckBox chkBox in panel.Controls)
                {
                    if (chkBox.Checked)
                    {
                        var weatherDataClass = (IWeatherDataGetter)chkBox.Tag;
                        IWeatherData result = weatherDataClass.GetWeatherData(chkBox.Text);
                        sb.AppendLine(FormatDataResults(chkBox.Text, result));
                    }
                }
            }

            e.Result = sb.ToString();
        }

        private string FormatDataResults(string option, IWeatherData weatherData)
        {
            var sb = new StringBuilder();
            var header = $"{"Date",35}{" Conditions", 10}{" Temp",45}";

            sb.AppendLine($"From {weatherData.DataSourceName}-------{option}-------------");
            sb.AppendLine(header);

            foreach (var forecast in weatherData.Records.Where(x => x != null).OrderBy(y => y.Date))
            {
                sb.Append($"{forecast.Date,-35}");
                sb.Append($"{forecast.Conditions,-30}");

                if (forecast.Temp != null)
                {
                    sb.AppendLine($"{forecast.Temp, -5}");
                }
                else
                {
                    sb.AppendLine(forecast.Low + "/" + forecast.High);
                }

                
            }

            return sb.ToString();
        }

        private void LoadPlugins()
        {
            foreach (var data in _dataGetters)
            {
                var offeringPanel = new FlowLayoutPanel();
                pnlOptions.Text = data.Key;
                pnlOptions.FlowDirection = FlowDirection.LeftToRight;
                pnlOptions.Controls.Add(offeringPanel);

                foreach (var offering in data.Value.Offerings)
                {
                    var checkbox = new CheckBox()
                    {
                        Text = offering,
                        Width = 200,
                        Tag = data.Value
                    };

                    checkbox.CheckedChanged += OnCheckBoxChecked;
                    offeringPanel.Controls.Add(checkbox);
                }
            }
        }

        private void OnCheckBoxChecked(object sender, EventArgs e)
        {
            var panels = pnlOptions.Controls.Cast<FlowLayoutPanel>();

            bool isEnabled = false;

            foreach (var flowLayoutPanel in panels)
            {
                if (flowLayoutPanel.Controls.Cast<CheckBox>().Any(x => x.Checked))
                {
                    isEnabled = true;
                    break;
                }
            }

            btnGetData.Enabled = isEnabled;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            GetWeather();
        }

        private void GetWeather()
        {
            btnGetData.Enabled = false;
            tbData.Text = "";
            _worker.RunWorkerAsync();
        }

    }
}
