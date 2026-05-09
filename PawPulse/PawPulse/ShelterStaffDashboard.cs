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
    public partial class ShelterStaffDashboard : Form
    {
        private int _staffId;
        private string _staffName;

        public ShelterStaffDashboard(int id, string name)
        {
            InitializeComponent();
            _staffId = id;
            _staffName = name;
            lblUsername.Text = name; // show the real name in the header
        }


        private void LoadUserControl(UserControl uc)
        {
            MainContentPanel.Controls.Clear(); // Clears the white stage
            uc.Dock = DockStyle.Fill;        // Makes the new screen fill the stage
            MainContentPanel.Controls.Add(uc); // Injects the new screen
        }

        private void MainContentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnManageKennels_Click(object sender, EventArgs e)
        {
            ShelterManageKennelsUC uc = new ShelterManageKennelsUC();
            LoadUserControl(uc);
            // EXPLICITLY call a public refresh method
            uc.RefreshData();
        }

        private void btnAdoption_Click(object sender, EventArgs e)
        {
            ProcessAdoptionsUC adoptionsScreen = new ProcessAdoptionsUC(_staffId);
            LoadUserControl(adoptionsScreen);
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            ManageAdoptionFeesShelterUC feesScreen = new ManageAdoptionFeesShelterUC();
            LoadUserControl(feesScreen);
        }

        private void btnRegisterAnimal_Click(object sender, EventArgs e)
        {
            ShelterRegisterAnimalUC registerScreen = new ShelterRegisterAnimalUC();
            LoadUserControl(registerScreen);
        }

        private void btnAnimals_Click(object sender, EventArgs e)
        {
            HealthClearanceShelterStaffUC clearanceScreen = new HealthClearanceShelterStaffUC();
            LoadUserControl(clearanceScreen);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
