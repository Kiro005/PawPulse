using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class EditMedicineForm : Form
    {
        private Controller controllerObj;
        private int _medicineId;

        // Constructor modified to accept medicine ID
        public EditMedicineForm(int medicineId)
        {
            InitializeComponent();
            controllerObj = new Controller();
            _medicineId = medicineId;

            SetupUI();
            LoadSuppliersCombo();

            // Load the existing medicine data into the fields
            LoadMedicineData();
        }

        // Configures styling and constraints
        private void SetupUI()
        {
            this.BackColor = Color.FromArgb(30, 40, 55);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblError.Visible = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            numStock.Minimum = 0;
            numStock.Maximum = 10000;

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 100000;
            numericUpDown1.DecimalPlaces = 2;

            dtpExpiry.Format = DateTimePickerFormat.Short;

            // Formats buttons
            btnadd.BackColor = Color.FromArgb(46, 204, 113); // Mint Green
            btnadd.ForeColor = Color.White;
            btnadd.FlatStyle = FlatStyle.Flat;
            btnadd.FlatAppearance.BorderSize = 0;

            btncancel.BackColor = Color.FromArgb(64, 80, 100); // Slate Gray
            btncancel.ForeColor = Color.White;
            btncancel.FlatStyle = FlatStyle.Flat;
            btncancel.FlatAppearance.BorderSize = 0;
        }

        // Fetches suppliers for the dropdown
        private void LoadSuppliersCombo()
        {
            DataTable dt = controllerObj.GetSuppliers();
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "SupplierName";
                comboBox1.ValueMember = "SupplierID";
                comboBox1.SelectedIndex = -1;
            }
        }

        // Fetches specific medicine data and populates the UI
        private void LoadMedicineData()
        {
            DataTable dt = controllerObj.GetMedicineByID(_medicineId);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                txtMedname.Text = row["MedicineName"].ToString();
                txtDosage.Text = row["Dosage"].ToString();
                numStock.Value = Convert.ToDecimal(row["StockQuantity"]);
                numericUpDown1.Value = Convert.ToDecimal(row["UnitPrice"]);

                if (DateTime.TryParse(row["ExpiryDate"].ToString(), out DateTime expiryDate))
                {
                    dtpExpiry.Value = expiryDate;
                }

                comboBox1.SelectedValue = row["SupplierID"];
            }
        }

        // Executes the update operation
        private void btnadd_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string name = txtMedname.Text.Trim();
            string dosage = txtDosage.Text.Trim();
            int quantity = (int)numStock.Value;
            decimal price = numericUpDown1.Value;
            DateTime expiry = dtpExpiry.Value;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(dosage) || comboBox1.SelectedIndex == -1)
            {
                lblError.Text = "Please, Fill all the Fields";
                lblError.Visible = true;
                return;
            }

            int supplierId = Convert.ToInt32(comboBox1.SelectedValue);

            int result = controllerObj.UpdateMedicine(_medicineId, name, dosage, quantity, price, expiry, supplierId);

            if (result > 0)
            {
                MessageBox.Show("Medicine updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Update failed.";
                lblError.Visible = true;
            }
        }

        // Closes the form
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}