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
    public partial class ClientDashboardForm : Form
    {
        private int ClientID;
        private string ClientName;
        public ClientDashboardForm(int ClientID, string fullname)
        {
            InitializeComponent();
            this.ClientID = ClientID;
            this.ClientName = fullname;
            lblUsername.Text = fullname;
        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnDashBoard);
            AddUserControl(new DashboardUC(ClientID, ClientName));
        }

        private void btnAnimals_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnAnimals);
            AddUserControl(new AnimalUC(ClientID, ClientName));
        }

        private void ClientDashboardForm_Load(object sender, EventArgs e)
        {
            MainContentPanel.Controls.Clear();
            AddUserControl(new DashboardUC(ClientID, ClientName));
        }

        private void HighlightActiveButton(Button activeBtn)
        {
            // 1. Change all buttons back to the dark background color
            // (Note: Replace these with your actual button names if they are different!)
            btnDashBoard.BackColor = Color.FromArgb(30, 40, 55); // Use your exact dark blue hex/RGB here
            btnDashBoard.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnDashBoard.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnAnimals.BackColor = Color.FromArgb(30, 40, 55);
            btnAnimals.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnAnimals.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnApp.BackColor = Color.FromArgb(30, 40, 55);
            btnApp.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnApp.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnBilling.BackColor = Color.FromArgb(30, 40, 55);
            btnBilling.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnBilling.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency
            btnAdoption.BackColor = Color.FromArgb(30, 40, 55);
            btnAdoption.ForeColor = Color.FromArgb(200, 200, 200); // Optional: Reset text color for better contrast
            btnAdoption.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80); // Optional: Reset hover color for consistency

            // 2. Change the button that was just clicked to your nice green color!
            activeBtn.BackColor = Color.FromArgb(113, 196, 175); // Use your exact green color here
            activeBtn.ForeColor = Color.White; // Optional: Change text color for better contrast
            activeBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 179, 113); // Optional: Keep the hover color consistent
        }

        private void btnDashBoard_Click_1(object sender, EventArgs e)
        {
            HighlightActiveButton(btnDashBoard);
            AddUserControl(new DashboardUC(ClientID, ClientName));
        }

        private void btnAnimals_Click_1(object sender, EventArgs e)
        {
            HighlightActiveButton(btnAnimals);
            AddUserControl(new AnimalUC(ClientID, ClientName));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnApp);
            AddUserControl(new AppointmentsClientUC(ClientID, ClientName));
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnBilling);
            AddUserControl(new ClientBillingUC(ClientID, ClientName));
        }

        private void btnAdoption_Click(object sender, EventArgs e)
        {
            HighlightActiveButton(btnAdoption);
            AddUserControl(new AdoptionClientUC(ClientID, ClientName));
        }
    }
}
