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
        private bool _editMode = false;
        private int _editingPrescriptionId = 0;

        public PrescriptionsUC(int vetId)
        {
            _vetId = vetId;
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgv2);
            btnAdd.Click += (s, e) => { _editMode = false; _editingPrescriptionId = 0; addForm2.Visible = true; addForm2.BringToFront(); };
            btnSave.Click += BtnSave_Click;
            btnCancelAdd.Click += (s, e) => { addForm2.Visible = false; _editMode = false; _editingPrescriptionId = 0; };
            button1.Click += BtnUpdate_Click;
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
                var dt = _ctrl.GetPrescriptions(_vetId);
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("PrescriptionID")) dgv2.Columns["PrescriptionID"].Visible = false;
                if (dgv2.Columns.Contains("RecordID")) dgv2.Columns["RecordID"].Visible = false;
                if (dgv2.Columns.Contains("MedicineID")) dgv2.Columns["MedicineID"].Visible = false;

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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Select a prescription to update.", "PawPulse"); return; }
            _editMode = true;
            _editingPrescriptionId = Convert.ToInt32(dgv2.SelectedRows[0].Cells["PrescriptionID"].Value);
            txtInstructions2.Text = dgv2.SelectedRows[0].Cells["Instructions"].Value?.ToString() ?? "";
            txtRefills2.Text = dgv2.SelectedRows[0].Cells["Refills"].Value?.ToString() ?? "";
            txtDuration2.Text = dgv2.SelectedRows[0].Cells["Duration"].Value?.ToString() ?? "";
            cmbRecord2.SelectedValue = Convert.ToInt32(dgv2.SelectedRows[0].Cells["RecordID"].Value);
            cmbMedicine2.SelectedValue = Convert.ToInt32(dgv2.SelectedRows[0].Cells["MedicineID"].Value);
            addForm2.Visible = true;
            addForm2.BringToFront();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Select a prescription to delete.", "PawPulse"); return; }
            if (MessageBox.Show("Delete this prescription?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            int id = Convert.ToInt32(dgv2.SelectedRows[0].Cells["PrescriptionID"].Value);
            bool ok = _ctrl.DeletePrescription(id);
            if (ok) { MessageBox.Show("Prescription deleted.", "PawPulse"); LoadData(); }
            else MessageBox.Show("Failed to delete.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbRecord2.SelectedItem == null || cmbMedicine2.SelectedItem == null || string.IsNullOrWhiteSpace(txtInstructions2.Text)) { MessageBox.Show("Please fill all required fields.", "PawPulse"); return; }
            int recordId = Convert.ToInt32(cmbRecord2.SelectedValue);
            int medicineId = Convert.ToInt32(cmbMedicine2.SelectedValue);
            int refills = 0; int.TryParse(txtRefills2.Text, out refills);
            int duration = 0; int.TryParse(txtDuration2.Text, out duration);

            bool paidInCash = false;
            bool isClientAnimal = false;

            if (!_editMode)
            {
                int? clientId = _ctrl.GetClientIdFromRecord(recordId);
                if (clientId.HasValue)
                {
                    isClientAnimal = true;
                    paidInCash = MessageBox.Show("Did the client pay in cash?", "Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                }
            }

            bool ok;
            if (_editMode)
                ok = _ctrl.UpdatePrescription(_editingPrescriptionId, recordId, medicineId, txtInstructions2.Text.Trim(), refills, duration);
            else
                ok = _ctrl.AddPrescription(recordId, medicineId, _vetId, txtInstructions2.Text.Trim(), refills, duration, paidInCash);

            if (ok)
            {
                string msg = _editMode ? "Prescription updated." : "Prescription added.";
                if (!_editMode)
                    msg += isClientAnimal ? (paidInCash ? "\nMarked as Paid." : "\nAdded to client's bill as Unpaid.") : "\nShelter animal — not billed.";
                MessageBox.Show(msg, "PawPulse");
                _editMode = false; _editingPrescriptionId = 0;
                addForm2.Visible = false;
                txtInstructions2.Clear(); txtRefills2.Clear(); txtDuration2.Clear();
                LoadData();
            }
            else MessageBox.Show("Operation failed.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
