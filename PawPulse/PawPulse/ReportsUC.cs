using DBapplication;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PawPulse
{
    public partial class ReportsUC : UserControl
    {
        private Controller controllerObj;

        public ReportsUC(int userId, string fullName)
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            // Initialize database controller
            controllerObj = new Controller();
            

            // Apply UI styling and load database records
            ApplyDashboardStyle();
            SetupReportControls();
            LoadDashboardData();
            cmbRtype.SelectedIndex = 0; // Default to first report type
        }

        // Fetches analytics from the database and binds them to UI controls
        private void LoadDashboardData()
        {
            string mode = cmbRtype.SelectedItem?.ToString() ?? "Animals Report";
            int month = dtpReportMonth.Value.Month;
            int year = dtpReportMonth.Value.Year;

            if (mode == "Managerial Report")
            {
                // 1. Fetch financial data (Ensure these methods exist in your Controller)
                decimal salaries = Convert.ToDecimal(controllerObj.GetTotalSalaries());
                decimal medExpenses = Convert.ToDecimal(controllerObj.GetMedicineExpenses(month, year));
                decimal labExpenses = Convert.ToDecimal(controllerObj.GetLabExpenses(month, year));
                decimal revenue = Convert.ToDecimal(controllerObj.GetMonthlyRevenue(month, year));

                // Calculate total expenses
                decimal totalExpenses = salaries + medExpenses + labExpenses;

                // 2. Bind data to KPI numbers
                labeltotnum.Text = controllerObj.GetTotalActiveEmployees().ToString();
                labelmonthnum.Text = totalExpenses.ToString("C2"); // Displays Total Expenses
                lblpennum.Text = revenue.ToString("C2"); // Displays Revenue
                lbllownum.Text = controllerObj.GetTotalInventoryValue().ToString("C2");

                // 3. Update Pie Chart
                UpdatePieChart(controllerObj.GetEmployeeRoleDist(), "EmployeeRole", "Count");

                // 4. Update Column Chart directly with 4 distinct bars
                chartcol.Series[0].Points.Clear();
                chartcol.Series[0].Points.AddXY("Salaries", salaries);
                chartcol.Series[0].Points.AddXY("Medicine", medExpenses);
                chartcol.Series[0].Points.AddXY("Labs", labExpenses);
                chartcol.Series[0].Points.AddXY("Revenue", revenue);
            }
            else
            {
                // Existing Animal Stats logic
                labeltotnum.Text = controllerObj.GetTotalAnimals().ToString();
                labelmonthnum.Text = controllerObj.GetMonthlyRevenue(month, year).ToString("C2");
                lblpennum.Text = controllerObj.GetPendingAdoptionsCount().ToString();
                lbllownum.Text = controllerObj.GetLowStockMedicineCount().ToString();

                UpdatePieChart(controllerObj.GetSpeciesDistribution(), "Species", "SpeciesCount");
                UpdateColChart(controllerObj.GetRevenueTrend());
            }
        }

        // Helper to update the Pie Chart with any DataTable
        private void UpdatePieChart(DataTable dt, string xMember, string yMember)
        {
            if (dt == null) return;
            chartpie.Series[0].Points.Clear();
            foreach (DataRow row in dt.Rows)
            {
                chartpie.Series[0].Points.AddXY(row[xMember].ToString(), row[yMember]);
            }
        }

        // Helper to update the Column Chart with any DataTable
        private void UpdateColChart(DataTable dt)
        {
            if (dt == null) return;
            chartcol.Series[0].Points.Clear();

            // Using index 0 and 1 to be more generic for different queries
            foreach (DataRow row in dt.Rows)
            {
                chartcol.Series[0].Points.AddXY(row[0].ToString(), row[1]);
            }
        }

        // Formats panels, labels, charts, and buttons for a modern flat UI
        private void ApplyDashboardStyle()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);

            Color cardWhite = Color.White;
            Color titleGray = Color.FromArgb(100, 110, 120);
            Color blueAccent = Color.FromArgb(52, 152, 219);
            Color greenAccent = Color.FromArgb(46, 204, 113);
            Color orangeAccent = Color.FromArgb(230, 126, 34);
            Color redAccent = Color.FromArgb(231, 76, 60);
            Color navyAccent = Color.FromArgb(30, 40, 55);

            Font titleFont = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            // Reduced font size to 16F so large numbers do not clip out of panels
            Font numberFont = new Font("Segoe UI", 16F, FontStyle.Bold);
            Font chartTitleFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            // Format layout panels
            Panel[] panels = { paneltolatanm, panelmonth, panelpend, panelLow, panelpiegraph, panelcolgraph };
            foreach (Panel pnl in panels)
            {
                pnl.BackColor = cardWhite;
                pnl.BorderStyle = BorderStyle.None;
            }

            // Format standard text labels
            Label[] titles = { lbltotalanimal, lblmonthlyrev, lblpend, lbllow };
            foreach (Label lbl in titles)
            {
                lbl.Font = titleFont;
                lbl.ForeColor = titleGray;
                lbl.BackColor = Color.Transparent;
            }

            // Apply metric accent colors
            labeltotnum.Font = numberFont;
            labeltotnum.ForeColor = blueAccent;

            labelmonthnum.Font = numberFont;
            labelmonthnum.ForeColor = greenAccent;

            lblpennum.Font = numberFont;
            lblpennum.ForeColor = orangeAccent;

            lbllownum.Font = numberFont;
            lbllownum.ForeColor = redAccent;

            // Format chart headers
            lblspec.Font = chartTitleFont;
            lblspec.ForeColor = navyAccent;
            lblspec.BackColor = Color.Transparent;

            lblrevtrend.Font = chartTitleFont;
            lblrevtrend.ForeColor = navyAccent;
            lblrevtrend.BackColor = Color.Transparent;

            // Apply chart styling 
            chartpie.BackColor = cardWhite;
            chartpie.ChartAreas[0].BackColor = cardWhite;
            chartpie.ChartAreas[0].BorderColor = Color.Transparent;

            chartcol.BackColor = cardWhite;
            chartcol.ChartAreas[0].BackColor = cardWhite;
            chartcol.ChartAreas[0].BorderColor = Color.Transparent;

            chartcol.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chartcol.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chartcol.ChartAreas[0].AxisX.LineColor = Color.FromArgb(200, 200, 200);
            chartcol.ChartAreas[0].AxisY.LineColor = Color.FromArgb(200, 200, 200);

            // Configure X-axis to display labels on a single line without wrapping
            chartcol.ChartAreas[0].AxisX.Interval = 1; // Force showing all labels
            chartcol.ChartAreas[0].AxisX.LabelStyle.IsStaggered = false; // Disable multi-row layout
            chartcol.ChartAreas[0].AxisX.IsLabelAutoFit = true; // Enable smart auto-fit

            // Prevent word-wrap by strictly allowing only font size reduction to fit the labels
            chartcol.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;

            // Set text fonts
            chartcol.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            chartcol.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            chartcol.ChartAreas[0].AxisY.LabelStyle.Format = "0,K";

            // Format the Report Type ComboBox and Label
            lblRtype.Font = titleFont;
            lblRtype.ForeColor = navyAccent;
            lblRtype.BackColor = Color.Transparent;

            cmbRtype.FlatStyle = FlatStyle.Flat;
            cmbRtype.Font = new Font("Segoe UI", 10F);
            cmbRtype.BackColor = Color.White;
            cmbRtype.ForeColor = navyAccent;

            // Apply button styling
            
            FormatButton(btnExcel, redAccent);
        }

        // Initializes ComboBox items and sets default states
        private void SetupReportControls()
        {
            cmbRtype.Items.Clear();
            cmbRtype.Items.Add("Animals Report");
            cmbRtype.Items.Add("Managerial Report");
            // Removed Summary report

            // Configure DateTimePicker to show a dropdown calendar formatted to MM/yyyy
            dtpReportMonth.Format = DateTimePickerFormat.Custom;
            dtpReportMonth.CustomFormat = "MM / yyyy";
            dtpReportMonth.ShowUpDown = false;

            
            btnExcel.Enabled = false;
        }

        // Fetches data based on UI selection and date filter
        private DataTable GetReportData(string reportType)
        {
            int selectedMonth = dtpReportMonth.Value.Month;
            int selectedYear = dtpReportMonth.Value.Year;

            if (reportType == "Animals Report")
            {
                return controllerObj.GetDetailedAnimalsReport();
            }
            else if (reportType == "Managerial Report")
            {
                return controllerObj.GetManagerialReport(selectedMonth, selectedYear);
            }

            return null;
        }

        // Handles report type selection change
        private void cmbRtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMode = cmbRtype.SelectedItem.ToString();

            UpdateDashboardUI(selectedMode);
            LoadDashboardData();

            btnExcel.Enabled = true;
        }

        // Triggers data reload when the month/year is changed
        private void dtpReportMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadDashboardData();
            this.Refresh(); // Ensure UI updates immediately after data load
        }

        // Swapping label texts to match the reporting context
        private void UpdateDashboardUI(string mode)
        {
            if (mode == "Managerial Report")
            {
                lbltotalanimal.Text = "Active Employees";
                lblmonthlyrev.Text = "Total Expenses";
                lblpend.Text = "Monthly Revenue";
                lbllow.Text = "Stock Value";

                lblspec.Text = "Employee Roles Dist.";
                lblrevtrend.Text = "Financial Overview";

                labelmonthnum.Text = "EGP 0.00";
                lbllownum.Text = "EGP 0.00";
            }
            else
            {
                lbltotalanimal.Text = "Total Animals";
                lblmonthlyrev.Text = "Monthly Revenue";
                lblpend.Text = "Pending Adoption";
                lbllow.Text = "Low Stock Meds";

                lblspec.Text = "Species Distribution";
                lblrevtrend.Text = "Revenue Trend";

                labelmonthnum.Text = "$0.00";
            }
        }

        // Handles Excel export button click
        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (cmbRtype.SelectedIndex == -1) return;

            string selectedReport = cmbRtype.SelectedItem.ToString();
            ExportToCSV(selectedReport);
        }

        // Exports DataTable to a CSV format readable by Excel
        private void ExportToCSV(string reportType)
        {
            DataTable dt = GetReportData(reportType);

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No data found for the selected report.", "Empty Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.FileName = reportType.Replace(" ", "_") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                    {
                        // Write headers
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sw.Write(dt.Columns[i].ColumnName);
                            if (i < dt.Columns.Count - 1) sw.Write(",");
                        }
                        sw.WriteLine();

                        // Write rows
                        foreach (DataRow row in dt.Rows)
                        {
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                sw.Write(row[i].ToString().Replace(",", " "));
                                if (i < dt.Columns.Count - 1) sw.Write(",");
                            }
                            sw.WriteLine();
                        }
                    }
                    MessageBox.Show("Data exported successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Export failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        

        // Sets flat style properties for action buttons
        private void FormatButton(Button btn, Color bgColor)
        {
            if (btn == null) return;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bgColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}