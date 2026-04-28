using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class AppointmentsUC : UserControl
    {
        private int _vetId;
        private Controller _ctrl;
        private DataTable _allData;

        public AppointmentsUC(int vetId)
        {
            _vetId = vetId;
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgv2);
            btnFilterAll2.Click += (s, e) => ApplyFilter("All");
            btnFilterScheduled2.Click += (s, e) => ApplyFilter("Scheduled");
            btnFilterCompleted2.Click += (s, e) => ApplyFilter("Completed");
            btnFilterCancelled2.Click += (s, e) => ApplyFilter("Cancelled");
            button1.Click += BtnApprove_Click;
            btnCancel2.Click += BtnCancel_Click;
            LoadData();
        }

        private void StyleGrid(DataGridView g)
        {
            g.BackgroundColor = Color.White; g.BorderStyle = BorderStyle.None; g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false; g.ReadOnly = true; g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect; g.MultiSelect = false;
            g.Font = new Font("Segoe UI", 9.5f); g.RowTemplate.Height = 36;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; g.GridColor = Color.FromArgb(230, 230, 235);
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 38, 62); g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold); g.ColumnHeadersHeight = 40;
            g.EnableHeadersVisualStyles = false; g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(113, 196, 175);
            g.DefaultCellStyle.SelectionForeColor = Color.White; g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 252);
        }

        private void LoadData()
        {
            try
            {
                _allData = _ctrl.GetVetAppointments(_vetId);
                BindGrid(_allData);
            }
            catch { }
        }

        private void BindGrid(DataTable dt)
        {
            dgv2.DataSource = null;
            if (dt == null) return;
            dgv2.DataSource = dt;
            if (dgv2.Columns.Contains("AppointmentID"))
                dgv2.Columns["AppointmentID"].Visible = false;
            ColorStatusCells();
        }

        private void ColorStatusCells()
        {
            if (!dgv2.Columns.Contains("Status")) return;
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString() ?? "";
                var cell = row.Cells["Status"];
                if (status == "Completed") { cell.Style.ForeColor = Color.FromArgb(34, 139, 34); cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold); }
                else if (status == "Cancelled") { cell.Style.ForeColor = Color.FromArgb(200, 50, 50); cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold); }
                else if (status == "Scheduled") { cell.Style.ForeColor = Color.FromArgb(30, 100, 200); cell.Style.Font = new Font("Segoe UI", 9f, FontStyle.Bold); }
            }
        }

        private void ApplyFilter(string filter)
        {
            Button[] filters = { btnFilterAll2, btnFilterScheduled2, btnFilterCompleted2, btnFilterCancelled2 };
            foreach (var b in filters) { b.BackColor = Color.FromArgb(31, 38, 62); b.ForeColor = Color.White; }
            Button active = filter == "All" ? btnFilterAll2 : filter == "Scheduled" ? btnFilterScheduled2 : filter == "Completed" ? btnFilterCompleted2 : btnFilterCancelled2;
            active.BackColor = Color.FromArgb(113, 196, 175);

            if (_allData == null) return;
            if (filter == "All") { BindGrid(_allData); return; }
            DataView dv = new DataView(_allData);
            dv.RowFilter = $"Status = '{filter}'";
            dgv2.DataSource = dv;
            if (dgv2.Columns.Contains("AppointmentID")) dgv2.Columns["AppointmentID"].Visible = false;
            ColorStatusCells();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgv2.SelectedRows[0].Cells["AppointmentID"].Value);
            string status = dgv2.SelectedRows[0].Cells["Status"].Value?.ToString();
            if (status != "Scheduled") { MessageBox.Show("Only Scheduled appointments can be approved.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            _ctrl.UpdateAppointmentStatus(id, "Completed");
            LoadData();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgv2.SelectedRows[0].Cells["AppointmentID"].Value);
            string status = dgv2.SelectedRows[0].Cells["Status"].Value?.ToString();
            if (status == "Completed") { MessageBox.Show("Cannot cancel a completed appointment.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Cancel this appointment?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ctrl.UpdateAppointmentStatus(id, "Cancelled");
                LoadData();
            }
        }

        private void btnFilterCancelled2_Click(object sender, EventArgs e) { }
    }
}
