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
                        case "Admin":
                            break;
                        case "Staff":
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
    }
}
