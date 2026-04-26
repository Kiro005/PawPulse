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
        private DataGridView dgv;
        private DataTable _allData;
        private Button btnFilterAll;
        private Button btnFilterScheduled;
        private Button btnFilterCompleted;
        private Button btnFilterCancelled;

        public AppointmentsUC(int vetId)
        {
            _vetId = vetId;
            _ctrl = new Controller();
            InitializeComponent();
            BuildUI();
            LoadData();
        }

        private void BuildUI()
        {
            this.BackColor = Color.FromArgb(245, 246, 250);

            var topBar = new Panel();
            topBar.BackColor = Color.FromArgb(31, 38, 62);
            topBar.Dock = DockStyle.Top;
            topBar.Height = 60;

            var lblTitle = new Label();
            lblTitle.Text = "My Appointments";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);

            btnFilterAll = MakeFilterButton("All", new Point(230, 15), true);
            btnFilterScheduled = MakeFilterButton("Scheduled", new Point(295, 15), false);
            btnFilterCompleted = MakeFilterButton("Completed", new Point(393, 15), false);
            btnFilterCancelled = MakeFilterButton("Cancelled", new Point(491, 15), false);

            btnFilterAll.Click += (s, e) => ApplyFilter("All");
            btnFilterScheduled.Click += (s, e) => ApplyFilter("Scheduled");
            btnFilterCompleted.Click += (s, e) => ApplyFilter("Completed");
            btnFilterCancelled.Click += (s, e) => ApplyFilter("Cancelled");

            topBar.Controls.Add(lblTitle);
            topBar.Controls.Add(btnFilterAll);
            topBar.Controls.Add(btnFilterScheduled);
            topBar.Controls.Add(btnFilterCompleted);
            topBar.Controls.Add(btnFilterCancelled);

            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            StyleGrid(dgv);

            var actionPanel = new Panel();
            actionPanel.BackColor = Color.FromArgb(245, 246, 250);
            actionPanel.Dock = DockStyle.Bottom;
            actionPanel.Height = 55;

            var btnApprove = MakeActionButton("✓  Approve", Color.FromArgb(113, 196, 175), new Point(20, 10));
            var btnCancel = MakeActionButton("✕  Cancel", Color.FromArgb(200, 60, 60), new Point(165, 10));
            var lblHint = new Label();
            lblHint.Text = "Select a Scheduled appointment to approve or cancel.";
            lblHint.Font = new Font("Segoe UI", 9f);
            lblHint.ForeColor = Color.FromArgb(140, 140, 160);
            lblHint.AutoSize = true;
            lblHint.Location = new Point(315, 20);

            btnApprove.Click += BtnApprove_Click;
            btnCancel.Click += BtnCancel_Click;

            actionPanel.Controls.Add(btnApprove);
            actionPanel.Controls.Add(btnCancel);
            actionPanel.Controls.Add(lblHint);

            var contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(20, 10, 20, 0);
            contentPanel.Controls.Add(dgv);

            this.Controls.Add(contentPanel);
            this.Controls.Add(actionPanel);
            this.Controls.Add(topBar);
        }

        private Button MakeFilterButton(string text, Point loc, bool active)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Location = loc;
            btn.AutoSize = true;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(113, 196, 175);
            btn.FlatAppearance.BorderSize = 1;
            btn.BackColor = active ? Color.FromArgb(113, 196, 175) : Color.FromArgb(31, 38, 62);
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9f);
            btn.Padding = new Padding(8, 3, 8, 3);
            btn.UseVisualStyleBackColor = false;
            return btn;
        }

        private Button MakeActionButton(string text, Color color, Point loc)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Location = loc;
            btn.Size = new Size(130, 34);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btn.UseVisualStyleBackColor = false;
            return btn;
        }

        private void StyleGrid(DataGridView g)
        {
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.ReadOnly = true;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.Font = new Font("Segoe UI", 9.5f);
            g.RowTemplate.Height = 36;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(230, 230, 235);
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 38, 62);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            g.ColumnHeadersHeight = 40;
            g.EnableHeadersVisualStyles = false;
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(113, 196, 175);
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 252);
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
            dgv.DataSource = null;
            if (dt == null) return;
            dgv.DataSource = dt;
            if (dgv.Columns.Contains("AppointmentID"))
                dgv.Columns["AppointmentID"].Visible = false;
            ColorStatusCells();
        }

        private void ColorStatusCells()
        {
            if (!dgv.Columns.Contains("Status")) return;
            foreach (DataGridViewRow row in dgv.Rows)
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
            Button[] filters = { btnFilterAll, btnFilterScheduled, btnFilterCompleted, btnFilterCancelled };
            foreach (var b in filters) { b.BackColor = Color.FromArgb(31, 38, 62); b.ForeColor = Color.White; }
            Button active = filter == "All" ? btnFilterAll : filter == "Scheduled" ? btnFilterScheduled : filter == "Completed" ? btnFilterCompleted : btnFilterCancelled;
            active.BackColor = Color.FromArgb(113, 196, 175);

            if (_allData == null) return;
            if (filter == "All") { BindGrid(_allData); return; }
            DataView dv = new DataView(_allData);
            dv.RowFilter = $"Status = '{filter}'";
            dgv.DataSource = dv;
            if (dgv.Columns.Contains("AppointmentID")) dgv.Columns["AppointmentID"].Visible = false;
            ColorStatusCells();
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["AppointmentID"].Value);
            string status = dgv.SelectedRows[0].Cells["Status"].Value?.ToString();
            if (status != "Scheduled") { MessageBox.Show("Only Scheduled appointments can be approved.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            _ctrl.UpdateAppointmentStatus(id, "Completed");
            LoadData();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["AppointmentID"].Value);
            string status = dgv.SelectedRows[0].Cells["Status"].Value?.ToString();
            if (status == "Completed") { MessageBox.Show("Cannot cancel a completed appointment.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show("Cancel this appointment?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _ctrl.UpdateAppointmentStatus(id, "Cancelled");
                LoadData();
            }
        }
    }
}
