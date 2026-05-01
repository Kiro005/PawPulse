using DBapplication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PawPulse
{
    public partial class MyRequestCardUC : UserControl
    {
        private Controller controllerObj;
        public int AnimalID { get; private set; }
        public int ClientID { get; private set; }
        public MyRequestCardUC(int animalId, int clientId, string name, string species, string breed, string gender, int age, decimal weight, DateTime dateApplied, string status)
        {
            InitializeComponent();
            controllerObj = new Controller();
            picPetIcon.SizeMode = PictureBoxSizeMode.Zoom;

            LoadRequestData(animalId, clientId, name, species, breed, gender, age, weight, dateApplied, status);
        }

        private void LoadRequestData(int animalId, int clientId, string name, string species, string breed, string gender, int age, decimal weight, DateTime dateApplied, string status)
        {
            AnimalID = animalId;
            ClientID = clientId;

            // 1. Set the basic text safely
            string stringAge = age > 0 ? $"{age} Years Old" : "Age Unknown";
            string stringWeight = weight > 0 ? $"{weight} kg" : "Weight Unknown";
            breed = string.IsNullOrEmpty(breed) ? "Breed Unknown" : breed;
            gender = string.IsNullOrEmpty(gender) ? "Gender Unknown" : gender;

            lblName.Text = name;
            lblDetails1.Text = $"{species} - {breed} - {gender}"; // Update with your actual label names!
            lblDetails2.Text = $"{stringAge}  |  {stringWeight}";
            lblDate.Text = $"Application Date: {dateApplied.ToString("MMM dd, yyyy")}";
            lblStatus.Text = $"Status: {status}";

            // 2. THE MAGIC: Status Colors & Cancel Button Logic
            switch (status.ToLower())
            {
                case "approved":
                    lblStatus.ForeColor = Color.SeaGreen;
                    btnCancel.Visible = false; // Hide the cancel button!
                    break;
                case "rejected":
                    lblStatus.ForeColor = Color.Crimson;
                    btnCancel.Visible = false; // Hide the cancel button!
                    break;
                case "pending":
                default:
                    lblStatus.ForeColor = Color.DarkOrange;
                    btnCancel.Visible = true; // Keep it visible so they can cancel
                    break;
            }

            // 3. Set the pet icon
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
                default:
                    picPetIcon.Image = Properties.Resources.defaultIcon;
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to cancel your adoption request for {lblName.Text}?",
                "Cancel Request",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                // You will need a method in your Controller to delete or update the request status
                int result = controllerObj.CancelAdoptionRequest(AnimalID, ClientID);

                if (result > 0)
                {
                    MessageBox.Show("Request cancelled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh Trick to reload the tab!
                    Control currentParent = this.Parent;
                    while (currentParent != null && !(currentParent is AdoptionClientUC))
                    {
                        currentParent = currentParent.Parent;
                    }

                    if (currentParent is AdoptionClientUC myAdoptionCenter)
                    {
                        myAdoptionCenter.LoadAdoptionCenter();
                    }
                }
                else
                {
                    MessageBox.Show("Failed to cancel request.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMedical_Click(object sender, EventArgs e)
        {
            new MedicalHistoryClientForm(AnimalID, lblName.Text).ShowDialog();
        }
    }
}
