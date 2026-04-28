using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class VetDashboardUC : UserControl
    {
        private int _vetId;
        private string _vetName;
        private Controller _ctrl;

        public VetDashboardUC(int vetId, string vetName)
        {
            _vetId = vetId;
            _vetName = vetName;
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgvRecent2);
            string displayName = _vetName.StartsWith("Dr.") || _vetName.StartsWith("dr.") ? _vetName : "Dr. " + _vetName;
            lblWelcome.Text = "Welcome back, " + displayName;
            lblDate.Text = DateTime.Today.ToString("dddd, MMMM d yyyy");
            icon1.Image = sidebarPanel2.LoadIcon("appointment.png", 45);
            icon2.Image = sidebarPanel2.LoadIcon("stethoscope.png", 45);
            icon3.Image = sidebarPanel2.LoadIcon("paw.png", 45);
            LoadStats();
        }

        private void StyleGrid(DataGridView g)
        {
            g.BackgroundColor = Color.White; g.BorderStyle = BorderStyle.None; g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false; g.ReadOnly = true; g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect; g.MultiSelect = false;
            g.Font = new Font("Segoe UI", 9.5f); g.RowTemplate.Height = 34;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; g.GridColor = Color.FromArgb(230, 230, 235);
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 38, 62); g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold); g.ColumnHeadersHeight = 38;
            g.EnableHeadersVisualStyles = false; g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(113, 196, 175);
            g.DefaultCellStyle.SelectionForeColor = Color.White; g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 252);
        }

        private void LoadStats()
        {
            try
            {
                label1.Text = _ctrl.GetTodayAppointmentsCount(_vetId).ToString();
                lblScheduledVal2.Text = _ctrl.GetScheduledAppointmentsCount(_vetId).ToString();
                lblPatientsVal2.Text = _ctrl.GetTotalPatientsCount(_vetId).ToString();

                var dt = _ctrl.GetVetAppointments(_vetId);
                if (dt != null)
                {
                    var recent = dt.Clone();
                    int count = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (count >= 5) break;
                        recent.ImportRow(row);
                        count++;
                    }
                    dgvRecent2.DataSource = recent;
                    if (dgvRecent2.Columns.Contains("AppointmentID")) dgvRecent2.Columns["AppointmentID"].Visible = false;

                    foreach (DataGridViewRow row in dgvRecent2.Rows)
                    {
                        string status = row.Cells["Status"]?.Value?.ToString() ?? "";
                        if (status == "Completed") row.DefaultCellStyle.ForeColor = Color.FromArgb(34, 139, 34);
                        else if (status == "Cancelled") row.DefaultCellStyle.ForeColor = Color.FromArgb(200, 60, 60);
                        else if (status == "Scheduled") row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 100, 200);
                    }
                }
            }
            catch { }
        }

        private void lblCard1Title_Click(object sender, EventArgs e) { }

        private void dgvRecent2_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
