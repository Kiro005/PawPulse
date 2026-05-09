using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class AddMedicineForm : Form
    {
        private Controller controllerObj;

        public AddMedicineForm()
        {
            InitializeComponent();
            controllerObj = new Controller();

            // Initializes UI components and loads database records
            SetupUI();
            LoadSuppliersCombo();
        }

        // Configures initial control states and styling
        private void SetupUI()
        {
            // Applies form dark theme
            this.BackColor = Color.FromArgb(30, 40, 55);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Hides validation error label by default
            lblError.Visible = false;

            // Configures dropdown style for supplier selection
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Sets constraints for numeric inputs
            numStock.Minimum = 0;
            numStock.Maximum = 10000;

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 100000;
            numericUpDown1.DecimalPlaces = 2;

            // Sets datetime picker format
            dtpExpiry.Format = DateTimePickerFormat.Short;

            // Formats action buttons (Note: Ensure the button name in Designer is exactly 'btnAddUser' without any invalid characters)
            btnadd.BackColor = Color.FromArgb(46, 204, 113); // Mint Green
            btnadd.ForeColor = Color.White;
            btnadd.FlatStyle = FlatStyle.Flat;
            btnadd.FlatAppearance.BorderSize = 0;

            btncancel.BackColor = Color.FromArgb(64, 80, 100); // Slate Gray
            btncancel.ForeColor = Color.White;
            btncancel.FlatStyle = FlatStyle.Flat;
            btncancel.FlatAppearance.BorderSize = 0;
        }

        // Fetches suppliers and binds them to the combobox
        private void LoadSuppliersCombo()
        {
            DataTable dt = controllerObj.GetSuppliers();
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "SupplierName";
                comboBox1.ValueMember = "SupplierID";
                comboBox1.SelectedIndex = -1; // Default to empty selection
            }
        }

        // Handles the insertion of a new medicine record
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // Reset error label state
            lblError.Visible = false;

            string name = txtMedname.Text.Trim();
            string dosage = txtDosage.Text.Trim();
            int quantity = (int)numStock.Value;
            decimal price = numericUpDown1.Value;
            DateTime expiry = dtpExpiry.Value;

            // Validates required text inputs and dropdown selection
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(dosage) || comboBox1.SelectedIndex == -1)
            {
                lblError.Text = "Please, Fill all the Fields";
                lblError.Visible = true;
                return;
            }

            int supplierId = Convert.ToInt32(comboBox1.SelectedValue);

            // Executes database insertion
            int result = controllerObj.InsertMedicine(name, dosage, quantity, price, expiry, supplierId);

            if (result > 0)
            {
                MessageBox.Show("New medicine added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Signals success to the parent form and closes
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Database operation failed.";
                lblError.Visible = true;
            }
        }

        // Closes the form without saving
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}