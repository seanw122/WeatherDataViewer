using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherDataViewer
{
    public partial class Form1 : Form
    {
        WeatherDataFactory _weatherDataFactory;

        public Form1()
        {
            InitializeComponent();
            LoadPlugins();
        }

        private void LoadPlugins()
        {
            _weatherDataFactory = new WeatherDataFactory();

            foreach (var weatherDataClass in _weatherDataFactory.LoadedWeatherDataClasses)
            {
                var checkBox = new CheckBox {Text = weatherDataClass.Name, Width = 200};
                panel2.Controls.Add(checkBox);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if (panel2.Controls.Cast<CheckBox>().All(x => x.Checked == false))
                return;

            var results = String.Empty;
            btnGetData.Enabled = false;
            tbData.Invoke(new MethodInvoker(() => tbData.Text = ""));

            foreach (CheckBox control in panel2.Controls)
            {
                if (control.Checked)
                {
                    var weatherDataClass = _weatherDataFactory.GetWeatherDataClass(control.Text);

                    var t = new Task(() =>
                    {
                        results = weatherDataClass.GetWeatherData();
                    });

                    var t2 = t.ContinueWith((antecedent) =>
                    {
                        tbData.Text += results + "\r\n\r\n";
                        btnGetData.Enabled = true;
                    }, TaskScheduler.FromCurrentSynchronizationContext());

                    t.Start();
                }
            }
        }
    }
}
