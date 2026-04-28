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

        public MedicalRecordsUC(int vetId)
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
                var dt = _ctrl.GetMedicalRecords();
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("RecordID")) dgv2.Columns["RecordID"].Visible = false;

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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbAnimal2.SelectedItem == null || string.IsNullOrWhiteSpace(txtDiagnosis2.Text)) { MessageBox.Show("Animal and Diagnosis are required.", "PawPulse"); return; }
            int animalId = Convert.ToInt32(cmbAnimal2.SelectedValue);
            decimal weight = 0;
            decimal.TryParse(txtWeight2.Text, out weight);
            int? apptId = null;
            if (cmbAppointment2.SelectedItem is ComboItem ci && ci.Value > 0) apptId = ci.Value;
            bool ok = _ctrl.AddMedicalRecord(animalId, txtDiagnosis2.Text.Trim(), txtNotes2.Text.Trim(), weight, apptId);
            if (ok) { MessageBox.Show("Record added successfully.", "PawPulse"); addForm2.Visible = false; txtDiagnosis2.Clear(); txtNotes2.Clear(); txtWeight2.Clear(); LoadData(); }
            else MessageBox.Show("Failed to add record.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
