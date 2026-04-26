using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class VaccinationsUC : UserControl
    {
        private Controller _ctrl;
        private DataGridView dgv;
        private Panel addForm;
        private ComboBox cmbAnimal;
        private ComboBox cmbVaccine;
        private DateTimePicker dtpDate;

        public VaccinationsUC()
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
            lblTitle.Text = "Vaccinations";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);

            var btnAdd = new Button();
            btnAdd.Text = "+  Add Vaccination";
            btnAdd.Size = new Size(155, 34);
            btnAdd.Location = new Point(645, 13);
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
            panel.Size = new Size(380, 230);
            panel.Location = new Point(230, 70);
            panel.BorderStyle = BorderStyle.FixedSingle;

            var lbl = new Label();
            lbl.Text = "Add Vaccination";
            lbl.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(31, 38, 62);
            lbl.Location = new Point(15, 15);
            lbl.AutoSize = true;

            AddCombo(panel, "Animal:", 55, out cmbAnimal);
            AddCombo(panel, "Vaccine:", 100, out cmbVaccine);

            var lblDate = new Label();
            lblDate.Text = "Date:";
            lblDate.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            lblDate.ForeColor = Color.FromArgb(60, 60, 80);
            lblDate.Location = new Point(15, 148);
            lblDate.AutoSize = true;

            dtpDate = new DateTimePicker();
            dtpDate.Location = new Point(120, 145);
            dtpDate.Size = new Size(240, 26);
            dtpDate.Font = new Font("Segoe UI", 9.5f);
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Value = DateTime.Today;

            var btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(185, 190);
            btnSave.Size = new Size(85, 30);
            btnSave.BackColor = Color.FromArgb(113, 196, 175);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;

            var btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(280, 190);
            btnCancel.Size = new Size(85, 30);
            btnCancel.BackColor = Color.FromArgb(220, 80, 80);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += (s, e) => addForm.Visible = false;

            panel.Controls.Add(lbl);
            panel.Controls.Add(lblDate);
            panel.Controls.Add(dtpDate);
            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCancel);
            return panel;
        }

        private void AddCombo(Panel parent, string label, int y, out ComboBox cmb)
        {
            var lbl = new Label(); lbl.Text = label; lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold); lbl.ForeColor = Color.FromArgb(60, 60, 80); lbl.Location = new Point(15, y + 3); lbl.AutoSize = true;
            cmb = new ComboBox(); cmb.Location = new Point(120, y); cmb.Size = new Size(245, 26); cmb.Font = new Font("Segoe UI", 9.5f); cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            parent.Controls.Add(lbl); parent.Controls.Add(cmb);
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
                dgv.DataSource = dt;
                if (dgv.Columns.Contains("AnimalID")) dgv.Columns["AnimalID"].Visible = false;
                if (dgv.Columns.Contains("VaccineID")) dgv.Columns["VaccineID"].Visible = false;

                var animals = _ctrl.GetAllAnimals();
                cmbAnimal.DataSource = animals;
                cmbAnimal.DisplayMember = "Display";
                cmbAnimal.ValueMember = "AnimalID";

                var vaccines = _ctrl.GetVaccines();
                cmbVaccine.DataSource = vaccines;
                cmbVaccine.DisplayMember = "Display";
                cmbVaccine.ValueMember = "VaccineID";
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbAnimal.SelectedItem == null || cmbVaccine.SelectedItem == null) { MessageBox.Show("Please select animal and vaccine.", "PawPulse"); return; }
            int animalId = Convert.ToInt32(cmbAnimal.SelectedValue);
            int vaccineId = Convert.ToInt32(cmbVaccine.SelectedValue);
            bool ok = _ctrl.AddVaccination(animalId, vaccineId, dtpDate.Value);
            if (ok) { MessageBox.Show("Vaccination recorded.", "PawPulse"); addForm.Visible = false; LoadData(); }
            else MessageBox.Show("Failed to record vaccination. It may already exist.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
