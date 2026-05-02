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
        public ShelterStaffDashboard(int id, string name)
        {
            
            
            
            InitializeComponent();


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
            // Create a new instance of the User Control you just built
            ShelterManageKennelsUC manageKennelsScreen = new ShelterManageKennelsUC();

            // Send it to the stage!
            LoadUserControl(manageKennelsScreen);
        }

        private void btnAdoption_Click(object sender, EventArgs e)
        {
            ProcessAdoptionsUC adoptionsScreen = new ProcessAdoptionsUC();
            LoadUserControl(adoptionsScreen);
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {

        }

       
    }
}
