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
        private DataGridView dgv;
        private Panel addForm;
        private ComboBox cmbAnimal;
        private ComboBox cmbAppointment;
        private TextBox txtDiagnosis;
        private TextBox txtNotes;
        private TextBox txtWeight;

        public MedicalRecordsUC(int vetId)
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
            lblTitle.Text = "Medical Records";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);

            var btnAdd = new Button();
            btnAdd.Text = "+  Add Record";
            btnAdd.Size = new Size(130, 34);
            btnAdd.Location = new Point(680, 13);
            btnAdd.BackColor = Color.FromArgb(113, 196, 175);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += (s, e) => { addForm.Visible = true; addForm.BringToFront(); };

            topBar.Controls.Add(lblTitle);
            topBar.Controls.Add(btnAdd);

            dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            StyleGrid(dgv);

            var contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Padding = new Padding(20, 10, 20, 10);
            contentPanel.Controls.Add(dgv);

            addForm = BuildAddForm();
            addForm.Visible = false;

            this.Controls.Add(addForm);
            this.Controls.Add(contentPanel);
            this.Controls.Add(topBar);
        }

        private Panel BuildAddForm()
        {
            var panel = new Panel();
            panel.BackColor = Color.White;
            panel.Size = new Size(400, 370);
            panel.Location = new Point(220, 70);
            panel.BorderStyle = BorderStyle.FixedSingle;

            var lbl = new Label();
            lbl.Text = "Add Medical Record";
            lbl.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(31, 38, 62);
            lbl.Location = new Point(15, 15);
            lbl.AutoSize = true;

            AddField(panel, "Animal:", 55, out cmbAnimal);
            AddFieldTxt(panel, "Diagnosis:", 110, out txtDiagnosis);
            AddFieldTxtMulti(panel, "Notes:", 165, out txtNotes);
            AddFieldTxt(panel, "Weight (kg):", 250, out txtWeight);

            var lblAppt = new Label();
            lblAppt.Text = "Appointment (optional):";
            lblAppt.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblAppt.ForeColor = Color.FromArgb(60, 60, 80);
            lblAppt.Location = new Point(15, 295);
            lblAppt.AutoSize = true;

            cmbAppointment = new ComboBox();
            cmbAppointment.Location = new Point(185, 292);
            cmbAppointment.Size = new Size(195, 26);
            cmbAppointment.Font = new Font("Segoe UI", 9.5f);
            cmbAppointment.DropDownStyle = ComboBoxStyle.DropDownList;

            var btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(200, 328);
            btnSave.Size = new Size(90, 32);
            btnSave.BackColor = Color.FromArgb(113, 196, 175);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;

            var btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(300, 328);
            btnCancel.Size = new Size(90, 32);
            btnCancel.BackColor = Color.FromArgb(220, 80, 80);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += (s, e) => addForm.Visible = false;

            panel.Controls.Add(lbl);
            panel.Controls.Add(lblAppt);
            panel.Controls.Add(cmbAppointment);
            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCancel);

            return panel;
        }

        private void AddField(Panel parent, string label, int y, out ComboBox cmb)
        {
            var lbl = new Label();
            lbl.Text = label;
            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(60, 60, 80);
            lbl.Location = new Point(15, y + 3);
            lbl.AutoSize = true;
            cmb = new ComboBox();
            cmb.Location = new Point(150, y);
            cmb.Size = new Size(230, 26);
            cmb.Font = new Font("Segoe UI", 9.5f);
            cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            parent.Controls.Add(lbl);
            parent.Controls.Add(cmb);
        }

        private void AddFieldTxt(Panel parent, string label, int y, out TextBox txt)
        {
            var lbl = new Label();
            lbl.Text = label;
            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(60, 60, 80);
            lbl.Location = new Point(15, y + 3);
            lbl.AutoSize = true;
            txt = new TextBox();
            txt.Location = new Point(150, y);
            txt.Size = new Size(230, 26);
            txt.Font = new Font("Segoe UI", 9.5f);
            txt.BorderStyle = BorderStyle.FixedSingle;
            parent.Controls.Add(lbl);
            parent.Controls.Add(txt);
        }

        private void AddFieldTxtMulti(Panel parent, string label, int y, out TextBox txt)
        {
            var lbl = new Label();
            lbl.Text = label;
            lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(60, 60, 80);
            lbl.Location = new Point(15, y + 3);
            lbl.AutoSize = true;
            txt = new TextBox();
            txt.Location = new Point(150, y);
            txt.Size = new Size(230, 55);
            txt.Font = new Font("Segoe UI", 9.5f);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Multiline = true;
            parent.Controls.Add(lbl);
            parent.Controls.Add(txt);
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
                var dt = _ctrl.GetMedicalRecords();
                dgv.DataSource = dt;
                if (dgv.Columns.Contains("RecordID")) dgv.Columns["RecordID"].Visible = false;

                var animals = _ctrl.GetAllAnimals();
                cmbAnimal.DataSource = animals;
                cmbAnimal.DisplayMember = "Display";
                cmbAnimal.ValueMember = "AnimalID";

                var appts = _ctrl.GetVetAppointments(_vetId);
                if (appts != null)
                {
                    cmbAppointment.Items.Clear();
                    cmbAppointment.Items.Add(new ComboItem("None", 0));
                    foreach (DataRow r in appts.Rows)
                        cmbAppointment.Items.Add(new ComboItem($"{r["Date"]} - {r["AnimalName"]} ({r["Purpose"]})", Convert.ToInt32(r["AppointmentID"])));
                    cmbAppointment.SelectedIndex = 0;
                    cmbAppointment.DisplayMember = "Display";
                    cmbAppointment.ValueMember = "Value";
                }
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbAnimal.SelectedItem == null || string.IsNullOrWhiteSpace(txtDiagnosis.Text)) { MessageBox.Show("Animal and Diagnosis are required.", "PawPulse"); return; }
            int animalId = Convert.ToInt32(cmbAnimal.SelectedValue);
            decimal weight = 0;
            decimal.TryParse(txtWeight.Text, out weight);
            int? apptId = null;
            if (cmbAppointment.SelectedItem is ComboItem ci && ci.Value > 0) apptId = ci.Value;
            bool ok = _ctrl.AddMedicalRecord(animalId, txtDiagnosis.Text.Trim(), txtNotes.Text.Trim(), weight, apptId);
            if (ok) { MessageBox.Show("Record added successfully.", "PawPulse"); addForm.Visible = false; txtDiagnosis.Clear(); txtNotes.Clear(); txtWeight.Clear(); LoadData(); }
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
