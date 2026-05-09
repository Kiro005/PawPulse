using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class KennelDetailForm : Form
    {
        private Controller controllerObj;
        private int _kennelId;
        private bool isEditMode = false;

        // Constructor 1: Triggered when "Add" button is clicked (Register mode)
        public KennelDetailForm()
        {
            InitializeComponent();
            controllerObj = new Controller();
            isEditMode = false;

            SetupUI();
        }

        // Constructor 2: Triggered when "Edit" button is clicked (Update mode)
        public KennelDetailForm(int id)
        {
            InitializeComponent();
            controllerObj = new Controller();
            _kennelId = id;
            isEditMode = true;

            SetupUI();
            LoadKennelData();
        }

        // Configures the form theme, label texts, and control behaviors
        private void SetupUI()
        {
            // Apply PawPulse Dark Theme
            this.BackColor = Color.FromArgb(30, 40, 55);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblError.Visible = false; // Hide validation message initially

            // Populate Dropdown Lists with standard values
            cmbSize.Items.AddRange(new string[] { "Small", "Medium", "Large" });
            cmbWard.Items.AddRange(new string[] { "Isolation", "General", "Adoption" });
            cmbStatus.Items.AddRange(new string[] { "Available", "Needs Cleaning" });

            // Set default selections
            cmbSize.SelectedIndex = 0;
            cmbWard.SelectedIndex = 1;

            // Logic to switch between REGISTER and UPDATE mode
            if (isEditMode)
            {
                // UI changes for EDIT mode
                lblmode.Text = "UPDATE\nKENNELS"; // The vertical label on the left
                lblRole.Text = "EDIT";          // The smaller role label
                btnSave.Text = "Update";
                btnSave.BackColor = Color.FromArgb(52, 152, 219); // Sky Blue theme for editing

                cmbStatus.Enabled = true; // Allow editing status for existing kennels
            }
            else
            {
                // UI changes for REGISTER mode
                lblmode.Text = "REGISTER\nKENNELS";
                lblRole.Text = "ADD";
                btnSave.Text = "Save";
                btnSave.BackColor = Color.FromArgb(46, 204, 113); // Mint Green theme for registering

                // New kennels must start as 'Available' and cannot be changed during registration
                cmbStatus.SelectedItem = "Available";
                cmbStatus.Enabled = false;
            }

            // Numeric constraint for capacity
            numCapacity.Minimum = 1;
            numCapacity.Maximum = 100;

            // Buttons visual formatting
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btnCancel.BackColor = Color.FromArgb(100, 110, 120);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
        }

        // Fetches existing data from DB and populates the fields
        private void LoadKennelData()
        {
            DataTable dt = controllerObj.GetKennelByID(_kennelId);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                numCapacity.Value = Convert.ToInt32(row["Capacity"]);
                cmbSize.SelectedItem = row["KennelSize"].ToString();
                cmbWard.SelectedItem = row["WardType"].ToString();
                cmbStatus.SelectedItem = row["KennelStatus"].ToString();
            }
        }

        // Handles both Insert and Update operations based on isEditMode flag
        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            // Simple validation: Ensure dropdowns have selections
            if (cmbSize.SelectedIndex == -1 || cmbWard.SelectedIndex == -1 || cmbStatus.SelectedIndex == -1)
            {
                lblError.Text = "Please, Fill all the Fields";
                lblError.Visible = true;
                return;
            }

            int capacity = (int)numCapacity.Value;
            string size = cmbSize.SelectedItem.ToString();
            string ward = cmbWard.SelectedItem.ToString();
            string status = cmbStatus.SelectedItem.ToString();

            if (isEditMode)
            {
                // Execute Database Update
                int result = controllerObj.UpdateKennel(_kennelId, capacity, size, ward, status);
                if (result > 0)
                {
                    MessageBox.Show("Kennel updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                // Execute Database Insertion (Registration)
                int result = controllerObj.InsertKennel(capacity, size, ward, status);
                if (result > 0)
                {
                    MessageBox.Show("New kennel registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        // Closes the form without modifications
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}