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
    public partial class AnimalUC : UserControl
    {
        int ClientID;
        string ClientName;
        Controller ControllerObj;
        public AnimalUC(int clientID, string clientName)
        {
            InitializeComponent();
            ControllerObj = new Controller();
            this.ClientID = clientID;
            this.ClientName = clientName;

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            flowLayoutPanel1.Controls.Clear();
            DataTable pets = ControllerObj.GetClientPets(ClientID);

            if (pets != null && pets.Rows.Count > 0)
            {
                foreach (DataRow row in pets.Rows)
                {
                    int petID = Convert.ToInt32(row["AnimalID"]);
                    string petName = row["AnimalName"].ToString();
                    string petSpecie = row["Species"].ToString();
                    string petBreed = row["Breed"].ToString();
                    int petAge = row["Age"] != DBNull.Value ? Convert.ToInt32(row["Age"]) : 0;
                    decimal weight = row["LatestWeight"] != DBNull.Value ? Convert.ToDecimal(row["LatestWeight"]) : 0m;

                    PetCardUC petCard = new PetCardUC(petID, petName, petSpecie, petBreed, petAge, weight);
                    flowLayoutPanel1.Controls.Add(petCard);
                }
            }
        }

        public void LoadPets()
        {
            // 1. Clear the old cards first!
            flowLayoutPanel1.Controls.Clear();

            // 2. Fetch the updated list of pets from the database
            DataTable dtPets = ControllerObj.GetClientPets(ClientID);

            // 3. Loop through and create the new cards
            if (dtPets != null)
            {
                foreach (DataRow row in dtPets.Rows)
                {
                    int petID = Convert.ToInt32(row["AnimalID"]);
                    string petName = row["AnimalName"].ToString();
                    string petSpecie = row["Species"].ToString();
                    string petBreed = row["Breed"].ToString();
                    int petAge = row["Age"] != DBNull.Value ? Convert.ToInt32(row["Age"]) : 0;
                    decimal weight = row["LatestWeight"] != DBNull.Value ? Convert.ToDecimal(row["LatestWeight"]) : 0m;

                    PetCardUC petCard = new PetCardUC(petID, petName, petSpecie, petBreed, petAge, weight);
                    flowLayoutPanel1.Controls.Add(petCard);
                }
            }
        }
        private void AnimalUC_Load(object sender, EventArgs e)
        {

        }

        private void btnAddPet_Click(object sender, EventArgs e)
        {
            AddPetClientForm addForm = new AddPetClientForm(ClientID);

            // 2. Open it, and wait for it to close. If it reports "OK" (success)...
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // 3. ...Refresh the layout!
                LoadPets();
            }
        }
    }
}
