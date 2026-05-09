using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class ManageSuppliersForm : Form
    {
        private Controller controllerObj;
        private bool isEditMode = false;

        public ManageSuppliersForm()
        {
            InitializeComponent();
            controllerObj = new Controller();

            // Apply UI styles and load initial data
            SetupFormStyles();
            LoadSuppliersCombo();
        }

        // Applies the PawPulse dark theme and control formatting
        private void SetupFormStyles()
        {
            // Form styling
            this.BackColor = Color.FromArgb(30, 40, 55);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // ComboBox styling (DropDown allows typing new names)
            cmbSuppliers.DropDownStyle = ComboBoxStyle.DropDown;
            cmbSuppliers.Font = new Font("Segoe UI", 8F, FontStyle.Regular);

            // TextBoxes styling
            TextBox[] inputs = { txtphone, txtemail, txtaddress };
            foreach (TextBox txt in inputs)
            {
                txt.BackColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
                txt.Font = new Font("Segoe UI", 11F);
            }

            // Labels styling
            Label[] labels = { lblselectsup, lblphone, lblemail, lbladdress };
            foreach (Label lbl in labels)
            {
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            }

            // Buttons styling
            btnSave.BackColor = Color.FromArgb(46, 204, 113); // Mint Green
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            btnCancel.BackColor = Color.FromArgb(64, 80, 100); // Slate Gray
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);

            btnAddsupp.BackColor = Color.White;
            btnAddsupp.ForeColor = Color.Black;
            btnAddsupp.FlatStyle = FlatStyle.Flat;
            btnAddsupp.FlatAppearance.BorderSize = 0;
            btnAddsupp.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        }

        // Fetches suppliers from the database and binds them to the ComboBox
        private void LoadSuppliersCombo()
        {
            DataTable dt = controllerObj.GetSuppliers();
            if (dt != null)
            {
                // Temporarily detach event to avoid triggering during data bind
                cmbSuppliers.SelectedIndexChanged -= cmbSuppliers_SelectedIndexChanged;

                cmbSuppliers.DataSource = dt;
                cmbSuppliers.DisplayMember = "SupplierName";
                cmbSuppliers.ValueMember = "SupplierID";
                cmbSuppliers.SelectedIndex = -1;

                cmbSuppliers.SelectedIndexChanged += cmbSuppliers_SelectedIndexChanged;
            }
        }

        // Triggers when a supplier is selected from the dropdown
        private void cmbSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuppliers.SelectedValue != null && int.TryParse(cmbSuppliers.SelectedValue.ToString(), out int id))
            {
                isEditMode = true; // Switch to update mode

                DataTable dt = controllerObj.GetSupplierDetails(id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    txtphone.Text = dt.Rows[0]["ContactPhone"].ToString();
                    txtemail.Text = dt.Rows[0]["Email"].ToString();
                    txtaddress.Text = dt.Rows[0]["SupplierAddress"].ToString();
                }
            }
        }

        // Clears input fields to prepare for adding a new supplier
        private void btnAddsupp_Click(object sender, EventArgs e)
        {
            isEditMode = false; // Switch to insert mode

            cmbSuppliers.SelectedIndex = -1;
            cmbSuppliers.Text = "";

            txtphone.Clear();
            txtemail.Clear();
            txtaddress.Clear();

            // Set focus to the combobox so the user can type the new supplier name
            cmbSuppliers.Focus();
        }

        // Handles both Insert (New) and Update (Edit) database operations
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = cmbSuppliers.Text.Trim();
            string phone = txtphone.Text.Trim();
            string email = txtemail.Text.Trim();
            string address = txtaddress.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Supplier name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isEditMode && cmbSuppliers.SelectedValue != null)
            {
                // Update existing record
                int id = Convert.ToInt32(cmbSuppliers.SelectedValue);
                int result = controllerObj.UpdateSupplier(id, name, phone, address, email);

                if (result > 0)
                {
                    MessageBox.Show("Supplier updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuppliersCombo();
                }
            }
            else
            {
                // Insert new record
                int result = controllerObj.InsertSupplier(name, phone, address, email);

                if (result > 0)
                {
                    MessageBox.Show("New supplier added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuppliersCombo();
                }
            }

            // Reset state after saving
            isEditMode = false;
            txtphone.Clear();
            txtemail.Clear();
            txtaddress.Clear();
            cmbSuppliers.SelectedIndex = -1;
        }

        // Closes the dialog
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}