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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tab = new System.Windows.Forms.TabControl();
            this.tp_1 = new System.Windows.Forms.TabPage();
            this.lb_min = new System.Windows.Forms.Label();
            this.lb_max = new System.Windows.Forms.Label();
            this.cb_lf = new System.Windows.Forms.CheckBox();
            this.cb_rf = new System.Windows.Forms.CheckBox();
            this.cb_mf = new System.Windows.Forms.CheckBox();
            this.cb_if = new System.Windows.Forms.CheckBox();
            this.cb_t = new System.Windows.Forms.CheckBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tp_2 = new System.Windows.Forms.TabPage();
            this.cb_lf_2 = new System.Windows.Forms.CheckBox();
            this.cb_rf_2 = new System.Windows.Forms.CheckBox();
            this.cb_mf_2 = new System.Windows.Forms.CheckBox();
            this.cb_if_2 = new System.Windows.Forms.CheckBox();
            this.lb_min_2 = new System.Windows.Forms.Label();
            this.lb_max_2 = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tab.SuspendLayout();
            this.tp_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tp_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tp_1);
            this.tab.Controls.Add(this.tp_2);
            this.tab.Location = new System.Drawing.Point(0, -2);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 1;
            this.tab.Size = new System.Drawing.Size(1188, 793);
            this.tab.TabIndex = 8;
            // 
            // tp_1
            // 
            this.tp_1.BackColor = System.Drawing.Color.Silver;
            this.tp_1.Controls.Add(this.lb_min);
            this.tp_1.Controls.Add(this.lb_max);
            this.tp_1.Controls.Add(this.cb_lf);
            this.tp_1.Controls.Add(this.cb_rf);
            this.tp_1.Controls.Add(this.cb_mf);
            this.tp_1.Controls.Add(this.cb_if);
            this.tp_1.Controls.Add(this.cb_t);
            this.tp_1.Controls.Add(this.chart);
            this.tp_1.Location = new System.Drawing.Point(4, 22);
            this.tp_1.Name = "tp_1";
            this.tp_1.Padding = new System.Windows.Forms.Padding(3);
            this.tp_1.Size = new System.Drawing.Size(1180, 767);
            this.tp_1.TabIndex = 0;
            this.tp_1.Text = "Angle";
            this.tp_1.Click += new System.EventHandler(this.tp_1_Click);
            // 
            // lb_min
            // 
            this.lb_min.AutoSize = true;
            this.lb_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_min.Location = new System.Drawing.Point(1071, 309);
            this.lb_min.Name = "lb_min";
            this.lb_min.Size = new System.Drawing.Size(32, 16);
            this.lb_min.TabIndex = 7;
            this.lb_min.Text = "Min:";
            // 
            // lb_max
            // 
            this.lb_max.AutoSize = true;
            this.lb_max.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_max.Location = new System.Drawing.Point(1071, 283);
            this.lb_max.Name = "lb_max";
            this.lb_max.Size = new System.Drawing.Size(36, 16);
            this.lb_max.TabIndex = 6;
            this.lb_max.Text = "Max:";
            this.lb_max.Click += new System.EventHandler(this.lb_max_Click);
            // 
            // cb_lf
            // 
            this.cb_lf.AutoSize = true;
            this.cb_lf.Checked = true;
            this.cb_lf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_lf.Location = new System.Drawing.Point(1071, 230);
            this.cb_lf.Name = "cb_lf";
            this.cb_lf.Size = new System.Drawing.Size(92, 20);
            this.cb_lf.TabIndex = 5;
            this.cb_lf.Text = "LittleFinger";
            this.cb_lf.UseVisualStyleBackColor = true;
            this.cb_lf.CheckedChanged += new System.EventHandler(this.cb_lf_CheckedChanged);
            // 
            // cb_rf
            // 
            this.cb_rf.AutoSize = true;
            this.cb_rf.Checked = true;
            this.cb_rf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_rf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_rf.Location = new System.Drawing.Point(1071, 206);
            this.cb_rf.Name = "cb_rf";
            this.cb_rf.Size = new System.Drawing.Size(93, 20);
            this.cb_rf.TabIndex = 4;
            this.cb_rf.Text = "RingFinger";
            this.cb_rf.UseVisualStyleBackColor = true;
            this.cb_rf.CheckedChanged += new System.EventHandler(this.cb_rf_CheckedChanged);
            // 
            // cb_mf
            // 
            this.cb_mf.AutoSize = true;
            this.cb_mf.Checked = true;
            this.cb_mf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_mf.Location = new System.Drawing.Point(1071, 182);
            this.cb_mf.Name = "cb_mf";
            this.cb_mf.Size = new System.Drawing.Size(106, 20);
            this.cb_mf.TabIndex = 3;
            this.cb_mf.Text = "MiddleFinger";
            this.cb_mf.UseVisualStyleBackColor = true;
            this.cb_mf.CheckedChanged += new System.EventHandler(this.cb_mf_CheckedChanged);
            // 
            // cb_if
            // 
            this.cb_if.AutoSize = true;
            this.cb_if.Checked = true;
            this.cb_if.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_if.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_if.Location = new System.Drawing.Point(1071, 158);
            this.cb_if.Name = "cb_if";
            this.cb_if.Size = new System.Drawing.Size(97, 20);
            this.cb_if.TabIndex = 2;
            this.cb_if.Text = "IndexFinger";
            this.cb_if.UseVisualStyleBackColor = true;
            this.cb_if.CheckedChanged += new System.EventHandler(this.cb_if_CheckedChanged);
            // 
            // cb_t
            // 
            this.cb_t.AutoSize = true;
            this.cb_t.Checked = true;
            this.cb_t.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_t.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_t.Location = new System.Drawing.Point(1071, 134);
            this.cb_t.Name = "cb_t";
            this.cb_t.Size = new System.Drawing.Size(69, 20);
            this.cb_t.TabIndex = 1;
            this.cb_t.Text = "Thumb";
            this.cb_t.UseVisualStyleBackColor = true;
            this.cb_t.CheckedChanged += new System.EventHandler(this.cb_t_CheckedChanged);
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.Interval = 2D;
            chartArea1.AxisX.Title = "t(s)";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.Interval = 10D;
            chartArea1.AxisY.Title = "Angle (°)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.BackColor = System.Drawing.Color.Silver;
            chartArea1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Silver;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(-38, 0);
            this.chart.Name = "chart";
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
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series3.Legend = "Legend1";
            series3.Name = "MiddleFinger";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series4.Legend = "Legend1";
            series4.Name = "RingFinger";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Black;
            series5.Legend = "Legend1";
            series5.Name = "LittleFinger";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Series.Add(series3);
            this.chart.Series.Add(series4);
            this.chart.Series.Add(series5);
            this.chart.Size = new System.Drawing.Size(1268, 650);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            // 
            // tp_2
            // 
            this.tp_2.Controls.Add(this.cb_lf_2);
            this.tp_2.Controls.Add(this.cb_rf_2);
            this.tp_2.Controls.Add(this.cb_mf_2);
            this.tp_2.Controls.Add(this.cb_if_2);
            this.tp_2.Controls.Add(this.lb_min_2);
            this.tp_2.Controls.Add(this.lb_max_2);
            this.tp_2.Controls.Add(this.chart2);
            this.tp_2.Location = new System.Drawing.Point(4, 22);
            this.tp_2.Name = "tp_2";
            this.tp_2.Padding = new System.Windows.Forms.Padding(3);
            this.tp_2.Size = new System.Drawing.Size(1180, 767);
            this.tp_2.TabIndex = 1;
            this.tp_2.Text = "Distance";
            this.tp_2.UseVisualStyleBackColor = true;
            // 
            // cb_lf_2
            // 
            this.cb_lf_2.AutoSize = true;
            this.cb_lf_2.BackColor = System.Drawing.Color.Silver;
            this.cb_lf_2.Checked = true;
            this.cb_lf_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_lf_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_lf_2.Location = new System.Drawing.Point(1068, 194);
            this.cb_lf_2.Name = "cb_lf_2";
            this.cb_lf_2.Size = new System.Drawing.Size(92, 20);
            this.cb_lf_2.TabIndex = 6;
            this.cb_lf_2.Text = "LittleFinger";
            this.cb_lf_2.UseVisualStyleBackColor = false;
            this.cb_lf_2.CheckedChanged += new System.EventHandler(this.cb_lf_2_CheckedChanged);
            // 
            // cb_rf_2
            // 
            this.cb_rf_2.AutoSize = true;
            this.cb_rf_2.BackColor = System.Drawing.Color.Silver;
            this.cb_rf_2.Checked = true;
            this.cb_rf_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_rf_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_rf_2.Location = new System.Drawing.Point(1068, 171);
            this.cb_rf_2.Name = "cb_rf_2";
            this.cb_rf_2.Size = new System.Drawing.Size(93, 20);
            this.cb_rf_2.TabIndex = 5;
            this.cb_rf_2.Text = "RingFinger";
            this.cb_rf_2.UseVisualStyleBackColor = false;
            this.cb_rf_2.CheckedChanged += new System.EventHandler(this.cb_rf_2_CheckedChanged);
            // 
            // cb_mf_2
            // 
            this.cb_mf_2.AutoSize = true;
            this.cb_mf_2.BackColor = System.Drawing.Color.Silver;
            this.cb_mf_2.Checked = true;
            this.cb_mf_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_mf_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_mf_2.Location = new System.Drawing.Point(1068, 148);
            this.cb_mf_2.Name = "cb_mf_2";
            this.cb_mf_2.Size = new System.Drawing.Size(106, 20);
            this.cb_mf_2.TabIndex = 4;
            this.cb_mf_2.Text = "MiddleFinger";
            this.cb_mf_2.UseVisualStyleBackColor = false;
            this.cb_mf_2.CheckedChanged += new System.EventHandler(this.cb_mf_2_CheckedChanged);
            // 
            // cb_if_2
            // 
            this.cb_if_2.AutoSize = true;
            this.cb_if_2.BackColor = System.Drawing.Color.Silver;
            this.cb_if_2.Checked = true;
            this.cb_if_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_if_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_if_2.Location = new System.Drawing.Point(1068, 125);
            this.cb_if_2.Name = "cb_if_2";
            this.cb_if_2.Size = new System.Drawing.Size(97, 20);
            this.cb_if_2.TabIndex = 3;
            this.cb_if_2.Text = "IndexFinger";
            this.cb_if_2.UseVisualStyleBackColor = false;
            this.cb_if_2.CheckedChanged += new System.EventHandler(this.cb_if_2_CheckedChanged);
            // 
            // lb_min_2
            // 
            this.lb_min_2.AutoSize = true;
            this.lb_min_2.BackColor = System.Drawing.Color.Silver;
            this.lb_min_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_min_2.Location = new System.Drawing.Point(1065, 280);
            this.lb_min_2.Name = "lb_min_2";
            this.lb_min_2.Size = new System.Drawing.Size(45, 16);
            this.lb_min_2.TabIndex = 2;
            this.lb_min_2.Text = "label2";
            this.lb_min_2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lb_max_2
            // 
            this.lb_max_2.AutoSize = true;
            this.lb_max_2.BackColor = System.Drawing.Color.Silver;
            this.lb_max_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb_max_2.Location = new System.Drawing.Point(1065, 253);
            this.lb_max_2.Name = "lb_max_2";
            this.lb_max_2.Size = new System.Drawing.Size(45, 16);
            this.lb_max_2.TabIndex = 1;
            this.lb_max_2.Text = "label1";
            this.lb_max_2.Click += new System.EventHandler(this.label1_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.Title = "t(s)";
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea2.AxisY.Title = "Magnitude";
            chartArea2.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea2.BackColor = System.Drawing.Color.Silver;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Silver;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(-38, 0);
            this.chart2.Name = "chart2";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Color = System.Drawing.Color.Red;
            series6.Legend = "Legend1";
            series6.Name = "IndexFinger";
            series6.YValuesPerPoint = 2;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            series7.Legend = "Legend1";
            series7.Name = "MiddleFinger";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series8.Legend = "Legend1";
            series8.Name = "RingFinger";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.Fuchsia;
            series9.Legend = "Legend1";
            series9.Name = "LittleFinger";
            this.chart2.Series.Add(series6);
            this.chart2.Series.Add(series7);
            this.chart2.Series.Add(series8);
            this.chart2.Series.Add(series9);
            this.chart2.Size = new System.Drawing.Size(1265, 650);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 657);
            this.Controls.Add(this.tab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.tab.ResumeLayout(false);
            this.tp_1.ResumeLayout(false);
            this.tp_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tp_2.ResumeLayout(false);
            this.tp_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tp_1;
        private System.Windows.Forms.TabPage tp_2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.CheckBox cb_t;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.CheckBox cb_lf;
        private System.Windows.Forms.CheckBox cb_rf;
        private System.Windows.Forms.CheckBox cb_mf;
        private System.Windows.Forms.CheckBox cb_if;
        private System.Windows.Forms.Label lb_min;
        private System.Windows.Forms.Label lb_max;
        private System.Windows.Forms.Label lb_min_2;
        private System.Windows.Forms.Label lb_max_2;
        private System.Windows.Forms.CheckBox cb_lf_2;
        private System.Windows.Forms.CheckBox cb_rf_2;
        private System.Windows.Forms.CheckBox cb_mf_2;
        private System.Windows.Forms.CheckBox cb_if_2;
    }
}

