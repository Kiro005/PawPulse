using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DBapplication;

namespace PawPulse
{
    public partial class LoginForm : Form
    {
        Controller ControllerObj;
        public LoginForm()
        {
            InitializeComponent();
            ControllerObj = new Controller();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please enter both email and password.";
                return;
            }
            lblError.Text = "";
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            DataTable dt = ControllerObj.GetUserLoginInfo(email);

            if (dt != null && dt.Rows.Count > 0 && Convert.ToBoolean(dt.Rows[0]["IsActive"]))
            {
                string hashFromDatabase = dt.Rows[0]["PasswordHash"].ToString();
                string userRole = dt.Rows[0]["Role"].ToString();
                int userId = int.Parse(dt.Rows[0]["UserID"].ToString());
                string firstName = dt.Rows[0]["FirstName"].ToString();
                string lastName = dt.Rows[0]["LastName"].ToString();
                string fullName = firstName + " " + lastName;

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashFromDatabase);

                if (isPasswordValid)
                {
                    this.Hide();

                    switch (userRole)
                    {
                        case "Client":
                            ClientDashboardForm clientPortal = new ClientDashboardForm(userId, fullName);
                            clientPortal.Show();
                            break;
                        case "Veterinarian":
                            sidebarPanel2 vetPortal = new sidebarPanel2(userId, fullName);
                            vetPortal.Show();
                            break;
                        case "Manager":
                            AdminDashboardForm adminPortal = new AdminDashboardForm(userId, fullName);
                            adminPortal.Show();
                            break;
                        case "Shelter Staff":
                            ShelterStaffDashboard shelter = new ShelterStaffDashboard(userId, fullName);
                            shelter.Show();
                            break;
                        default:
                            MessageBox.Show("Error: Unrecognized user role.");
                            this.Show();
                            break;
                    }
                }
                else
                {
                    lblError.Text = "Invalid email or password.";
                }
            }
            else
            {
                lblError.Text = "Invalid email or password.";
            }
        }

        private void SignUplabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            // Temporary bypass for testing purposes
            // Using Mohamed Gharabwy (ID: 7) as the default manager from your SQL data
            int tempManagerID = 7;
            string tempManagerName = "Mohamed Gharabwy";

            // Initialize and show the Admin Dashboard directly
            AdminDashboardForm adminDash = new AdminDashboardForm(tempManagerID, tempManagerName);
            adminDash.Show();

            // Hide the login form
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            FirstTimeSetupForm setupForm = new FirstTimeSetupForm();
            setupForm.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // Skip authentication for testing purposes
            // Using dummy ID (1) and generic Name
            AdminDashboardForm adminDash = new AdminDashboardForm(1, "Test Administrator");

            adminDash.Show();
            this.Hide(); // Hide login form to keep app running
        }
    }
    
}
