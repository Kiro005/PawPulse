using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class ManageMedicinesUC : UserControl
    {
        Controller controllerObj;
        DataView currentDataView;
        int currentUserId;
        string currentUserName;

        public ManageMedicinesUC(int userId, string fullName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            currentUserId = userId;
            currentUserName = fullName;

            // Initialize UI elements
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            //if (lblWelcome != null) lblWelcome.Text = $"Welcome, {fullName}";

            SetupGridStyle();
            LoadSupplierFilters();
            RefreshGrid();
        }

        // Configures DataGridView visual properties
        private void SetupGridStyle()
        {
            dgvMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicine.AllowUserToAddRows = false;
            dgvMedicine.ReadOnly = true;
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.BackgroundColor = Color.White;
        }

        // Fetches data and binds it to the grid
        private void RefreshGrid()
        {
            DataTable dt = controllerObj.GetAllMedicinesWithSuppliers();
            if (dt != null)
            {
                currentDataView = new DataView(dt);
                dgvMedicine.DataSource = currentDataView;

                if (dgvMedicine.Columns.Contains("MedicineID"))
                    dgvMedicine.Columns["MedicineID"].Visible = false;

                ApplyStockAlerts();
            }
            StyleDataGridView();
        }

        // Populates the filter ComboBox with Supplier names
        private void LoadSupplierFilters()
        {
            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.Add("All Suppliers");

            DataTable dtSuppliers = controllerObj.GetAllSuppliers();
            if (dtSuppliers != null)
            {
                foreach (DataRow row in dtSuppliers.Rows)
                {
                    cmbTypeFilter.Items.Add(row["SupplierName"].ToString());
                }
            }
            cmbTypeFilter.SelectedIndex = 0;
        }

        // Highlights rows with StockQuantity less than 10
        private void ApplyStockAlerts()
        {
            foreach (DataGridViewRow row in dgvMedicine.Rows)
            {
                if (row.Cells["StockQuantity"].Value != DBNull.Value)
                {
                    int stock = Convert.ToInt32(row.Cells["StockQuantity"].Value);
                    if (stock < 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230);
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        // Re-applies styling when data sorting/binding changes
        private void dgvMedicine_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyStockAlerts();
        }

        // Triggers filter application on text change
        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Triggers filter application on combo box selection
        private void cmbTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        // Applies row filters based on search text and selected supplier
        private void ApplyFilters()
        {
            if (currentDataView == null) return;

            string filter = "";

            if (!string.IsNullOrWhiteSpace(txtSearchUser.Text))
            {
                filter += $"MedicineName LIKE '%{txtSearchUser.Text}%'";
            }

            if (cmbTypeFilter.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                filter += $"SupplierName = '{cmbTypeFilter.SelectedItem.ToString()}'";
            }

            currentDataView.RowFilter = filter;
            ApplyStockAlerts();
        }

        // --- Action Buttons ---

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            AddMedicineForm addFrm = new AddMedicineForm();
            if (addFrm.ShowDialog() == DialogResult.OK)
                RefreshGrid();
        }
        private void StyleDataGridView()
        {
            // Basic Grid Styling
            dgvMedicine.BackgroundColor = Color.White;
            dgvMedicine.BorderStyle = BorderStyle.None;
            dgvMedicine.AllowUserToAddRows = false;
            dgvMedicine.RowHeadersVisible = false;
            dgvMedicine.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMedicine.EnableHeadersVisualStyles = false;

            dgvMedicine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMedicine.RowTemplate.Height = 45;
            dgvMedicine.ColumnHeadersHeight = 50;

            // Dark Navy Header Style
            dgvMedicine.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 40, 55);
            dgvMedicine.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMedicine.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMedicine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row Styling
            dgvMedicine.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 240, 245);
            dgvMedicine.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 40, 55);
            dgvMedicine.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvMedicine.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvMedicine.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Formatting specific columns dynamically to prevent overlapping and clipping

            // 1. Columns that need exact space based on their content
            if (dgvMedicine.Columns.Contains("Dosage"))
            {
                dgvMedicine.Columns["Dosage"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgvMedicine.Columns.Contains("StockQuantity"))
            {
                dgvMedicine.Columns["StockQuantity"].HeaderText = "Stock";
                dgvMedicine.Columns["StockQuantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            if (dgvMedicine.Columns.Contains("UnitPrice"))
            {
                dgvMedicine.Columns["UnitPrice"].HeaderText = "Price";
                dgvMedicine.Columns["UnitPrice"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMedicine.Columns["UnitPrice"].DefaultCellStyle.Format = "C2";
            }

            if (dgvMedicine.Columns.Contains("ExpiryDate"))
            {
                dgvMedicine.Columns["ExpiryDate"].HeaderText = "Expiry Date";
                dgvMedicine.Columns["ExpiryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMedicine.Columns["ExpiryDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }

            // 2. Columns that will stretch to fill the remaining empty space
            if (dgvMedicine.Columns.Contains("MedicineName"))
            {
                dgvMedicine.Columns["MedicineName"].HeaderText = "Medicine Name";
                dgvMedicine.Columns["MedicineName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMedicine.Columns["MedicineName"].FillWeight = 150; // Takes more of the empty space
                dgvMedicine.Columns["MedicineName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }

            if (dgvMedicine.Columns.Contains("SupplierName"))
            {
                dgvMedicine.Columns["SupplierName"].HeaderText = "Supplier";
                dgvMedicine.Columns["SupplierName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvMedicine.Columns["SupplierName"].FillWeight = 130; // Takes less than Medicine Name
                dgvMedicine.Columns["SupplierName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void btnEditMedicine_Click(object sender, EventArgs e)
        {
            // Ensure at least one row is selected in the grid
            if (dgvMedicine.SelectedRows.Count > 0)
            {
                var selectedRow = dgvMedicine.SelectedRows[0];

                // Verify that the MedicineID column exists and contains a valid value
                if (selectedRow.Cells["MedicineID"].Value != null && selectedRow.Cells["MedicineID"].Value != DBNull.Value)
                {
                    int medicineId = Convert.ToInt32(selectedRow.Cells["MedicineID"].Value);

                    // Open the edit form modally, passing the selected medicine ID
                    using (EditMedicineForm editFrm = new EditMedicineForm(medicineId))
                    {
                        if (editFrm.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh the grid to show the updated medicine data
                            RefreshGrid();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a medicine record to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dltMedicine_Click(object sender, EventArgs e)
        {
            if (dgvMedicine.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvMedicine.SelectedRows[0].Cells["MedicineID"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this medicine?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int rowsAffected = controllerObj.DeleteMedicine(id);
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Medicine deleted successfully.", "Success");
                        RefreshGrid();
                    }
                }
            }
        }

        private void btnresupply_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the grid
            if (dgvMedicine.SelectedRows.Count > 0)
            {
                var selectedRow = dgvMedicine.SelectedRows[0];

                if (selectedRow.Cells["MedicineID"].Value != null && selectedRow.Cells["MedicineID"].Value != DBNull.Value)
                {
                    int id = Convert.ToInt32(selectedRow.Cells["MedicineID"].Value);
                    string name = selectedRow.Cells["MedicineName"].Value.ToString();
                    decimal currentPrice = Convert.ToDecimal(selectedRow.Cells["UnitPrice"].Value);

                    // Open the small Resupply Form and pass selected medicine details
                    using (ResupplyForm resupplyFrm = new ResupplyForm(id, name, currentPrice))
                    {
                        if (resupplyFrm.ShowDialog() == DialogResult.OK)
                        {
                            // Refresh the grid to show the updated stock and price
                            RefreshGrid();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a medicine to resupply.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnManageSup_Click(object sender, EventArgs e)
        {
            ManageSuppliersForm supFrm = new ManageSuppliersForm();
            supFrm.ShowDialog();

            // Refresh combo box in case a new supplier was added
            LoadSupplierFilters();
            RefreshGrid();
        }
    }
}