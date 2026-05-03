using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class ManageAdoptionFeesUC : UserControl
    {
        Controller controllerObj;

        public ManageAdoptionFeesUC()
        {
            InitializeComponent();
            controllerObj = new Controller();
            ApplyInterfaceStyles();
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            SetupUI();
            LoadSpeciesCombo();
            StyleInputControls();
            RefreshGrid();
        }

        // Configure UI components and grid styling
        private void SetupUI()
        {
            // Hide status label by default
            lblState.Visible = false;

            // Configure ComboBox to act as both text input and dropdown with autocomplete
            cmbSpecies.DropDownStyle = ComboBoxStyle.DropDown;
            cmbSpecies.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbSpecies.AutoCompleteSource = AutoCompleteSource.ListItems;

            // DataGridView basic styling
            dgvFees.BackgroundColor = Color.White;
            dgvFees.BorderStyle = BorderStyle.None;
            dgvFees.AllowUserToAddRows = false;
            dgvFees.RowHeadersVisible = false;
            dgvFees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFees.EnableHeadersVisualStyles = false;
            dgvFees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFees.RowTemplate.Height = 45;
            dgvFees.ColumnHeadersHeight = 50;

            // Header styling
            dgvFees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 40, 55);
            dgvFees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Row styling
            dgvFees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 240, 245);
            dgvFees.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 40, 55);
            dgvFees.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        }

        // Populate ComboBox with distinct species from the database
        private void LoadSpeciesCombo()
        {
            cmbSpecies.Items.Clear();
            DataTable dt = controllerObj.GetDistinctSpecies();

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Species"] != DBNull.Value)
                    {
                        cmbSpecies.Items.Add(row["Species"].ToString());
                    }
                }
            }
        }

        // Fetch adoption settings and bind to the grid
        private void RefreshGrid()
        {
            DataTable dt = controllerObj.GetAdoptionSettings();
            dgvFees.DataSource = dt;

            // Format specific columns
            if (dgvFees.Columns.Contains("SettingID"))
                dgvFees.Columns["SettingID"].Visible = false;

            if (dgvFees.Columns.Contains("BaseFee"))
                dgvFees.Columns["BaseFee"].DefaultCellStyle.Format = "C2"; // Currency format
        }

        // Handle the SET FEES button click
        private void btnSet_Click(object sender, EventArgs e)
        {
            string species = cmbSpecies.Text.Trim();

            // 1. Validate Species input
            if (string.IsNullOrWhiteSpace(species))
            {
                ShowStatus("Please enter or select a species.", Color.Red);
                return;
            }

            // 2. Validate Fee input (must be a positive decimal)
            if (!decimal.TryParse(txtFees.Text, out decimal fee) || fee < 0)
            {
                ShowStatus("Please enter a valid positive fee amount.", Color.Red);
                return;
            }

            // 3. Execute DB update/insert
            int result = controllerObj.SetAdoptionFee(species, fee);

            if (result > 0)
            {
                ShowStatus($"Fee for {species} successfully set to {fee:C2}.", Color.Green);
                RefreshGrid();

                // Dynamically add new species to ComboBox if not already present
                if (!cmbSpecies.Items.Contains(species))
                {
                    cmbSpecies.Items.Add(species);
                }
            }
            else
            {
                ShowStatus("Database operation failed.", Color.Red);
            }
        }
        // Enhances the visual appearance of input controls to match a modern flat design
        private void StyleInputControls()
        {
            // 1. Style ComboBox
            cmbSpecies.FlatStyle = FlatStyle.Flat; // Removes the old 3D look
            cmbSpecies.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            cmbSpecies.BackColor = Color.FromArgb(245, 247, 250); // Light grayish-blue background
            cmbSpecies.ForeColor = Color.FromArgb(30, 40, 55); // Dark navy text

            // 2. Style TextBox
            txtFees.BorderStyle = BorderStyle.FixedSingle;
            txtFees.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtFees.BackColor = Color.FromArgb(245, 247, 250);
            txtFees.ForeColor = Color.FromArgb(30, 40, 55);

            // 3. Style standard Labels dynamically (ignoring the dynamic status label)
            // This loops through controls directly on the UserControl
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label && ctrl.Name != "lblState" && ctrl.Name != "lblWelcome" && ctrl.Name != "lblDate")
                {
                    ctrl.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
                    ctrl.ForeColor = Color.DimGray;
                }
            }

            // Note: If your labels are inside a specific Panel or GroupBox (like groupBox1), 
            // change 'this.Controls' to 'groupBox1.Controls' in the loop above.
        }

        // Reset the form
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbSpecies.SelectedIndex = -1;
            cmbSpecies.Text = "";
            txtFees.Clear();
            lblState.Visible = false;
        }

        // Handle grid click to quickly populate input fields for editing
        private void dgvFees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFees.Rows[e.RowIndex];
                cmbSpecies.Text = row.Cells["Species"].Value.ToString();
                txtFees.Text = row.Cells["BaseFee"].Value.ToString();
                lblState.Visible = false;
            }
        }

        // Helper method to display validation or success messages
        private void ShowStatus(string message, Color color)
        {
            lblState.Text = message;
            lblState.ForeColor = color;
            lblState.Visible = true;
        }
        private void ApplyInterfaceStyles()
        {
            // 1. Labels styling (Segoe UI Semibold for a modern look)
            Font tagFont = new Font("Segoe UI Semibold", 10, FontStyle.Bold);
            Color tagColor = Color.FromArgb(64, 64, 64); // Professional Dark Gray

            lblFilterTag.Font = tagFont;
            lblFilterTag.ForeColor = tagColor;

            lblSearchTag.Font = tagFont;
            lblSearchTag.ForeColor = tagColor;

            

            // 3. Input Controls styling (Flat and Clean)
            Color inputBg = Color.FromArgb(245, 247, 250); // Soft light blue-gray
            Color navyText = Color.FromArgb(30, 40, 55);   // Deep Navy

            // ComboBox styling
            cmbSpecies.FlatStyle = FlatStyle.Flat;
            cmbSpecies.Font = new Font("Segoe UI", 11);
            cmbSpecies.BackColor = inputBg;
            cmbSpecies.ForeColor = navyText;

            // TextBox styling
            txtFees.BorderStyle = BorderStyle.FixedSingle;
            txtFees.Font = new Font("Segoe UI", 11);
            txtFees.BackColor = inputBg;
            txtFees.ForeColor = navyText;

            // 4. Status Label (Keeping it distinct for notifications)
            lblState.Font = new Font("Segoe UI", 9, FontStyle.Italic);
        }
        // Filters the DataGridView dynamically based on the species input
        private void FilterGrid()
        {
            if (dgvFees.DataSource == null) return;

            DataTable dt = (DataTable)dgvFees.DataSource;

            // Prevent SQL syntax errors by escaping single quotes
            string searchText = cmbSpecies.Text.Trim().Replace("'", "''");

            if (!string.IsNullOrEmpty(searchText))
            {
                // Apply filter to show rows matching the entered species
                dt.DefaultView.RowFilter = $"Species LIKE '%{searchText}%'";
            }
            else
            {
                // Clear the filter to show all records
                dt.DefaultView.RowFilter = string.Empty;
            }
        }

        private void cmbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterGrid();
        }
    }
}