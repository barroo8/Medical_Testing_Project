using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalPJ
{
    public partial class ChartsForm : Form
    {
        public ChartsForm()
        {
            InitializeComponent();
        }

        private void ChartsForm_Load(object sender, EventArgs e)
        {

            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorTickMark.Enabled = false;
            chart1.ChartAreas[0].AxisY.LineWidth = 0;

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MinorGrid.LineWidth = 0;

            //--- COLORS GUIDE ---
            //Green = OK
            //Red = HIGH 
            //Blue = LOW

            int[] highOrLowVal = Form2.alex.Diagnosis();
            string[] valsName = { "WBC", "Neut", "Lymph", "RBC", "HCT", "Urea", "Hb", "Crtn", "Iron", "HDL", "AP" };
            float[] vals = Form2.alex.normolizevalues();
            //chart1.Series[0].Color = Color.Green;

            for (int i = 0; i<highOrLowVal.Length; i++)
            {
                if (highOrLowVal[i] == 1)
                {
                    chart1.Series[0].Points.AddXY(valsName[i], vals[i]);
                    chart1.Series[0].Points[i].Color = Color.Red;
                }
                else if (highOrLowVal[i] == -1)
                {
                    chart1.Series[0].Points.AddXY(valsName[i], vals[i]);
                    chart1.Series[0].Points[i].Color = Color.Blue;
                }
                else
                {
                    chart1.Series[0].Points.AddXY(valsName[i], vals[i]);
                    chart1.Series[0].Points[i].Color = Color.Green;
                }
            }
        }
    }
}
