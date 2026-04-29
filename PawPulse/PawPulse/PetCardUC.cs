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
        public int AnimalID { get; private set; }
        public PetCardUC(int id, string name, string species, string breed, int age, decimal weight)
        {
            InitializeComponent();
            picPetIcon.SizeMode = PictureBoxSizeMode.Zoom;
            LoadPetData(id, name, species, breed, age, weight);
        }

        public void LoadPetData(int id, string name, string species, string breed, int age, decimal weight)
        {
            AnimalID = id;

            // Fill in the text labels
            lblName.Text = name;
            lblBreed.Text = $"{species} - {breed}";
            lblStats.Text = $"{age} Years Old  |  {weight} kg";

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
    }
}
