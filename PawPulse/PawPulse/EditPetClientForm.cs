using DBapplication;
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
    public partial class EditPetClientForm : Form
    {
        Controller controllerObj;
        int SelectedAnimalID;
        public EditPetClientForm(int animalID, string petName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            SelectedAnimalID = animalID;

            lblError.Visible = false;
            label2.Text = petName;

            dtpDOB.MaxDate = DateTime.Today;

            // 1. Setup Dropdowns (Just like the Add form!)
            cmbSpecies.Items.AddRange(new string[] { "Dog", "Cat", "Rabbit", "Other" });
            cmbGender.Items.AddRange(new string[] { "Male", "Female" });

            // 2. Load the Pet's Data
            LoadPetData();
        }

        private void LoadPetData()
        {
            DataTable dtPet = controllerObj.GetPetDetails(SelectedAnimalID);

            if (dtPet != null && dtPet.Rows.Count > 0)
            {
                DataRow row = dtPet.Rows[0];

                // 1. Load basic text fields
                txtName.Text = row["AnimalName"].ToString();
                txtBreed.Text = row["Breed"].ToString();

                // 2. Load Gender
                cmbGender.SelectedItem = row["Gender"].ToString();

                // 3. Load Species (Handle the "Other" case)
                string species = row["Species"].ToString();
                if (cmbSpecies.Items.Contains(species))
                {
                    cmbSpecies.SelectedItem = species;
                }
                else
                {
                    cmbSpecies.SelectedItem = "Other";
                    txtOtherSpecies.Text = species;
                    txtOtherSpecies.Enabled = true;
                }

                // 4. Load DOB safely (Check for NULL)
                if (row["EstimatedDOB"] != DBNull.Value)
                {
                    dtpDOB.Checked = true;
                    dtpDOB.Value = Convert.ToDateTime(row["EstimatedDOB"]);
                }
                else
                {
                    dtpDOB.Checked = false; // Grey it out if it was NULL
                }

                // 5. Load Weight safely (Check for NULL)
                if (row["LatestWeight"] != DBNull.Value)
                {
                    numWeight.Value = Convert.ToDecimal(row["LatestWeight"]);
                }
                else
                {
                    numWeight.Value = 0;
                }
            }
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            // 1. Basic Validation
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                cmbSpecies.SelectedIndex == -1 ||
                cmbGender.SelectedIndex == -1)
            {
                lblError.Text = "Please fill in the Name, Species, and Gender.";
                lblError.Visible = true;
                return;
            }

            // 2. Handle the "Other" Species logic
            string finalSpecies = cmbSpecies.SelectedItem.ToString();
            if (finalSpecies == "Other")
            {
                if (string.IsNullOrWhiteSpace(txtOtherSpecies.Text))
                {
                    lblError.Text = "Please specify the 'Other' species.";
                    lblError.Visible = true;
                    return;
                }
                finalSpecies = txtOtherSpecies.Text.Trim();
            }

            // 3. Extract the mandatory data
            string name = txtName.Text.Trim();
            string breed = txtBreed.Text.Trim();
            string gender = cmbGender.SelectedItem.ToString();

            // 4. Handle Optional DOB & Weight
            string dobValue = dtpDOB.Checked ? $"'{dtpDOB.Value.ToString("yyyy-MM-dd")}'" : "NULL";
            string weightValue = numWeight.Value > 0 ? numWeight.Value.ToString() : "NULL";

            // 5. Send to Database (Using the animalID we passed in the constructor)
            int result = controllerObj.UpdatePet(SelectedAnimalID, name, finalSpecies, breed, gender, dobValue, weightValue);

            // 6. Success/Fail Logic
            if (result > 0)
            {
                MessageBox.Show($"{name}'s information has been updated!", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Signals success to whatever opened this form
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update pet. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditPetClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
