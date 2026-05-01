using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawPulse
{
    public partial class AddUserForm : Form
    {
        Controller controllerObj;

        public AddUserForm()
        {
            InitializeComponent();
            controllerObj = new Controller();

            // Hide error message on startup
            lblError.Visible = false;

            // Load roles dynamically from the database
            FillRolesComboBox();
        }

        private void FillRolesComboBox()
        {
            DataTable dt = controllerObj.GetEmployeeRoles();
            if (dt != null)
            {
                cmbRole.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    cmbRole.Items.Add(row["EmployeeRole"].ToString());
                }

                if (cmbRole.Items.Count > 0)
                    cmbRole.Text=""; // Set to empty string to prompt selection
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            // 1. Check for empty fields first
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtphone.Text) ||
                string.IsNullOrWhiteSpace(txtSalary.Text) ||
                cmbRole.SelectedIndex == -1)
            {
                lblError.Text = "Please, Fill all the Fields"; // Update label text
                lblError.Visible = true;
                return;
            }

            // 2. Validate Phone and Salary (Negative numbers check)
            // Try to parse the values to ensure they are numeric and positive
            bool isSalaryValid = decimal.TryParse(txtSalary.Text, out decimal salaryValue);
            bool isPhoneValid = long.TryParse(txtphone.Text, out long phoneValue);

            if (!isSalaryValid || salaryValue < 0)
            {
                lblError.Text = "Salary must be a positive number!";
                lblError.Visible = true;
                return;
            }

            if (!isPhoneValid || phoneValue < 0)
            {
                lblError.Text = "Phone number cannot be negative!";
                lblError.Visible = true;
                return;
            }

            // 3. If all validations pass, proceed to database logic
            lblError.Visible = false;

            try
            {
                int result = controllerObj.InsertEmployee(
                    txtFName.Text,
                    txtLName.Text,
                    cmbRole.Text,
                    txtEmail.Text,
                    txtphone.Text,
                    salaryValue // Use the parsed positive decimal
                );

                if (result > 0)
                {
                    MessageBox.Show("Employee added successfully!", "Success");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message);
            }
        }
    }
}
