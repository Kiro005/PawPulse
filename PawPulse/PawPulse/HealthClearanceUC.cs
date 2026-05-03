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

        public HealthClearanceUC()
        {
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgv2);
            btnClear2.Click += BtnClear_Click;
            btnRefresh.Click += (s, e) => LoadData();
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
                var dt = _ctrl.GetShelterAnimals();
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("AnimalID")) dgv2.Columns["AnimalID"].Visible = false;

                foreach (DataGridViewRow row in dgv2.Rows)
                {
                    string diag = row.Cells["LatestDiagnosis"]?.Value?.ToString() ?? "";
                    if (diag == "Cleared for Adoption")
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(34, 139, 34);
                        row.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                    }
                    else if (diag == "No Record")
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(180, 120, 0);
                }
            }
            catch { }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Please select an animal.", "PawPulse"); return; }
            int animalId = Convert.ToInt32(dgv2.SelectedRows[0].Cells["AnimalID"].Value);
            string animalName = dgv2.SelectedRows[0].Cells["AnimalName"]?.Value?.ToString() ?? "";
            string current = dgv2.SelectedRows[0].Cells["LatestDiagnosis"]?.Value?.ToString() ?? "";
            if (current == "Cleared for Adoption") { MessageBox.Show($"{animalName} is already cleared for adoption.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            if (MessageBox.Show($"Issue health clearance for {animalName}?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bool ok = _ctrl.IssueClearance(animalId);
                if (ok) { MessageBox.Show($"Health clearance issued for {animalName}.", "PawPulse"); LoadData(); }
                else MessageBox.Show("Failed to issue clearance.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HealthClearanceUC_Load(object sender, EventArgs e) { }
    }
}
