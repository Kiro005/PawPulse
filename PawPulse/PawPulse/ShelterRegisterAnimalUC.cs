using DBapplication;
using System;
using System.Data;
using System.Windows.Forms;

namespace PawPulse
{
    public partial class ShelterRegisterAnimalUC : UserControl
    {
        Controller controllerObj = new Controller();

        public ShelterRegisterAnimalUC()
        {
            InitializeComponent();

           

            cmbSpecies2.DropDownStyle = ComboBoxStyle.DropDown;

            RefreshSpeciesDropdown();

            //Load available kennels from the database
            RefreshKennelDropdown();

            cmbGender2.Items.Clear();
            cmbGender2.Items.Add("Male");
            cmbGender2.Items.Add("Female");
            cmbGender2.SelectedIndex = -1;
        }

       

        private void RefreshKennelDropdown()
        {
            // Fetch kennels that are NOT full
            DataTable dtKennels = controllerObj.GetKennelsWithSpace();
            cmbKennel2.DataSource = dtKennels;
            cmbKennel2.DisplayMember = "Display";
            cmbKennel2.ValueMember = "KennelID";
            cmbKennel2.SelectedIndex = -1;
        }

        // Make sure your Designer Click event is hooked up to this specific method name!
        private void btnRegister2_Click(object sender, EventArgs e)
        {
            // Basic Validation
            if (string.IsNullOrWhiteSpace(txtName2.Text) || cmbSpecies2.SelectedIndex == -1 || cmbGender2.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all required fields (Name, Species, and Gender).");
                return;
            }

            decimal weight = 0;
            if (!string.IsNullOrWhiteSpace(txtWeight2.Text) && !decimal.TryParse(txtWeight2.Text, out weight))
            {
                MessageBox.Show("Please enter a valid number for weight.");
                return;
            }

            string name = txtName2.Text;
            string species = cmbSpecies2.Text;
            string breed = textBreed2.Text;
            string gender = cmbGender2.Text;
            string dob = dtpDOB2.Value.ToString("yyyy-MM-dd");

            // SMART KENNEL LOGIC: Grab the ID if selected, otherwise leave it null
            int? kennelId = null;
            if (cmbKennel2.SelectedIndex != -1 && cmbKennel2.SelectedValue != null)
            {
                kennelId = Convert.ToInt32(cmbKennel2.SelectedValue);
            }

            // Call the Controller
            if (controllerObj.ShelterRegisterAnimal(name, species, breed, gender, dob, weight, kennelId))
            {
                MessageBox.Show("Animal registered successfully!");

                // Clear the form for the next entry
                txtName2.Clear();
                textBreed2.Clear();
                txtWeight2.Clear();
                cmbSpecies2.SelectedIndex = -1;
                cmbGender2.SelectedIndex = -1;

                // Refresh the kennel list 
                RefreshKennelDropdown();
            }
            else
            {
                MessageBox.Show("An error occurred during registration. Please check your connection.");
            }
        }

        // Make sure your Designer Click event is hooked up to this specific method name!
        private void btnClear2_Click(object sender, EventArgs e)
        {
            txtName2.Clear();
            textBreed2.Clear();
            txtWeight2.Clear();
            cmbSpecies2.SelectedIndex = -1;
            cmbGender2.SelectedIndex = -1;
            cmbKennel2.SelectedIndex = -1;
        }


        

        private void RefreshSpeciesDropdown()
        {
            DataTable dtSpecies = controllerObj.GetExistingSpecies();

            // Bind the database results to the ComboBox
            cmbSpecies2.DataSource = dtSpecies;
            cmbSpecies2.DisplayMember = "Species";
            cmbSpecies2.ValueMember = "Species";

            // Ensure it starts blank
            cmbSpecies2.SelectedIndex = -1;
            cmbSpecies2.Text = "";
        }

    }
}