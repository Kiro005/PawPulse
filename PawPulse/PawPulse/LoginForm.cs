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
            lblError.Text = ""; // Clear any previous error messages
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            DataTable dt = ControllerObj.GetUserLoginInfo(email);

            if (dt != null && dt.Rows.Count > 0)
            {
                string hashFromDatabase = dt.Rows[0]["PasswordHash"].ToString();
                string userRole = dt.Rows[0]["Role"].ToString(); // This will be Client, Admin, Vet, or Staff

                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashFromDatabase);

                if (isPasswordValid)
                {
                    // Success! Hide the login screen
                    this.Hide();

                    // 4. Route them to the exact right portal based on their role
                    switch (userRole)
                    {
                        case "Client":
                            ClientDashboardForm clientPortal = new ClientDashboardForm();
                            clientPortal.Show();
                            break;
                        case "Admin":
                            //AdminDashboardForm adminPortal = new AdminDashboardForm();
                            //adminPortal.Show();
                            break;
                        case "Vet":
                            // Replace with your actual Vet form name
                            //VetDashboardForm vetPortal = new VetDashboardForm();
                            //vetPortal.Show();
                            break;
                        case "Staff":
                            // Replace with your actual Staff form name
                            //StaffDashboardForm staffPortal = new StaffDashboardForm();
                            //staffPortal.Show();
                            break;
                        default:
                            MessageBox.Show("Error: Unrecognized user role.");
                            this.Show(); // Show login screen again if something went wrong
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
    }
}
