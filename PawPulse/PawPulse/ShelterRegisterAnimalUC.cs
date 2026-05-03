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

            UIThemeManager.ApplyTheme(this);

            // 1. Make sure the dropdown allows typing (so they can add new species like "Rabbit")
            cmbSpecies2.DropDownStyle = ComboBoxStyle.DropDown;

            // 2. Load the species dynamically from the DB
            RefreshSpeciesDropdown();

            // 3. Load available kennels from the database
            RefreshKennelDropdown();

            // We can leave Gender hardcoded since Biological Sex (Male/Female) won't change, 
            // but you can use this same logic for Gender if you prefer!
            cmbGender2.Items.Clear();
            cmbGender2.Items.Add("Male");
            cmbGender2.Items.Add("Female");
            cmbGender2.SelectedIndex = -1;
        }

        private void ShelterRegisterAnimalUC_Load(object sender, EventArgs e)
        {
            // Populate Species Dropdown
            cmbSpecies2.Items.Clear();
            cmbSpecies2.Items.Add("Dog");
            cmbSpecies2.Items.Add("Cat");
            cmbSpecies2.Items.Add("Bird");
            cmbSpecies2.Items.Add("Other");
            cmbSpecies2.SelectedIndex = -1;

            // Populate Gender Dropdown
            cmbGender2.Items.Clear();
            cmbGender2.Items.Add("Male");
            cmbGender2.Items.Add("Female");
            cmbGender2.SelectedIndex = -1;

            // Load available kennels
            RefreshKennelDropdown();
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