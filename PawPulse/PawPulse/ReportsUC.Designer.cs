namespace PawPulse
{
    partial class ReportsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.paneltolatanm = new System.Windows.Forms.Panel();
            this.labeltotnum = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lbltotalanimal = new System.Windows.Forms.Label();
            this.panelmonth = new System.Windows.Forms.Panel();
            this.labelmonthnum = new System.Windows.Forms.Label();
            this.lblmonthlyrev = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelpend = new System.Windows.Forms.Panel();
            this.lblpennum = new System.Windows.Forms.Label();
            this.lblpend = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLow = new System.Windows.Forms.Panel();
            this.lbllownum = new System.Windows.Forms.Label();
            this.lbllow = new System.Windows.Forms.Label();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelpiegraph = new System.Windows.Forms.Panel();
            this.chartpie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblspec = new System.Windows.Forms.Label();
            this.panelcolgraph = new System.Windows.Forms.Panel();
            this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
            this.chartcol = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblrevtrend = new System.Windows.Forms.Label();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbRtype = new System.Windows.Forms.ComboBox();
            this.lblRtype = new System.Windows.Forms.Label();
            this.dtpReportMonth = new System.Windows.Forms.DateTimePicker();
            this.lblperiod = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.paneltolatanm.SuspendLayout();
            this.panelmonth.SuspendLayout();
            this.panelpend.SuspendLayout();
            this.panelLow.SuspendLayout();
            this.panelpiegraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartpie)).BeginInit();
            this.panelcolgraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartcol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 75);
            this.panel1.TabIndex = 62;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDate.Location = new System.Drawing.Point(671, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(106, 31);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "--/--/----";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblWelcome.Location = new System.Drawing.Point(29, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(118, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Reports";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(701, 533);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(156, 34);
            this.btnExcel.TabIndex = 69;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // paneltolatanm
            // 
            this.paneltolatanm.BackColor = System.Drawing.Color.White;
            this.paneltolatanm.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paneltolatanm.Controls.Add(this.labeltotnum);
            this.paneltolatanm.Controls.Add(this.flowLayoutPanel1);
            this.paneltolatanm.Controls.Add(this.lbltotalanimal);
            this.paneltolatanm.Location = new System.Drawing.Point(19, 190);
            this.paneltolatanm.Name = "paneltolatanm";
            this.paneltolatanm.Size = new System.Drawing.Size(200, 107);
            this.paneltolatanm.TabIndex = 2;
            // 
            // labeltotnum
            // 
            this.labeltotnum.AutoSize = true;
            this.labeltotnum.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltotnum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.labeltotnum.Location = new System.Drawing.Point(21, 51);
            this.labeltotnum.Name = "labeltotnum";
            this.labeltotnum.Size = new System.Drawing.Size(56, 32);
            this.labeltotnum.TabIndex = 72;
            this.labeltotnum.Text = "###";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lbltotalanimal
            // 
            this.lbltotalanimal.AutoSize = true;
            this.lbltotalanimal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalanimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.lbltotalanimal.Location = new System.Drawing.Point(43, 17);
            this.lbltotalanimal.Name = "lbltotalanimal";
            this.lbltotalanimal.Size = new System.Drawing.Size(116, 23);
            this.lbltotalanimal.TabIndex = 71;
            this.lbltotalanimal.Text = " Total Animals";
            // 
            // panelmonth
            // 
            this.panelmonth.BackColor = System.Drawing.Color.White;
            this.panelmonth.Controls.Add(this.labelmonthnum);
            this.panelmonth.Controls.Add(this.lblmonthlyrev);
            this.panelmonth.Controls.Add(this.flowLayoutPanel2);
            this.panelmonth.Location = new System.Drawing.Point(248, 190);
            this.panelmonth.Name = "panelmonth";
            this.panelmonth.Size = new System.Drawing.Size(200, 107);
            this.panelmonth.TabIndex = 3;
            // 
            // labelmonthnum
            // 
            this.labelmonthnum.AutoSize = true;
            this.labelmonthnum.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmonthnum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.labelmonthnum.Location = new System.Drawing.Point(15, 51);
            this.labelmonthnum.Name = "labelmonthnum";
            this.labelmonthnum.Size = new System.Drawing.Size(56, 32);
            this.labelmonthnum.TabIndex = 73;
            this.labelmonthnum.Text = "###";
            // 
            // lblmonthlyrev
            // 
            this.lblmonthlyrev.AutoSize = true;
            this.lblmonthlyrev.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmonthlyrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.lblmonthlyrev.Location = new System.Drawing.Point(14, 17);
            this.lblmonthlyrev.Name = "lblmonthlyrev";
            this.lblmonthlyrev.Size = new System.Drawing.Size(176, 23);
            this.lblmonthlyrev.TabIndex = 72;
            this.lblmonthlyrev.Text = "💰 Monthly Revenue";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panelpend
            // 
            this.panelpend.BackColor = System.Drawing.Color.White;
            this.panelpend.Controls.Add(this.lblpennum);
            this.panelpend.Controls.Add(this.lblpend);
            this.panelpend.Controls.Add(this.flowLayoutPanel3);
            this.panelpend.Location = new System.Drawing.Point(488, 190);
            this.panelpend.Name = "panelpend";
            this.panelpend.Size = new System.Drawing.Size(200, 107);
            this.panelpend.TabIndex = 3;
            // 
            // lblpennum
            // 
            this.lblpennum.AutoSize = true;
            this.lblpennum.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpennum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lblpennum.Location = new System.Drawing.Point(16, 51);
            this.lblpennum.Name = "lblpennum";
            this.lblpennum.Size = new System.Drawing.Size(56, 32);
            this.lblpennum.TabIndex = 74;
            this.lblpennum.Text = "###";
            // 
            // lblpend
            // 
            this.lblpend.AutoSize = true;
            this.lblpend.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.lblpend.Location = new System.Drawing.Point(13, 17);
            this.lblpend.Name = "lblpend";
            this.lblpend.Size = new System.Drawing.Size(184, 23);
            this.lblpend.TabIndex = 73;
            this.lblpend.Text = "📝 Pending Adoptions";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // panelLow
            // 
            this.panelLow.BackColor = System.Drawing.Color.White;
            this.panelLow.Controls.Add(this.lbllownum);
            this.panelLow.Controls.Add(this.lbllow);
            this.panelLow.Controls.Add(this.flowLayoutPanel4);
            this.panelLow.Location = new System.Drawing.Point(708, 190);
            this.panelLow.Name = "panelLow";
            this.panelLow.Size = new System.Drawing.Size(200, 107);
            this.panelLow.TabIndex = 3;
            // 
            // lbllownum
            // 
            this.lbllownum.AutoSize = true;
            this.lbllownum.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllownum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lbllownum.Location = new System.Drawing.Point(12, 51);
            this.lbllownum.Name = "lbllownum";
            this.lbllownum.Size = new System.Drawing.Size(56, 32);
            this.lbllownum.TabIndex = 75;
            this.lbllownum.Text = "###";
            // 
            // lbllow
            // 
            this.lbllow.AutoSize = true;
            this.lbllow.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(140)))));
            this.lbllow.Location = new System.Drawing.Point(14, 17);
            this.lbllow.Name = "lbllow";
            this.lbllow.Size = new System.Drawing.Size(164, 23);
            this.lbllow.TabIndex = 74;
            this.lbllow.Text = "⚠️ Low Stock Meds";
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel4.TabIndex = 0;
            // 
            // panelpiegraph
            // 
            this.panelpiegraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panelpiegraph.Controls.Add(this.chartpie);
            this.panelpiegraph.Controls.Add(this.flowLayoutPanel5);
            this.panelpiegraph.Controls.Add(this.lblspec);
            this.panelpiegraph.Location = new System.Drawing.Point(19, 319);
            this.panelpiegraph.Name = "panelpiegraph";
            this.panelpiegraph.Size = new System.Drawing.Size(429, 199);
            this.panelpiegraph.TabIndex = 72;
            // 
            // chartpie
            // 
            this.chartpie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.chartpie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartpie.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BorderColor = System.Drawing.Color.Bisque;
            chartArea1.Name = "ChartArea1";
            this.chartpie.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartpie.Legends.Add(legend1);
            this.chartpie.Location = new System.Drawing.Point(-1, 39);
            this.chartpie.Name = "chartpie";
            this.chartpie.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartpie.Series.Add(series1);
            this.chartpie.Size = new System.Drawing.Size(427, 163);
            this.chartpie.TabIndex = 75;
            this.chartpie.Text = "chart3";
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // lblspec
            // 
            this.lblspec.AutoSize = true;
            this.lblspec.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblspec.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblspec.Location = new System.Drawing.Point(109, 10);
            this.lblspec.Name = "lblspec";
            this.lblspec.Size = new System.Drawing.Size(189, 23);
            this.lblspec.TabIndex = 71;
            this.lblspec.Text = "🔵 Species Distribution";
            // 
            // panelcolgraph
            // 
            this.panelcolgraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panelcolgraph.Controls.Add(this.flowLayoutPanel6);
            this.panelcolgraph.Controls.Add(this.chartcol);
            this.panelcolgraph.Controls.Add(this.lblrevtrend);
            this.panelcolgraph.Location = new System.Drawing.Point(488, 319);
            this.panelcolgraph.Name = "panelcolgraph";
            this.panelcolgraph.Size = new System.Drawing.Size(420, 199);
            this.panelcolgraph.TabIndex = 73;
            // 
            // flowLayoutPanel6
            // 
            this.flowLayoutPanel6.Location = new System.Drawing.Point(0, 25);
            this.flowLayoutPanel6.Name = "flowLayoutPanel6";
            this.flowLayoutPanel6.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel6.TabIndex = 0;
            // 
            // chartcol
            // 
            this.chartcol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.chartcol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chartcol.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea1";
            this.chartcol.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartcol.Legends.Add(legend2);
            this.chartcol.Location = new System.Drawing.Point(0, 36);
            this.chartcol.Name = "chartcol";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartcol.Series.Add(series2);
            this.chartcol.Size = new System.Drawing.Size(420, 163);
            this.chartcol.TabIndex = 74;
            this.chartcol.Text = "chart1";
            // 
            // lblrevtrend
            // 
            this.lblrevtrend.AutoSize = true;
            this.lblrevtrend.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrevtrend.ForeColor = System.Drawing.SystemColors.Menu;
            this.lblrevtrend.Location = new System.Drawing.Point(135, 10);
            this.lblrevtrend.Name = "lblrevtrend";
            this.lblrevtrend.Size = new System.Drawing.Size(154, 23);
            this.lblrevtrend.TabIndex = 71;
            this.lblrevtrend.Text = "📈 Revenue Trend";
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart2.Legends.Add(legend3);
            this.chart2.Location = new System.Drawing.Point(218, 229);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(8, 8);
            this.chart2.TabIndex = 75;
            this.chart2.Text = "chart2";
            // 
            // cmbRtype
            // 
            this.cmbRtype.FormattingEnabled = true;
            this.cmbRtype.Location = new System.Drawing.Point(157, 123);
            this.cmbRtype.Name = "cmbRtype";
            this.cmbRtype.Size = new System.Drawing.Size(222, 24);
            this.cmbRtype.TabIndex = 76;
            this.cmbRtype.SelectedIndexChanged += new System.EventHandler(this.cmbRtype_SelectedIndexChanged);
            // 
            // lblRtype
            // 
            this.lblRtype.AutoSize = true;
            this.lblRtype.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRtype.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lblRtype.Location = new System.Drawing.Point(32, 123);
            this.lblRtype.Name = "lblRtype";
            this.lblRtype.Size = new System.Drawing.Size(107, 23);
            this.lblRtype.TabIndex = 73;
            this.lblRtype.Text = "Report Type:";
            // 
            // dtpReportMonth
            // 
            this.dtpReportMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportMonth.Location = new System.Drawing.Point(598, 125);
            this.dtpReportMonth.Name = "dtpReportMonth";
            this.dtpReportMonth.Size = new System.Drawing.Size(288, 22);
            this.dtpReportMonth.TabIndex = 77;
            this.dtpReportMonth.ValueChanged += new System.EventHandler(this.dtpReportMonth_ValueChanged);
            // 
            // lblperiod
            // 
            this.lblperiod.AutoSize = true;
            this.lblperiod.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblperiod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.lblperiod.Location = new System.Drawing.Point(507, 125);
            this.lblperiod.Name = "lblperiod";
            this.lblperiod.Size = new System.Drawing.Size(53, 23);
            this.lblperiod.TabIndex = 78;
            this.lblperiod.Text = "Date:";
            // 
            // ReportsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.lblperiod);
            this.Controls.Add(this.dtpReportMonth);
            this.Controls.Add(this.lblRtype);
            this.Controls.Add(this.cmbRtype);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.panelcolgraph);
            this.Controls.Add(this.panelpiegraph);
            this.Controls.Add(this.panelLow);
            this.Controls.Add(this.panelpend);
            this.Controls.Add(this.panelmonth);
            this.Controls.Add(this.paneltolatanm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExcel);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "ReportsUC";
            this.Size = new System.Drawing.Size(932, 606);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.paneltolatanm.ResumeLayout(false);
            this.paneltolatanm.PerformLayout();
            this.panelmonth.ResumeLayout(false);
            this.panelmonth.PerformLayout();
            this.panelpend.ResumeLayout(false);
            this.panelpend.PerformLayout();
            this.panelLow.ResumeLayout(false);
            this.panelLow.PerformLayout();
            this.panelpiegraph.ResumeLayout(false);
            this.panelpiegraph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartpie)).EndInit();
            this.panelcolgraph.ResumeLayout(false);
            this.panelcolgraph.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartcol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel paneltolatanm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lbltotalanimal;
        private System.Windows.Forms.Panel panelmonth;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panelpend;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Panel panelLow;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label lblmonthlyrev;
        private System.Windows.Forms.Label lblpend;
        private System.Windows.Forms.Label lbllow;
        private System.Windows.Forms.Panel panelpiegraph;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.Label lblspec;
        private System.Windows.Forms.Panel panelcolgraph;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;
        private System.Windows.Forms.Label lblrevtrend;
        private System.Windows.Forms.Label labeltotnum;
        private System.Windows.Forms.Label labelmonthnum;
        private System.Windows.Forms.Label lblpennum;
        private System.Windows.Forms.Label lbllownum;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartcol;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartpie;
        private System.Windows.Forms.ComboBox cmbRtype;
        private System.Windows.Forms.Label lblRtype;
        private System.Windows.Forms.DateTimePicker dtpReportMonth;
        private System.Windows.Forms.Label lblperiod;
    }
}
