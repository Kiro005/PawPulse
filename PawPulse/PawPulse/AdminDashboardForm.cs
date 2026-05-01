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
    public partial class AdminDashboardForm : Form
    {
        private int ClientID;
        private string ClientName;
        public AdminDashboardForm(int userId, string fullName)
        {
            ClientID = userId;
            ClientName = fullName;
            InitializeComponent();

            // Assign the name to the label in the header
            lblUsername.Text = ClientName;

        }

        private void AddUserControl(UserControl uc)
        {
            // Clear out whatever is currently on the stage
            MainContentPanel.Controls.Clear();

            // Tell the new mini-screen to fill up the whole stage
            uc.Dock = DockStyle.Fill;

            // Add it to the screen!
            MainContentPanel.Controls.Add(uc);
            uc.BringToFront();
        }
        private void HighlightActiveButton(Button activeBtn)
        {
            // 1. Change all buttons back to the dark background color
            // (Note: Replace these with your actual button names if they are different!)
            btnUsers.BackColor = Color.FromArgb(30, 40, 55); // Use your exact dark blue hex/RGB here
            btnUsers.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnUsers.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnMedicines.BackColor = Color.FromArgb(30, 40, 55);
            btnMedicines.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnMedicines.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnKennels.BackColor = Color.FromArgb(30, 40, 55);
            btnKennels.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnKennels.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnAdoptionfees.BackColor = Color.FromArgb(30, 40, 55);
            btnAdoptionfees.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnAdoptionfees.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnReports.BackColor = Color.FromArgb(30, 40, 55);
            btnReports.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnReports.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency

            // 2. Change the button that was just clicked to your nice green color!
            activeBtn.BackColor = Color.FromArgb(113, 196, 175); // Use your exact green color here
            activeBtn.ForeColor = Color.White; // Optional: Change text color for better contrast
            activeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 179, 113); // Optional: Keep the hover color consistent
        }
        private void btnUsers_Click_1(object sender, EventArgs e)
        {
            HighlightActiveButton(btnUsers);
            AddUserControl(new DashboardUC(ClientID, ClientName));
        }

        private void btnMedicines_Click_1(object sender, EventArgs e)
        {
            HighlightActiveButton(btnMedicines);
            AddUserControl(new ManageMedicinesUC(ClientID, ClientName));
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.FormClosed -= AdminDashboardForm_FormClosed;

            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void btnKennels_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnKennels);
            AddUserControl(new AppointmentsClientUC(ClientID, ClientName));
        }

        private void btnAdoptionfees_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnAdoptionfees);
            AddUserControl(new ClientBillingUC(ClientID, ClientName));
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnUsers);
            AddUserControl(new ManageUsers(ClientID, ClientName));
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnMedicines);
            AddUserControl(new ManageMedicinesUC(ClientID, ClientName));
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            MainContentPanel.Controls.Clear();
            AddUserControl(new ManageUsers(ClientID, ClientName));
        }

        private void AdminDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Terminate the entire application and all hidden forms
            Application.Exit();
        }

    }
}
