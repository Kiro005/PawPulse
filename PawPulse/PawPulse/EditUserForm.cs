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
    public partial class EditUserForm : Form
    {
        Controller controllerObj;
        int currentEmpID;

        // Receive the ID of the selected employee
        public EditUserForm(int empID)
        {
            InitializeComponent();
            controllerObj = new Controller();
            currentEmpID = empID;

            lblError.Visible = false;
            FillRolesComboBox();
            LoadEmployeeData(); // Load data into fields
        }

        private void LoadEmployeeData()
        {
            DataTable dt = controllerObj.GetEmployeeByID(currentEmpID);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtFName.Text = row["FirstName"].ToString();
                txtLName.Text = row["LastName"].ToString();
                txtEmail.Text = row["Email"].ToString();
                txtphone.Text = row["Phone"].ToString();
                txtSalary.Text = row["Salary"].ToString();
                cmbRole.Text = row["EmployeeRole"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate that all required fields are filled (IsNullOrWhiteSpace)
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtphone.Text) ||
                string.IsNullOrWhiteSpace(txtSalary.Text) ||
                cmbRole.SelectedIndex == -1)
            {
                lblError.Text = "Please, Fill all the Fields";
                lblError.Visible = true;
                return;
            }

            // 2. Positive number validation for Salary and Phone
            bool isSalaryValid = decimal.TryParse(txtSalary.Text, out decimal salaryValue);
            if (!isSalaryValid || salaryValue < 0)
            {
                lblError.Text = "Invalid Salary value!";
                lblError.Visible = true;
                return;
            }

            // 3. Show Confirmation Message before updating
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?",
                                                       "Confirm Update",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // 4. Proceed with the update through the controller
                    int result = controllerObj.UpdateEmployee(
                        currentEmpID,
                        txtFName.Text,
                        txtLName.Text,
                        cmbRole.Text,
                        txtEmail.Text,
                        txtphone.Text,
                        salaryValue
                    );

                    if (result > 0)
                    {
                        MessageBox.Show("Employee data updated successfully!", "Success");
                        this.DialogResult = DialogResult.OK; // Signal the main form to refresh
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error");
                }
            }
            // If user clicks 'No', nothing happens and the form stays open
        }
        // Helper method to populate the ComboBox with roles from the Database
        private void FillRolesComboBox()
        {
            // Retrieve unique roles from the database through the controller
            DataTable dt = controllerObj.GetEmployeeRoles();

            if (dt != null && dt.Rows.Count > 0)
            {
                // Clear any existing items to avoid duplicates
                cmbRole.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    // Add the role name to the ComboBox items
                    cmbRole.Items.Add(row["EmployeeRole"].ToString());
                }

                // Set the default selection to the first item (Index 0)
                if (cmbRole.Items.Count > 0)
                {
                    cmbRole.SelectedIndex = 0;
                }
            }
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtphone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblemail_Click(object sender, EventArgs e)
        {

        }

        private void lblLastname_Click(object sender, EventArgs e)
        {

        }

        private void lblsalary_Click(object sender, EventArgs e)
        {

        }

        private void lblphone_Click(object sender, EventArgs e)
        {

        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblFirstname_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
