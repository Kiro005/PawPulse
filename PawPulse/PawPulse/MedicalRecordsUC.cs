using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class MedicalRecordsUC : UserControl
    {
        private int _vetId;
        private Controller _ctrl;
        private bool _editMode = false;
        private int _editingRecordId = 0;

        public MedicalRecordsUC(int vetId)
        {
            _vetId = vetId;
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgv2);
            btnAdd.Click += (s, e) => { _editMode = false; _editingRecordId = 0; addForm2.Visible = true; addForm2.BringToFront(); };
            btnSave.Click += BtnSave_Click;
            btnCancelAdd.Click += (s, e) => { addForm2.Visible = false; _editMode = false; _editingRecordId = 0; };
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
                var dt = _ctrl.GetMedicalRecords();
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("RecordID")) dgv2.Columns["RecordID"].Visible = false;
                if (dgv2.Columns.Contains("AnimalID")) dgv2.Columns["AnimalID"].Visible = false;
                if (dgv2.Columns.Contains("AppointmentID")) dgv2.Columns["AppointmentID"].Visible = false;

                var animals = _ctrl.GetAllAnimals();
                cmbAnimal2.DataSource = animals;
                cmbAnimal2.DisplayMember = "Display";
                cmbAnimal2.ValueMember = "AnimalID";

                var appts = _ctrl.GetVetAppointments(_vetId);
                if (appts != null)
                {
                    cmbAppointment2.Items.Clear();
                    cmbAppointment2.Items.Add(new ComboItem("None", 0));
                    foreach (DataRow r in appts.Rows)
                        cmbAppointment2.Items.Add(new ComboItem($"{r["Date"]} - {r["AnimalName"]} ({r["Purpose"]})", Convert.ToInt32(r["AppointmentID"])));
                    cmbAppointment2.SelectedIndex = 0;
                    cmbAppointment2.DisplayMember = "Display";
                    cmbAppointment2.ValueMember = "Value";
                }
            }
            catch { }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Select a record to update.", "PawPulse"); return; }
            _editMode = true;
            _editingRecordId = Convert.ToInt32(dgv2.SelectedRows[0].Cells["RecordID"].Value);
            txtDiagnosis2.Text = dgv2.SelectedRows[0].Cells["Diagnosis"].Value?.ToString() ?? "";
            txtNotes2.Text = dgv2.SelectedRows[0].Cells["Notes"].Value?.ToString() ?? "";
            txtWeight2.Text = dgv2.SelectedRows[0].Cells["Weight"].Value?.ToString() ?? "";

            int animalId = Convert.ToInt32(dgv2.SelectedRows[0].Cells["AnimalID"].Value);
            cmbAnimal2.SelectedValue = animalId;

            object apptIdObj = dgv2.SelectedRows[0].Cells["AppointmentID"].Value;
            if (apptIdObj != DBNull.Value && apptIdObj != null)
            {
                int apptId = Convert.ToInt32(apptIdObj);
                foreach (ComboItem item in cmbAppointment2.Items)
                    if (item.Value == apptId) { cmbAppointment2.SelectedItem = item; break; }
            }
            else if (cmbAppointment2.Items.Count > 0) cmbAppointment2.SelectedIndex = 0;

            addForm2.Visible = true;
            addForm2.BringToFront();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Select a record to delete.", "PawPulse"); return; }
            if (MessageBox.Show("Delete this medical record?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            int id = Convert.ToInt32(dgv2.SelectedRows[0].Cells["RecordID"].Value);
            bool ok = _ctrl.DeleteMedicalRecord(id);
            if (ok) { MessageBox.Show("Record deleted.", "PawPulse"); LoadData(); }
            else MessageBox.Show("Failed to delete.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbAnimal2.SelectedItem == null || string.IsNullOrWhiteSpace(txtDiagnosis2.Text)) { MessageBox.Show("Animal and Diagnosis are required.", "PawPulse"); return; }
            int animalId = Convert.ToInt32(cmbAnimal2.SelectedValue);
            decimal weight = 0; decimal.TryParse(txtWeight2.Text, out weight);
            int? apptId = null;
            if (cmbAppointment2.SelectedItem is ComboItem ci && ci.Value > 0) apptId = ci.Value;

            bool ok;
            if (_editMode)
                ok = _ctrl.UpdateMedicalRecord(_editingRecordId, animalId, txtDiagnosis2.Text.Trim(), txtNotes2.Text.Trim(), weight, apptId);
            else
                ok = _ctrl.AddMedicalRecord(animalId, txtDiagnosis2.Text.Trim(), txtNotes2.Text.Trim(), weight, apptId);

            if (ok)
            {
                MessageBox.Show(_editMode ? "Record updated." : "Record added.", "PawPulse");
                _editMode = false; _editingRecordId = 0;
                addForm2.Visible = false;
                txtDiagnosis2.Clear(); txtNotes2.Clear(); txtWeight2.Clear();
                LoadData();
            }
            else MessageBox.Show("Operation failed.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public class ComboItem
    {
        public string Display { get; set; }
        public int Value { get; set; }
        public ComboItem(string display, int value) { Display = display; Value = value; }
        public override string ToString() => Display;
    }
}
