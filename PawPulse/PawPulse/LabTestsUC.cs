using System;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class LabTestsUC : UserControl
    {
        private int _vetId;
        private Controller _ctrl;

        public LabTestsUC(int vetId)
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
                var dt = _ctrl.GetLabTests();
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("TestID")) dgv2.Columns["TestID"].Visible = false;

                var records = _ctrl.GetMedicalRecordsDropdown();
                cmbRecord2.DataSource = records;
                cmbRecord2.DisplayMember = "Display";
                cmbRecord2.ValueMember = "RecordID";
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbRecord2.SelectedItem == null || string.IsNullOrWhiteSpace(txtTestType2.Text)) { MessageBox.Show("Record and Test Type are required.", "PawPulse"); return; }
            int recordId = Convert.ToInt32(cmbRecord2.SelectedValue);
            decimal cost = 0; decimal.TryParse(txtCost2.Text, out cost);
            bool ok = _ctrl.AddLabTest(recordId, txtTestType2.Text.Trim(), txtResults2.Text.Trim(), cost);
            if (ok) { MessageBox.Show("Lab test added.", "PawPulse"); addForm2.Visible = false; txtTestType2.Clear(); txtResults2.Clear(); txtCost2.Clear(); LoadData(); }
            else MessageBox.Show("Failed to add lab test.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
