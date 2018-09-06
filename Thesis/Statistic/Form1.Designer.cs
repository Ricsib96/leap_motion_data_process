using System.Collections.Generic;

namespace Statistic
{
    partial class Form1
    {
        
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cb_lf = new System.Windows.Forms.CheckBox();
            this.cb_t = new System.Windows.Forms.CheckBox();
            this.cb_if = new System.Windows.Forms.CheckBox();
            this.cb_mf = new System.Windows.Forms.CheckBox();
            this.cb_rf = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Silver;
            this.chart.BorderlineColor = System.Drawing.Color.WhiteSmoke;
            this.chart.BorderSkin.PageColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.Title = "t(s)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.Title = "Angle(°)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, -2);
            this.chart.Margin = new System.Windows.Forms.Padding(0);
            this.chart.Name = "chart";
            series1.BackImageTransparentColor = System.Drawing.Color.Gray;
            series1.BackSecondaryColor = System.Drawing.Color.Silver;
            series1.BorderColor = System.Drawing.Color.Silver;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Thumb";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "IndexFinger";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Green;
            series3.Legend = "Legend1";
            series3.Name = "MiddleFinger";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Black;
            series4.Legend = "Legend1";
            series4.Name = "RingFinger";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series5.Legend = "Legend1";
            series5.Name = "LittleFinger";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Size = new System.Drawing.Size(981, 565);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // cb_lf
            // 
            this.cb_lf.AutoSize = true;
            this.cb_lf.BackColor = System.Drawing.Color.Silver;
            this.cb_lf.Checked = true;
            this.cb_lf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lf.Location = new System.Drawing.Point(835, 196);
            this.cb_lf.Name = "cb_lf";
            this.cb_lf.Size = new System.Drawing.Size(77, 17);
            this.cb_lf.TabIndex = 1;
            this.cb_lf.Text = "LittleFinger";
            this.cb_lf.UseVisualStyleBackColor = false;
            this.cb_lf.CheckedChanged += new System.EventHandler(this.cb_lf_CheckedChanged);
            // 
            // cb_t
            // 
            this.cb_t.AutoSize = true;
            this.cb_t.BackColor = System.Drawing.Color.Silver;
            this.cb_t.Checked = true;
            this.cb_t.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_t.Location = new System.Drawing.Point(835, 104);
            this.cb_t.Name = "cb_t";
            this.cb_t.Size = new System.Drawing.Size(59, 17);
            this.cb_t.TabIndex = 2;
            this.cb_t.Text = "Thumb";
            this.cb_t.UseVisualStyleBackColor = false;
            this.cb_t.CheckedChanged += new System.EventHandler(this.cb_t_CheckedChanged);
            // 
            // cb_if
            // 
            this.cb_if.AutoSize = true;
            this.cb_if.BackColor = System.Drawing.Color.Silver;
            this.cb_if.Checked = true;
            this.cb_if.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_if.Location = new System.Drawing.Point(835, 127);
            this.cb_if.Name = "cb_if";
            this.cb_if.Size = new System.Drawing.Size(81, 17);
            this.cb_if.TabIndex = 3;
            this.cb_if.Text = "IndexFinger";
            this.cb_if.UseVisualStyleBackColor = false;
            this.cb_if.CheckedChanged += new System.EventHandler(this.cb_if_CheckedChanged);
            // 
            // cb_mf
            // 
            this.cb_mf.AutoSize = true;
            this.cb_mf.BackColor = System.Drawing.Color.Silver;
            this.cb_mf.Checked = true;
            this.cb_mf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mf.Location = new System.Drawing.Point(835, 150);
            this.cb_mf.Name = "cb_mf";
            this.cb_mf.Size = new System.Drawing.Size(86, 17);
            this.cb_mf.TabIndex = 4;
            this.cb_mf.Text = "MiddleFinger";
            this.cb_mf.UseVisualStyleBackColor = false;
            this.cb_mf.CheckedChanged += new System.EventHandler(this.cb_mf_CheckedChanged);
            // 
            // cb_rf
            // 
            this.cb_rf.AutoSize = true;
            this.cb_rf.BackColor = System.Drawing.Color.Silver;
            this.cb_rf.Checked = true;
            this.cb_rf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_rf.Location = new System.Drawing.Point(835, 173);
            this.cb_rf.Name = "cb_rf";
            this.cb_rf.Size = new System.Drawing.Size(77, 17);
            this.cb_rf.TabIndex = 5;
            this.cb_rf.Text = "RingFinger";
            this.cb_rf.UseVisualStyleBackColor = false;
            this.cb_rf.CheckedChanged += new System.EventHandler(this.cb_rf_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.cb_rf);
            this.Controls.Add(this.cb_mf);
            this.Controls.Add(this.cb_if);
            this.Controls.Add(this.cb_t);
            this.Controls.Add(this.cb_lf);
            this.Controls.Add(this.chart);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.CheckBox cb_lf;
        private System.Windows.Forms.CheckBox cb_t;
        private System.Windows.Forms.CheckBox cb_if;
        private System.Windows.Forms.CheckBox cb_mf;
        private System.Windows.Forms.CheckBox cb_rf;
    }
}

