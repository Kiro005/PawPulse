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
    public partial class SignUpForm : Form
    {
        Controller ControllerObj;
        public SignUpForm()
        {
            InitializeComponent();
            ControllerObj = new Controller();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = "";

            string fName = txtFirstName.Text.Trim();
            string lName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string city = txtCity.Text.Trim();
            string street = txtStreet.Text.Trim();
            string buildingNum = txtBNum.Text.Trim();
            string password = txtPassword.Text; // Passwords shouldn't be trimmed!

            if (string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(lName) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(street) ||
                string.IsNullOrWhiteSpace(buildingNum) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Please fill in all the required fields.";
                lblError.Visible = true;
                return;
            }

            if (ControllerObj.CheckIfUserExists(email, phone))
            {
                lblError.Text = "A user with this email or phone number already exists.";
                lblError.Visible = true;
                return;
            }

            if (password.Length < 8)
            {
                lblError.Text = "Password must be at least 8 characters long.";
                lblError.Visible = true;
                return;
            }


            int newClientId = ControllerObj.SignUpClient(fName, lName, phone, email, city, street, buildingNum, password);

            if (newClientId > 0)
            {
                new ClientDashboardForm(newClientId, fName + " " + lName).Show();
                this.Hide();
            }
            else
            {
                lblError.Text = "Something went wrong with the database. Please try again.";
                lblError.Visible = true;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }

        private void txtBNum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
