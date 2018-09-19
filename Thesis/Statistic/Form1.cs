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
           // DataHandler.LoadData(@"E:\test7.csv");

            var Points = DataHandler.Angles;
            var Distances = DataHandler.Distances;
            double UnitTime = DataHandler.UnitTime;
            double Unit = UnitTime;

            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].AxisY.Maximum = DataHandler.MaxAngle;
            chart.ChartAreas["ChartArea1"].AxisY.Minimum = 0;

            chart2.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart2.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;

            lb_max.Text = "Max: " + Math.Round(DataHandler.MaxAngle,2).ToString() + " °";
            lb_min.Text = "Min: " + Math.Round(DataHandler.MinAngle,2).ToString() + " °";

            lb_max_2.Text = "Max: " + Math.Round(DataHandler.MaxDistance, 2).ToString();
            lb_min_2.Text = "Min: " + Math.Round(DataHandler.MinDistance, 2).ToString();

            for (int i = 0; i < Points["Thumb"].Count; i++)
            {
                chart.Series["Thumb"].Points.AddXY(Unit, Math.Round(Points["Thumb"].ElementAt(i),1));
                chart.Series["IndexFinger"].Points.AddXY(Unit, Math.Round(Points["IndexFinger"].ElementAt(i), 1));
                chart.Series["MiddleFinger"].Points.AddXY(Unit, Math.Round(Points["MiddleFinger"].ElementAt(i), 1));
                chart.Series["RingFinger"].Points.AddXY(Unit, Math.Round(Points["RingFinger"].ElementAt(i), 1));
                chart.Series["LittleFinger"].Points.AddXY(Unit, Math.Round(Points["LittleFinger"].ElementAt(i), 1));

                chart2.Series["IndexFinger"].Points.AddXY(Unit, Math.Round(Distances["IndexFinger"].ElementAt(i), 1));
                chart2.Series["MiddleFinger"].Points.AddXY(Unit, Math.Round(Distances["MiddleFinger"].ElementAt(i), 1));
                chart2.Series["RingFinger"].Points.AddXY(Unit, Math.Round(Distances["RingFinger"].ElementAt(i), 1));
                chart2.Series["LittleFinger"].Points.AddXY(Unit, Math.Round(Distances["LittleFinger"].ElementAt(i), 1));

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

        private void tp_1_Click(object sender, EventArgs e)
        {

        }

        private void lb_max_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_if_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_if_2.Checked)
            {
                chart2.Series["IndexFinger"].Enabled = true;
            }
            else
            {
                chart2.Series["IndexFinger"].Enabled = false;
            }
        }

        private void cb_mf_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_mf_2.Checked)
            {
                chart2.Series["MiddleFinger"].Enabled = true;
            }
            else
            {
                chart2.Series["MiddleFinger"].Enabled = false;
            }
        }

        private void cb_rf_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_rf_2.Checked)
            {
                chart2.Series["RingFinger"].Enabled = true;
            }
            else
            {
                chart2.Series["RingFinger"].Enabled = false;
            }
        }

        private void cb_lf_2_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_lf_2.Checked)
            {
                chart2.Series["LittleFinger"].Enabled = true;
            }
            else
            {
                chart2.Series["LittleFinger"].Enabled = false;
            }
        }
    }
}
