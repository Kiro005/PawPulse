using System;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class PrescriptionsUC : UserControl
    {
        private int _vetId;
        private Controller _ctrl;

        public PrescriptionsUC(int vetId)
        {
            _vetId = vetId;
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgv2);
            btnAdd.Click += (s, e) => { addForm2.Visible = true; addForm2.BringToFront(); };
            btnSave.Click += BtnSave_Click;
            btnCancelAdd.Click += (s, e) => addForm2.Visible = false;
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
                var dt = _ctrl.GetPrescriptions(_vetId);
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("PrescriptionID")) dgv2.Columns["PrescriptionID"].Visible = false;

                var records = _ctrl.GetMedicalRecordsDropdown();
                cmbRecord2.DataSource = records;
                cmbRecord2.DisplayMember = "Display";
                cmbRecord2.ValueMember = "RecordID";

                var meds = _ctrl.GetMedicines();
                cmbMedicine2.DataSource = meds;
                cmbMedicine2.DisplayMember = "Display";
                cmbMedicine2.ValueMember = "MedicineID";
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbRecord2.SelectedItem == null || cmbMedicine2.SelectedItem == null || string.IsNullOrWhiteSpace(txtInstructions2.Text)) { MessageBox.Show("Please fill all required fields.", "PawPulse"); return; }
            int recordId = Convert.ToInt32(cmbRecord2.SelectedValue);
            int medicineId = Convert.ToInt32(cmbMedicine2.SelectedValue);
            int refills = 0; int.TryParse(txtRefills2.Text, out refills);
            int duration = 0; int.TryParse(txtDuration2.Text, out duration);
            bool ok = _ctrl.AddPrescription(recordId, medicineId, _vetId, txtInstructions2.Text.Trim(), refills, duration);
            if (ok) { MessageBox.Show("Prescription added.", "PawPulse"); addForm2.Visible = false; txtInstructions2.Clear(); txtRefills2.Clear(); txtDuration2.Clear(); LoadData(); }
            else MessageBox.Show("Failed to add prescription.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
