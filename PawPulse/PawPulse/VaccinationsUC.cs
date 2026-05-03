using System;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class VaccinationsUC : UserControl
    {
        private Controller _ctrl;

        public VaccinationsUC()
        {
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgv2);
            btnAdd.Click += (s, e) => { addForm2.Visible = true; addForm2.BringToFront(); };
            btnSave.Click += BtnSave_Click;
            btnCancelAdd.Click += (s, e) => addForm2.Visible = false;
            button2.Click += BtnDelete_Click;
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
                var dt = _ctrl.GetVaccinations();
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("AnimalID")) dgv2.Columns["AnimalID"].Visible = false;
                if (dgv2.Columns.Contains("VaccineID")) dgv2.Columns["VaccineID"].Visible = false;

                var animals = _ctrl.GetAllAnimals();
                cmbAnimal2.DataSource = animals;
                cmbAnimal2.DisplayMember = "Display";
                cmbAnimal2.ValueMember = "AnimalID";

                var vaccines = _ctrl.GetVaccines();
                cmbVaccine2.DataSource = vaccines;
                cmbVaccine2.DisplayMember = "Display";
                cmbVaccine2.ValueMember = "VaccineID";
            }
            catch { }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Select a vaccination record to delete.", "PawPulse"); return; }
            if (MessageBox.Show("Delete this vaccination record?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            int animalId = Convert.ToInt32(dgv2.SelectedRows[0].Cells["AnimalID"].Value);
            int vaccineId = Convert.ToInt32(dgv2.SelectedRows[0].Cells["VaccineID"].Value);
            string date = Convert.ToDateTime(dgv2.SelectedRows[0].Cells["Date"].Value).ToString("yyyy-MM-dd");
            bool ok = _ctrl.DeleteVaccination(animalId, vaccineId, date);
            if (ok) { MessageBox.Show("Vaccination record deleted.", "PawPulse"); LoadData(); }
            else MessageBox.Show("Failed to delete.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbAnimal2.SelectedItem == null || cmbVaccine2.SelectedItem == null) { MessageBox.Show("Please select animal and vaccine.", "PawPulse"); return; }
            int animalId = Convert.ToInt32(cmbAnimal2.SelectedValue);
            int vaccineId = Convert.ToInt32(cmbVaccine2.SelectedValue);
            bool ok = _ctrl.AddVaccination(animalId, vaccineId, dtpDate2.Value);
            if (ok) { MessageBox.Show("Vaccination recorded.", "PawPulse"); addForm2.Visible = false; LoadData(); }
            else MessageBox.Show("Failed to record vaccination. It may already exist.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void VaccinationsUC_Load(object sender, EventArgs e) { }
    }
}
