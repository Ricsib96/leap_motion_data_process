using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            FillChart();
        }
        public void FillChart()
        {
            PipeClient Client = new PipeClient();
            Client.StartClient();
            DataHandler DataHandler = new DataHandler();
            DataHandler.LoadData(Client.File_name);

            var Points = DataHandler.Angles;
            double UnitTime = DataHandler.UnitTime;
            double Unit = UnitTime;

            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].BackColor = Color.Silver;
            chart.ChartAreas["ChartArea1"].AxisY.Maximum = 25;
            chart.ChartAreas["ChartArea1"].AxisY.Minimum = -1;


            for (int i = 0; i < Points["Thumb"].Count; i++)
            {
                chart.Series["Thumb"].Points.AddXY(Unit, Points["Thumb"].ElementAt(i));
                chart.Series["IndexFinger"].Points.AddXY(Unit, Points["IndexFinger"].ElementAt(i));
                chart.Series["MiddleFinger"].Points.AddXY(Unit, Points["MiddleFinger"].ElementAt(i));
                chart.Series["RingFinger"].Points.AddXY(Unit, Points["RingFinger"].ElementAt(i));
                chart.Series["LittleFinger"].Points.AddXY(Unit, Points["LittleFinger"].ElementAt(i));

                Trace.WriteLine(Points["Thumb"].ElementAt(i));

                Unit += UnitTime;
            }
            
            
        }

        private void cb_lf_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_lf.Checked)
            {
                chart.Series["LittleFinger"].Enabled = true;
            }
            else
            {
                chart.Series["LittleFinger"].Enabled = false;
            }
        }

        private void cb_t_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_t.Checked)
            {
                chart.Series["Thumb"].Enabled = true;
            }
            else
            {
                chart.Series["Thumb"].Enabled = false;
            }
        }

        private void cb_rf_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_rf.Checked)
            {
                chart.Series["RingFinger"].Enabled = true;
            }
            else
            {
                chart.Series["RingFinger"].Enabled = false;
            }
        }

        private void cb_if_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_if.Checked)
            {
                chart.Series["IndexFinger"].Enabled = true;
            }
            else
            {
                chart.Series["IndexFinger"].Enabled = false;
            }
        }

        private void cb_mf_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_mf.Checked)
            {
                chart.Series["MiddleFinger"].Enabled = true;
            }
            else
            {
                chart.Series["MiddleFinger"].Enabled = false;
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
