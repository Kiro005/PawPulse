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
    public partial class AdoptionClientUC : UserControl
    {
        Controller controllerObj;
        private int ClientID;
        private string ClientName;
        public AdoptionClientUC(int clientID, string clientName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            ClientID = clientID;
            ClientName = clientName;

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            LoadAdoptionCenter();
        }

        public void LoadAdoptionCenter()
        {
            // 1. Clear both layout panels to prevent duplicating cards when the page refreshes
            flowAvailable.Controls.Clear();
            flowMyRequests.Controls.Clear();

            // ==========================================
            // TAB 1: LOAD AVAILABLE PETS
            // ==========================================
            DataTable dtAvailable = controllerObj.GetAvailablePets();

            if (dtAvailable != null)
            {
                foreach (DataRow row in dtAvailable.Rows)
                {
                    // Inside your foreach loop in LoadAdoptionCenter()
                    int animalId = Convert.ToInt32(row["AnimalID"]);
                    string name = row["AnimalName"].ToString();
                    string species = row["Species"].ToString();
                    string breed = row["Breed"].ToString();
                    string gender = row["Gender"].ToString();

                    // Handle possible nulls for numbers gracefully
                    int age = row["Age"] != DBNull.Value ? Convert.ToInt32(row["Age"]) : 0;
                    decimal weight = row["LatestWeight"] != DBNull.Value ? Convert.ToDecimal(row["LatestWeight"]) : 0;

                    // Create the card using your awesome new constructor!
                    AvailablePetCardUC card = new AvailablePetCardUC(animalId, ClientID, name, species, breed, gender, age, weight);

                    flowAvailable.Controls.Add(card);
                }
            }
            DataTable dtRequests = controllerObj.GetMyAdoptionRequests(ClientID);

            if (dtRequests != null)
            {
                foreach (DataRow row in dtRequests.Rows)
                {
                    int animalId = Convert.ToInt32(row["AnimalID"]);
                    string name = row["AnimalName"].ToString();
                    string species = row["Species"].ToString();
                    string breed = row["Breed"].ToString();
                    string gender = row["Gender"].ToString();
                    DateTime dateApplied = Convert.ToDateTime(row["ApplicationDate"]);
                    string status = row["AdoptionStatus"].ToString();

                    // Handle possible nulls for numbers safely
                    int age = 0;
                    if (row.Table.Columns.Contains("EstimatedDOB") && row["EstimatedDOB"] != DBNull.Value)
                    {
                        DateTime dob = Convert.ToDateTime(row["EstimatedDOB"]);
                        age = DateTime.Now.Year - dob.Year;
                        if (DateTime.Now.DayOfYear < dob.DayOfYear) age--;
                    }
                    else if (row.Table.Columns.Contains("Age") && row["Age"] != DBNull.Value)
                    {
                        age = Convert.ToInt32(row["Age"]);
                    }

                    decimal weight = row.Table.Columns.Contains("LatestWeight") && row["LatestWeight"] != DBNull.Value
                                     ? Convert.ToDecimal(row["LatestWeight"])
                                     : 0;

                    // Create the updated MyRequest card!
                    MyRequestCardUC reqCard = new MyRequestCardUC(animalId, ClientID, name, species, breed, gender, age, weight, dateApplied, status);
                    flowMyRequests.Controls.Add(reqCard);
                }
            }
        }
    }
}
