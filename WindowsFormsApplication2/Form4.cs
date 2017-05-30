using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public double f(double k)
        {
            return 3 * k * k + k;
        }

        public double df(double k)
        {
            return 6 * k + 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double x0, x, eps;
            x0 = Convert.ToDouble(textBox1.Text);
            eps = Convert.ToDouble(textBox2.Text);

            chart1.Series.Clear();
            chart1.Series.Add("");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            for (double xx = -10; xx <= 10; xx = xx + 0.5)
            {
                chart1.Series[0].Points.AddXY(xx, f(xx));
            }
            do
            {
                x = x0;
                x0 = x - f(x) / df(x);

            }
            while (Math.Abs(x0 - x) > eps);
            label3.Text = "x = " +Convert.ToString(x0);
            label4.Text ="f(x) = "+ Convert.ToString(f(x0));
        }
    }
}
