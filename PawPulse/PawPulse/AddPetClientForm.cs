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
using System.Xml.Linq;

namespace PawPulse
{
    public partial class AddPetClientForm : Form
    {
        Controller controllerObj;
        int ClientID;
        public AddPetClientForm(int clientID)
        {
            InitializeComponent();
            controllerObj = new Controller();
            ClientID = clientID;

            lblError.Visible = false;

            cmbSpecies.Items.Clear(); // Clears any accidental designer items
            cmbSpecies.Items.AddRange(new string[] { "Dog", "Cat", "Rabbit", "Other" });
            cmbSpecies.SelectedIndex = -1; // Leaves it blank so they are forced to choose

            // 2. Populate the Gender Dropdown
            cmbGender.Items.Clear();
            cmbGender.Items.AddRange(new string[] { "Male", "Female" });
            cmbGender.SelectedIndex = -1; // Leaves it blank
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cmbSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpecies.SelectedItem != null && cmbSpecies.SelectedItem.ToString() == "Other")
            {
                txtOtherSpecies.Enabled = true;
                label5.Enabled = true;
                txtOtherSpecies.Focus(); // Automatically put their text cursor in the box!
            }
            else
            {
                txtOtherSpecies.Enabled = false;
                label5.Enabled = false;
                txtOtherSpecies.Clear(); // Wipe it clean if they change their mind
            }
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
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

            // 4. Handle Optional DOB (Check if the box is checked)
            string dobValue = dtpDOB.Checked ? $"'{dtpDOB.Value.ToString("yyyy-MM-dd")}'" : "NULL";

            // 5. Handle Optional Weight (If it's 0, assume they don't know it)
            string weightValue = numWeight.Value > 0 ? numWeight.Value.ToString() : "NULL";

            // 6. Send to Database
            int result = controllerObj.AddNewPet(name, finalSpecies, breed, gender, dobValue, weightValue, ClientID);

            // 7. Success/Fail Logic
            if (result > 0)
            {
                MessageBox.Show($"{name} has been added to your family!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add pet. Please try again.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        
    }
}
