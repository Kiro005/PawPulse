using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class HealthClearanceUC : UserControl
    {
        private Controller _ctrl;
        private DataGridView dgv;

        public HealthClearanceUC()
        {
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
            lblTitle.Text = "Health Clearance for Adoption";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);

            topBar.Controls.Add(lblTitle);

            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            StyleGrid(dgv);

            var actionPanel = new Panel();
            actionPanel.BackColor = Color.White;
            actionPanel.Dock = DockStyle.Bottom;
            actionPanel.Height = 60;

            var btnClear = new Button();
            btnClear.Text = "✓  Issue Health Clearance";
            btnClear.Size = new Size(210, 36);
            btnClear.Location = new Point(20, 12);
            btnClear.BackColor = Color.FromArgb(113, 196, 175);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;

            var lblHint = new Label();
            lblHint.Text = "Select a shelter animal to issue a health clearance certificate for adoption.";
            lblHint.Font = new Font("Segoe UI", 9f);
            lblHint.ForeColor = Color.FromArgb(140, 140, 160);
            lblHint.AutoSize = true;
            lblHint.Location = new Point(245, 22);

            actionPanel.Controls.Add(btnClear);
            actionPanel.Controls.Add(lblHint);

            var btnRefresh = new Button();
            btnRefresh.Text = "↻  Refresh";
            btnRefresh.Size = new Size(100, 36);
            btnRefresh.Location = new Point(700, 12);
            btnRefresh.BackColor = Color.FromArgb(31, 38, 62);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += (s, e) => LoadData();
            actionPanel.Controls.Add(btnRefresh);

            var contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(20, 10, 20, 0);
            contentPanel.Controls.Add(dgv);

            this.Controls.Add(contentPanel);
            this.Controls.Add(actionPanel);
            this.Controls.Add(topBar);
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
                var dt = _ctrl.GetShelterAnimalsForClearance();
                dgv.DataSource = dt;
                if (dgv.Columns.Contains("AnimalID")) dgv.Columns["AnimalID"].Visible = false;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    string diag = row.Cells["LatestDiagnosis"]?.Value?.ToString() ?? "";
                    if (diag == "Cleared for Adoption")
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(34, 139, 34);
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                    else if (diag == "No Record")
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 120, 0);
                    }
                }
            }
            catch { }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) { MessageBox.Show("Please select an animal.", "PawPulse"); return; }
            int animalId = Convert.ToInt32(dgv.SelectedRows[0].Cells["AnimalID"].Value);
            string animalName = dgv.SelectedRows[0].Cells["AnimalName"]?.Value?.ToString() ?? "";
            string current = dgv.SelectedRows[0].Cells["LatestDiagnosis"]?.Value?.ToString() ?? "";
            if (current == "Cleared for Adoption") { MessageBox.Show($"{animalName} is already cleared for adoption.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show($"Issue health clearance for {animalName}?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool ok = _ctrl.IssueClearance(animalId);
                if (ok) { MessageBox.Show($"Health clearance issued for {animalName}.", "PawPulse"); LoadData(); }
                else MessageBox.Show("Failed to issue clearance.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HealthClearanceUC_Load(object sender, EventArgs e)
        {

        }
    }
}
