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
        private bool _editMode = false;
        private int _editingTestId = 0;

        public LabTestsUC(int vetId)
        {
            _vetId = vetId;
            _ctrl = new Controller();
            InitializeComponent();
            StyleGrid(dgv2);
            btnAdd.Click += (s, e) => { _editMode = false; _editingTestId = 0; addForm2.Visible = true; addForm2.BringToFront(); };
            btnSave.Click += BtnSave_Click;
            btnCancelAdd.Click += (s, e) => { addForm2.Visible = false; _editMode = false; _editingTestId = 0; };
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
                var dt = _ctrl.GetLabTests();
                dgv2.DataSource = dt;
                if (dgv2.Columns.Contains("TestID")) dgv2.Columns["TestID"].Visible = false;
                if (dgv2.Columns.Contains("RecordID")) dgv2.Columns["RecordID"].Visible = false;

                var records = _ctrl.GetMedicalRecordsDropdown();
                cmbRecord2.DataSource = records;
                cmbRecord2.DisplayMember = "Display";
                cmbRecord2.ValueMember = "RecordID";
            }
            catch { }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Select a lab test to update.", "PawPulse"); return; }
            _editMode = true;
            _editingTestId = Convert.ToInt32(dgv2.SelectedRows[0].Cells["TestID"].Value);
            txtTestType2.Text = dgv2.SelectedRows[0].Cells["Type"].Value?.ToString() ?? "";
            txtResults2.Text = dgv2.SelectedRows[0].Cells["Result"].Value?.ToString() ?? "";
            txtCost2.Text = dgv2.SelectedRows[0].Cells["Cost"].Value?.ToString() ?? "";
            cmbRecord2.SelectedValue = Convert.ToInt32(dgv2.SelectedRows[0].Cells["RecordID"].Value);
            addForm2.Visible = true;
            addForm2.BringToFront();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgv2.SelectedRows.Count == 0) { MessageBox.Show("Select a lab test to delete.", "PawPulse"); return; }
            if (MessageBox.Show("Delete this lab test?", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            int id = Convert.ToInt32(dgv2.SelectedRows[0].Cells["TestID"].Value);
            bool ok = _ctrl.DeleteLabTest(id);
            if (ok) { MessageBox.Show("Lab test deleted.", "PawPulse"); LoadData(); }
            else MessageBox.Show("Failed to delete.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbRecord2.SelectedItem == null || string.IsNullOrWhiteSpace(txtTestType2.Text)) { MessageBox.Show("Record and Test Type are required.", "PawPulse"); return; }
            int recordId = Convert.ToInt32(cmbRecord2.SelectedValue);
            decimal cost = 0; decimal.TryParse(txtCost2.Text, out cost);

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
                ok = _ctrl.UpdateLabTest(_editingTestId, recordId, txtTestType2.Text.Trim(), txtResults2.Text.Trim(), cost);
            else
                ok = _ctrl.AddLabTest(recordId, txtTestType2.Text.Trim(), txtResults2.Text.Trim(), cost, paidInCash);

            if (ok)
            {
                string msg = _editMode ? "Lab test updated." : "Lab test added.";
                if (!_editMode)
                    msg += isClientAnimal ? (paidInCash ? "\nMarked as Paid." : "\nAdded to client's bill as Unpaid.") : "\nShelter animal — not billed.";
                MessageBox.Show(msg, "PawPulse");
                _editMode = false; _editingTestId = 0;
                addForm2.Visible = false;
                txtTestType2.Clear(); txtResults2.Clear(); txtCost2.Clear();
                LoadData();
            }
            else MessageBox.Show("Operation failed.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
