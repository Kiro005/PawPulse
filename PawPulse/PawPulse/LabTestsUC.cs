using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class LabTestsUC : UserControl
    {
        private int _vetId;
        private Controller _ctrl;
        private DataGridView dgv;
        private Panel addForm;
        private ComboBox cmbRecord;
        private TextBox txtTestType;
        private TextBox txtResult;
        private TextBox txtCost;

        public LabTestsUC(int vetId)
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
            lblTitle.Text = "Lab Tests";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);

            var btnAdd = new Button();
            btnAdd.Text = "+  Add Lab Test";
            btnAdd.Size = new Size(140, 34);
            btnAdd.Location = new Point(660, 13);
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
            panel.Size = new Size(400, 265);
            panel.Location = new Point(220, 70);
            panel.BorderStyle = BorderStyle.FixedSingle;

            var lbl = new Label();
            lbl.Text = "Add Lab Test";
            lbl.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(31, 38, 62);
            lbl.Location = new Point(15, 15);
            lbl.AutoSize = true;

            AddCombo(panel, "Medical Record:", 55, out cmbRecord);
            AddText(panel, "Test Type:", 105, out txtTestType);
            AddText(panel, "Result:", 150, out txtResult);
            AddText(panel, "Cost (EGP):", 195, out txtCost);

            var btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(205, 228);
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
            btnCancel.Location = new Point(300, 228);
            btnCancel.Size = new Size(85, 30);
            btnCancel.BackColor = Color.FromArgb(220, 80, 80);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI Semibold", 10f, FontStyle.Bold);
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += (s, e) => addForm.Visible = false;

            panel.Controls.Add(lbl);
            panel.Controls.Add(btnSave);
            panel.Controls.Add(btnCancel);
            return panel;
        }

        private void AddCombo(Panel parent, string label, int y, out ComboBox cmb)
        {
            var lbl = new Label(); lbl.Text = label; lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold); lbl.ForeColor = Color.FromArgb(60, 60, 80); lbl.Location = new Point(15, y + 3); lbl.AutoSize = true;
            cmb = new ComboBox(); cmb.Location = new Point(155, y); cmb.Size = new Size(230, 26); cmb.Font = new Font("Segoe UI", 9.5f); cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            parent.Controls.Add(lbl); parent.Controls.Add(cmb);
        }

        private void AddText(Panel parent, string label, int y, out TextBox txt)
        {
            var lbl = new Label(); lbl.Text = label; lbl.Font = new Font("Segoe UI", 9f, FontStyle.Bold); lbl.ForeColor = Color.FromArgb(60, 60, 80); lbl.Location = new Point(15, y + 3); lbl.AutoSize = true;
            txt = new TextBox(); txt.Location = new Point(155, y); txt.Size = new Size(230, 26); txt.Font = new Font("Segoe UI", 9.5f); txt.BorderStyle = BorderStyle.FixedSingle;
            parent.Controls.Add(lbl); parent.Controls.Add(txt);
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
                var dt = _ctrl.GetLabTests();
                dgv.DataSource = dt;
                if (dgv.Columns.Contains("TestID")) dgv.Columns["TestID"].Visible = false;

                var records = _ctrl.GetMedicalRecordsDropdown();
                cmbRecord.DataSource = records;
                cmbRecord.DisplayMember = "Display";
                cmbRecord.ValueMember = "RecordID";
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbRecord.SelectedItem == null || string.IsNullOrWhiteSpace(txtTestType.Text)) { MessageBox.Show("Record and Test Type are required.", "PawPulse"); return; }
            int recordId = Convert.ToInt32(cmbRecord.SelectedValue);
            decimal cost = 0; decimal.TryParse(txtCost.Text, out cost);
            bool ok = _ctrl.AddLabTest(recordId, txtTestType.Text.Trim(), txtResult.Text.Trim(), cost);
            if (ok) { MessageBox.Show("Lab test added.", "PawPulse"); addForm.Visible = false; txtTestType.Clear(); txtResult.Clear(); txtCost.Clear(); LoadData(); }
            else MessageBox.Show("Failed to add lab test.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
