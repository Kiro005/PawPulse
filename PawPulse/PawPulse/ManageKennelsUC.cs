using DBapplication;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PawPulse
{
    public partial class ManageKennelsUC : UserControl
    {
        private Controller controllerObj;
        private int ClientID;
        private string ClientName;

        public ManageKennelsUC(int clientID, string clientName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            ClientID = clientID;
            ClientName = clientName;

            // Initialize UI and Data
            ApplyKennelStyle();
            SetupFilters();
            LoadKennelData();

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblWelcome.Text = "Manage Shelter Kennels";
        }

        // Fetches data from database and binds it to the grid
        private void LoadKennelData()
        {
            DataTable dt = controllerObj.GetAllKennelsWithAnimals();
            dgvKennels.DataSource = dt;
            ApplySearchAndFilter();
        }

        private void SetupFilters()
        {
            cmbFilterCategory.Items.Clear();
            cmbFilterCategory.Items.Add("All Kennels");
            cmbFilterCategory.Items.Add("Size");
            cmbFilterCategory.Items.Add("Ward Type");
            cmbFilterCategory.Items.Add("Capacity");
            cmbFilterCategory.Items.Add("Status");

            cmbFilterCategory.SelectedIndex = 0;
            cmbFilterValue.Enabled = false;

            cmbFilterCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterValue.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ApplyKennelStyle()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);

            // DataGridView Modern Styling
            dgvKennels.BackgroundColor = Color.White;
            dgvKennels.BorderStyle = BorderStyle.None;
            dgvKennels.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKennels.RowHeadersVisible = false;
            dgvKennels.AllowUserToAddRows = false;
            dgvKennels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKennels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKennels.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 240, 250);
            dgvKennels.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvKennels.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

            dgvKennels.EnableHeadersVisualStyles = false;
            dgvKennels.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 60, 95);
            dgvKennels.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvKennels.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvKennels.ColumnHeadersHeight = 40;

            // Buttons Styling (Updated to match your variable names)
            FormatButton(btnAdd, Color.FromArgb(30, 40, 55), Color.White);
            FormatButton(btnEdit, Color.FromArgb(70, 80, 95), Color.White);
            FormatButton(btnreassign, Color.Yellow, Color.Black); // Assign Animal
            FormatButton(btndlt, Color.Red, Color.White);

            // Labels styling
            lblFilterTag.ForeColor = Color.FromArgb(100, 110, 120);
            lblSearchTag.ForeColor = Color.FromArgb(100, 110, 120);
            lblDetails.ForeColor = Color.FromArgb(100, 110, 120);
        }

        private void FormatButton(Button btn, Color bg, Color fg)
        {
            if (btn == null) return;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = bg;
            btn.ForeColor = fg;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }

        private void ApplySearchAndFilter()
        {
            if (dgvKennels.DataSource == null) return;
            DataTable dt = (DataTable)dgvKennels.DataSource;
            string rowFilter = "";

            // Text Search Logic (ID or Animal Name)
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                rowFilter += $"(Convert(KennelID, 'System.String') LIKE '%{txtSearch.Text}%' OR [Occupied By] LIKE '%{txtSearch.Text}%')";
            }

            // Double-Stage Filter Logic
            if (cmbFilterCategory.SelectedIndex > 0 && cmbFilterValue.SelectedIndex > 0 && cmbFilterValue.SelectedItem.ToString() != "All")
            {
                string cat = cmbFilterCategory.SelectedItem.ToString();
                string val = cmbFilterValue.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(rowFilter)) rowFilter += " AND ";

                if (cat == "Size") rowFilter += $"[Size] = '{val}'";
                else if (cat == "Ward Type") rowFilter += $"[Ward] = '{val}'";
                else if (cat == "Capacity") rowFilter += $"Capacity = {val}";
                else if (cat == "Status") rowFilter += $"[Status] = '{val}'";
            }

            dt.DefaultView.RowFilter = rowFilter;
        }

        // Event for Stage 1 Filter
        private void cmbFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbFilterCategory.SelectedItem?.ToString();
            cmbFilterValue.Items.Clear();

            if (selectedCategory == "All Kennels" || string.IsNullOrEmpty(selectedCategory))
            {
                cmbFilterValue.Enabled = false;
            }
            else
            {
                cmbFilterValue.Enabled = true;
                cmbFilterValue.Items.Add("All");

                if (selectedCategory == "Size")
                    cmbFilterValue.Items.AddRange(new string[] { "Small", "Medium", "Large" });
                else if (selectedCategory == "Ward Type")
                    cmbFilterValue.Items.AddRange(new string[] { "Isolation", "General", "Adoption" });
                else if (selectedCategory == "Capacity")
                    cmbFilterValue.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });
                else if (selectedCategory == "Status")
                    cmbFilterValue.Items.AddRange(new string[] { "Available", "Occupied", "Needs Cleaning" });

                cmbFilterValue.SelectedIndex = 0;
            }
            ApplySearchAndFilter();
        }

        private void cmbFilterValue_SelectedIndexChanged(object sender, EventArgs e) => ApplySearchAndFilter();

        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplySearchAndFilter();

        // [ADD] Opens the Kennel Detail Form
        private void btnAdd_Click(object sender, EventArgs e)
        {
            KennelDetailForm addForm = new KennelDetailForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadKennelData();
            }
        }

        // [EDIT] Opens the Kennel Detail Form with selected ID
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvKennels.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKennels.SelectedRows[0].Cells["KennelID"].Value);
                KennelDetailForm editForm = new KennelDetailForm(id);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadKennelData();
                }
            }
        }

        // [ASSIGN/REASSIGN] Logic to assign an animal to a kennel
        private void btnreassign_Click(object sender, EventArgs e)
        {
            if (dgvKennels.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKennels.SelectedRows[0].Cells["KennelID"].Value);
                string status = dgvKennels.SelectedRows[0].Cells["Status"].Value.ToString();

                if (status == "Available")
                {
                    AssignAnimalForm assignForm = new AssignAnimalForm(id);
                    if (assignForm.ShowDialog() == DialogResult.OK) LoadKennelData();
                }
                else
                {
                    MessageBox.Show("Kennel is not available for assignment.", "Status Warning");
                }
            }
        }

        // [DELETE] Deletes the selected kennel unit
        private void btndlt_Click(object sender, EventArgs e)
        {
            if (dgvKennels.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvKennels.SelectedRows[0].Cells["KennelID"].Value);
                string occupiedBy = dgvKennels.SelectedRows[0].Cells["Occupied By"].Value.ToString();

                if (occupiedBy != "Empty")
                {
                    MessageBox.Show("Cannot delete occupied kennel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show("Delete this kennel?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (controllerObj.DeleteKennel(id) > 0) LoadKennelData();
                }
            }
        }
    }
}