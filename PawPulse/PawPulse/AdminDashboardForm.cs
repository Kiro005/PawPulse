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
        private ContextMenuStrip cmsUsers; // Dropdown menu for Users button

        public AdminDashboardForm(int userId, string fullName)
        {
            ClientID = userId;
            ClientName = fullName;
            InitializeComponent();

            // Set the username in header
            lblUsername.Text = ClientName;

            // Initialize the Dropdown Menu for Users
            InitializeUsersMenu();
        }

        // Setup the hover menu items
        private void InitializeUsersMenu()
        {
            cmsUsers = new ContextMenuStrip();
            cmsUsers.Items.Add("Employee Directory", null, EmployeeDirectory_Click);
            cmsUsers.Items.Add("Client Directory", null, ClientDirectory_Click);

            // Optional: Customize look to match your Navy theme
            cmsUsers.BackColor = Color.FromArgb(30, 40, 55);
            cmsUsers.ForeColor = Color.White;
        }

        private void AddUserControl(UserControl uc)
        {
            // Clear the current stage
            MainContentPanel.Controls.Clear();

            // Setup docking and add to panel
            uc.Dock = DockStyle.Fill;
            MainContentPanel.Controls.Add(uc);
            uc.BringToFront();
        }

        private void HighlightActiveButton(Button activeBtn)
        {
            // 1. Reset all buttons to default dark color
            List<Button> navButtons = new List<Button> { btnUsers, btnMedicines, btnKennels, btnAdoptionfees, btnReports };
            foreach (var btn in navButtons)
            {
                btn.BackColor = Color.FromArgb(30, 40, 55);
                btn.ForeColor = Color.FromArgb(200, 200, 200);
            }

            // 2. Highlight the active button with green
            activeBtn.BackColor = Color.FromArgb(113, 196, 175);
            activeBtn.ForeColor = Color.White;
        }

        // --- Users Button Hover Logic ---

        private void btnUsers_MouseEnter(object sender, EventArgs e)
        {
            // Show the dropdown menu when mouse enters the button area
            // Positions it to the right of the sidebar button
            cmsUsers.Show(btnUsers, new Point(btnUsers.Width, 0));
        }

        private void EmployeeDirectory_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnUsers);
            // Load ManageUsers in "Employee" mode
            AddUserControl(new ManageUsersUC(ClientID, ClientName, "Employee"));
        }

        private void ClientDirectory_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnUsers);
            // Load ManageUsers in "Client" mode (Add button should be hidden here)
            AddUserControl(new ManageUsersUC(ClientID, ClientName, "Client"));
        }

        // --- Navigation Handlers ---

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Clicking the button directly shows the default view (Employees)
            EmployeeDirectory_Click(sender, e);
        }

        private void btnMedicines_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnMedicines);
            AddUserControl(new ManageMedicinesUC(ClientID, ClientName));
        }

        private void btnKennels_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnKennels);
            AddUserControl(new ManageKennelsUC(ClientID, ClientName));
        }

        private void btnAdoptionfees_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnAdoptionfees);
            AddUserControl(new ManageAdoptionFeesUC());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.FormClosed -= AdminDashboardForm_FormClosed;
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        // --- Form Events ---

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            // Default screen on load
            EmployeeDirectory_Click(sender, e);
        }

        private void AdminDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void emplyeeDircToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Highlight the Users button in the sidebar
            HighlightActiveButton(btnUsers);

            // 2. Load ManageUsers control with "Employee" view
            // This will show the Add button and employee data
            AddUserControl(new ManageUsersUC(ClientID, ClientName, "Employee"));

        }

        private void clientDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. Highlight the Users button in the sidebar
            HighlightActiveButton(btnUsers);

            // 2. Load ManageUsers control with "Client" view
            // This will hide the Add button and show client data
            AddUserControl(new ManageUsersUC(ClientID, ClientName, "Client"));
        }

        private void clientDirectoryToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            
            // Show the menu to the right of the button
            // Point(btnUsers.Width, 0) makes it appear exactly at the edge of the sidebar
            cmsUsers.Show(btnUsers, new Point(btnUsers.Width, 0));
        
    }

        private void btnUsers_MouseLeave(object sender, EventArgs e)
        {
            //cmsUsers.Hide();
        }

        private void btnMedicines_Click_1(object sender, EventArgs e)
        {
            HighlightActiveButton(btnMedicines);
            AddUserControl(new ManageMedicinesUC(ClientID, ClientName));

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // 1. Highlight the Reports button in the sidebar
            HighlightActiveButton(btnReports);
            // 2. Load the Reports UserControl
            AddUserControl(new ReportsUC(ClientID, ClientName));
        }
    }
}