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
    public partial class AvailablePetCardUC : UserControl
    {
        private Controller controllerObj;
        public int AnimalID { get; private set; }
        public int ClientID { get; private set; }
        public AvailablePetCardUC(int animalId, int clientId, string name, string species, string breed, string gender, int age, decimal weight)
        {
            InitializeComponent();
            controllerObj = new Controller();
            picPetIcon.SizeMode = PictureBoxSizeMode.Zoom;

            LoadPetData(animalId, clientId, name, species, breed, gender, age, weight);
        }

        public void LoadPetData(int animalId, int clientId, string name, string species, string breed, string gender, int age, decimal weight)
        {
            AnimalID = animalId;
            ClientID = clientId;

            // Format the strings safely just like in PetCardUC
            string stringAge = age > 0 ? $"{age} Years Old" : "Age Unknown";
            string stringWeight = weight > 0 ? $"{weight} kg" : "Weight Unknown";
            breed = string.IsNullOrEmpty(breed) ? "Breed Unknown" : breed;
            gender = string.IsNullOrEmpty(gender) ? "Gender Unknown" : gender;

            // Fill in the text labels (Make sure these match your designer names!)
            lblName.Text = name;
            lblDetails1.Text = $"{species} - {breed} - {gender}";
            lblDetails2.Text = $"{stringAge}  |  {stringWeight}";

            // THE MAGIC: Decide the image based on the species text
            switch (species.ToLower())
            {
                case "dog":
                    picPetIcon.Image = Properties.Resources.DogIcon;
                    break;
                case "cat":
                    picPetIcon.Image = Properties.Resources.CatIcon;
                    break;
                case "rabbit":
                    picPetIcon.Image = Properties.Resources.RabbitIcon;
                    break;
                //case "bird":
                //    picPetIcon.Image = Properties.Resources.BirdIcon;
                //    break;
                default:
                    // Fallback icon
                    picPetIcon.Image = Properties.Resources.defaultIcon;
                    break;
            }
        }

        private void AvailablePetCardUC_Load(object sender, EventArgs e)
        {

        }

        private void btnAdopt_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                 $"Are you sure you want to submit an adoption request for {lblName.Text}?",
                 "Confirm Adoption",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // 2. Execute the database query
                int result = controllerObj.SubmitAdoptionRequest(AnimalID, ClientID);

                if (result > 0)
                {
                    MessageBox.Show("Adoption request submitted successfully! It is now pending review.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. The Refresh Trick! Start looking at the container this card is sitting inside
                    Control currentParent = this.Parent;

                    // Keep climbing up the UI tree until we find the main AdoptionCenterUC
                    // (Note: Replace 'AdoptionCenterUC' with the actual name of your main Adoption UserControl)
                    while (currentParent != null && !(currentParent is AdoptionClientUC))
                    {
                        currentParent = currentParent.Parent;
                    }

                    // Once we find it, tell it to refresh so the pet moves to Tab 2!
                    if (currentParent is AdoptionClientUC myAdoptionCenter)
                    {
                        myAdoptionCenter.LoadAdoptionCenter();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to submit request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMedical_Click(object sender, EventArgs e)
        {
            new MedicalHistoryClientForm(AnimalID, lblName.Text).ShowDialog();
        }
    }
}
