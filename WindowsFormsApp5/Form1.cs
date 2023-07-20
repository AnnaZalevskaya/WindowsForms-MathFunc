using System;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            if (textBoxStep.Text != string.Empty && textBoxXmax.Text != string.Empty && textBoxXmin.Text != string.Empty)
            {
                double Xmin = 0;
                Xmin = GetNum(textBoxXmin, Xmin);
                double Xmax = 0;
                Xmax = GetNum(textBoxXmax, Xmax);
                double Step = 0;
                Step = GetNum(textBoxStep, Step);
                double b = -0.8;
                if (Xmax > Xmin && Step > 0)
                {
                    double kolPointer = (Xmax - Xmin) / Step + 1;
                    int count = (int)Math.Ceiling(kolPointer);

                    double[] x = new double[count];

                    double[] y1 = new double[count];
                    double[] y2 = new double[count];

                    for (int i = 0; i < count; i++)
                    {
                        x[i] = Xmin + Step * i;
                        y1[i] = Math.Pow(x[i], 2) + Math.Tan(5 * x[i] + b / x[i]);
                        y2[i] = x[i];
                        listBoxPoints.Items.Add("[" + x[i] + "; " + y1[i] + "]");
                    }

                    chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                    chart1.ChartAreas[0].AxisX.Maximum = Xmax;

                    chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;

                    chart1.Series[0].Points.DataBindXY(x, y1);
                    chart1.Series[1].Points.DataBindXY(x, y2);
                }
                else
                {
                    MessageBox.Show("Введены невозможные значения!");
                }
            }
            else { MessageBox.Show("Значения не введены!"); }
        }
        private double GetNum(TextBox textBox, double x)
        {
            if(!double.TryParse(textBox.Text, out x))
            {
                MessageBox.Show("Значение некорректно!");
            }
            return x;
        }
    }
}
