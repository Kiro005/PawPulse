using DBapplication;
using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class AdminDashboard : MaterialForm
    {
        public AdminDashboard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Create an instance of the Controller
            Controller controllerObj = new Controller();

            // Fetch the data
            DataTable dt = controllerObj.GetActiveEmployees();

            // Check if the DataTable has data
            if (dt != null)
            {
                // Bind the data to the grid
                dataGridViewEmployees.DataSource = dt;
                dataGridViewEmployees.Refresh();
            }
            else
            {
                // Print error message in English
                MessageBox.Show("No active employees found or database connection failed.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPageUsers_Click(object sender, EventArgs e)
        {

        }
    }
}
