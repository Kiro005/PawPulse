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
    public partial class PetCardUC : UserControl
    {
        Controller controllerObj;
        public int AnimalID { get; private set; }
        public PetCardUC(int id, string name, string species, string breed, int age, decimal weight)
        {
            InitializeComponent();
            controllerObj = new Controller();
            picPetIcon.SizeMode = PictureBoxSizeMode.Zoom;
            LoadPetData(id, name, species, breed, age, weight);
        }

        public void LoadPetData(int id, string name, string species, string breed, int age, decimal weight)
        {
            AnimalID = id;
            string stringAge = age >= 0 ? $"{age} Years Old" : "Age Unknown";
            string stringWeight = weight > 0 ? $"{weight} kg" : "Weight Unknown";
            breed = string.IsNullOrEmpty(breed) ? "Breed Unknown" : breed;

            // Fill in the text labels
            lblName.Text = name;
            lblBreed.Text = $"{species} - {breed}";
            lblStats.Text = $"{stringAge}  |  {stringWeight}";

            // THE MAGIC: Decide the image based on the species text
            // We use .ToLower() just in case the database says "Dog", "DOG", or "dog"
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
                    // Always have a fallback icon just in case they register an iguana!
                    picPetIcon.Image = Properties.Resources.defaultIcon;
                    break;
            }
        }

        private void btnMedical_Click(object sender, EventArgs e)
        {
            new MedicalHistoryClientForm(AnimalID, lblName.Text).ShowDialog();
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            new AddAppointmentClient(AnimalID, lblName.Text).ShowDialog();
        }

        private void btnUpdatePet_Click(object sender, EventArgs e)
        {
            EditPetClientForm editForm = new EditPetClientForm(AnimalID, lblName.Text);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                // 1. Start looking at the container this PetCard is sitting inside (the FlowLayoutPanel)
                Control currentParent = this.Parent;

                // 2. Keep climbing up the UI tree until we find the AnimalUC
                while (currentParent != null && !(currentParent is AnimalUC))
                {
                    currentParent = currentParent.Parent;
                }

                // 3. Once we find it, tell it to refresh!
                if (currentParent is AnimalUC myAnimalUC)
                {
                    myAnimalUC.LoadPets(); // Calls your method to wipe and redraw the cards!
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Confirm they actually want to do this!
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to remove this pet from your profile?",
                "Confirm Removal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // 2. Call the Soft Delete method
                int result = controllerObj.RemovePetFromClient(AnimalID);

                if (result > 0)
                {
                    MessageBox.Show("Pet removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. The Refresh Trick! Climb up to AnimalUC and reload!
                    Control currentParent = this.Parent;

                    while (currentParent != null && !(currentParent is AnimalUC))
                    {
                        currentParent = currentParent.Parent;
                    }

                    if (currentParent is AnimalUC myAnimalUC)
                    {
                        myAnimalUC.LoadPets(); // The pet is gone from the UI instantly!
                    }
                }
                else
                {
                    MessageBox.Show("Failed to remove pet. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
