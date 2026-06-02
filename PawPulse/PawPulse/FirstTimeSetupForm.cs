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
    public partial class FirstTimeSetupForm : Form
    {
        private Controller controllerObj;
        private int VerifiedEmployeeID = -1;
        public FirstTimeSetupForm()
        {
            InitializeComponent();
            controllerObj = new Controller();

            pnlPassword.Visible = false;
            pnlPassword.Enabled = false;
            pnlVerify.Visible = true;
            pnlVerify.Enabled = true;

            lblError.Visible = false;
            ErrorPass.Visible = false;
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
            {
                lblError.Text = "Please enter both email and phone number.";
                lblError.Visible = true;
                return;
            }

            DataTable dt = controllerObj.VerifyFirstTimeEmployee(email, phone);

            if (dt != null && dt.Rows.Count > 0)
            {
                // Success! We found the employee with a NULL password.
                // Save their ID so we can use it in Phase 2
                VerifiedEmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);

                // UI Magic: Hide Phase 1, Show Phase 2!
                pnlVerify.Visible = false;
                pnlVerify.Enabled = false;

                pnlPassword.Visible = true;
                pnlPassword.Enabled = true;

                MessageBox.Show("Identity verified! Please create your new password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("We couldn't find a pending account with those details. \n\nPlease check for typos or contact your Admin to ensure your account was created.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // 1. Basic validation
            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                ErrorPass.Text = "Please fill in both password fields.";
                ErrorPass.Visible = true;
                return;
            }

            if (newPassword != confirmPassword)
            {
                ErrorPass.Text = "Passwords do not match. Please try again.";
                ErrorPass.Visible = true;
                return;
            }

            if (newPassword.Length < 8)
            {
                ErrorPass.Text = "Password must be at least 8 characters long.";
                ErrorPass.Visible = true;
                return;
            }

            // 2. Hash the password (Assuming you are using BCrypt like in your SQL script!)
             string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // 3. Save to database
            int result = controllerObj.SetEmployeePassword(VerifiedEmployeeID, hashedPassword);

            if (result > 0)
            {
                MessageBox.Show("Password set successfully! You can now log in.", "Setup Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the setup form, returning them to the Login screen
            }
            else
            {
                MessageBox.Show("Something went wrong saving your password. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            ErrorPass.Visible = false;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            ErrorPass.Visible = false;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }

        private void ErrorPass_Click(object sender, EventArgs e)
        {

        }
    }
}
