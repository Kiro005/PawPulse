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
    public partial class AddAppointmentClient : Form
    {
        Controller controllerObj;
        private int AnimalID;
        public AddAppointmentClient(int animalID, string petName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            AnimalID = animalID;
            lblPetName.Text = $"For {petName}";
            dateTimePicker1.MinDate = DateTime.Now;

            LoadVets();
        }

        private void LoadVets()
        {
            DataTable dtVets = controllerObj.GetActiveVets();

            if (dtVets != null && dtVets.Rows.Count > 0)
            {
                // Bind the data to the dropdown
                cmpDoctor.DataSource = dtVets;

                // This is what the user actually reads in the dropdown
                cmpDoctor.DisplayMember = "VetName";

                // This is the hidden ID we will save to the APPOINTMENT table later
                cmpDoctor.ValueMember = "EmployeeID";

                // Optional UX tweak: Unselect everything so it's blank when they first open it, 
                // forcing them to make a conscious choice.
                cmpDoctor.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("No active veterinarians found in the system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdateAvailableTimes()
        {
            // Don't run if a vet isn't selected yet (prevents crashes when the form is just loading)
            if (cmpDoctor.SelectedIndex == -1 || cmpDoctor.SelectedValue == null)
            {
                AvailableTime.DataSource = null;
                AvailableTime.Enabled = false;
                return;
            }

            // 1. Safely grab the Vet ID and Date
            int vetID;
            bool isParsed = int.TryParse(cmpDoctor.SelectedValue.ToString(), out vetID);
            if (!isParsed) return;

            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // 2. Create your standard clinic hours
            List<string> allPossibleTimes = new List<string>
        {
            "09:00:00", "10:00:00", "11:00:00", "12:00:00",
            "13:00:00", "14:00:00", "15:00:00", "16:00:00", "17:00:00"
        };

            List<string> availableTimes = new List<string>();

            // 2.5 THE TIME TRAVEL FIX! 
            // Check if the user selected TODAY'S date
            bool isToday = dateTimePicker1.Value.Date == DateTime.Today;
            TimeSpan currentTime = DateTime.Now.TimeOfDay;

            foreach (string timeStr in allPossibleTimes)
            {
                // Convert our string ("13:00:00") into a TimeSpan so we can do math on it
                TimeSpan slotTime = TimeSpan.Parse(timeStr);

                if (isToday)
                {
                    // Only add the time slot to the list if it is in the future!
                    if (slotTime > currentTime)
                    {
                        availableTimes.Add(timeStr);
                    }
                }
                else
                {
                    // If it's a future date, they can book any open hour
                    availableTimes.Add(timeStr);
                }
            }

            // 3. Ask the database what is already booked
            DataTable dtBooked = controllerObj.GetBookedTimes(vetID, selectedDate);

            // 4. Remove the booked times from our standard list
            if (dtBooked != null)
            {
                foreach (DataRow row in dtBooked.Rows)
                {
                    // SQL 'TIME' datatype usually comes back as a TimeSpan in C#
                    TimeSpan bookedTimeSpan = (TimeSpan)row["AppTime"];
                    string bookedTimeStr = bookedTimeSpan.ToString(@"hh\:mm\:ss");

                    if (availableTimes.Contains(bookedTimeStr))
                    {
                        availableTimes.Remove(bookedTimeStr);
                    }
                }
            }

            // 5. Update the Dropdown!
            AvailableTime.DataSource = availableTimes;

            if (availableTimes.Count > 0)
            {
                AvailableTime.Enabled = true;
                AvailableTime.SelectedIndex = -1; // Keep it blank initially so they have to choose
            }
            else
            {
                // If they removed all the items, the vet is full (or the day is over!)
                AvailableTime.DataSource = null; // Clear out the datasource so we can edit the text safely
                AvailableTime.Enabled = false;
                AvailableTime.Text = "Unavailable";
            }
        }
        private void AddAppointmentClient_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            if (cmpDoctor.SelectedIndex == -1)
            {
                lblError.Text = "Please select a veterinarian.";
                lblError.Visible = true;
                return;
            }

            if (AvailableTime.SelectedIndex == -1 || AvailableTime.Text == "Fully Booked")
            {
                lblError.Text = "Please select a valid time slot.";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                lblError.Text = "Please provide a reason for the visit.";
                lblError.Visible = true;
                return;
            }

            // 2. Extract the data
            int vetID = Convert.ToInt32(cmpDoctor.SelectedValue);
            string selectedDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string selectedTime = AvailableTime.SelectedItem.ToString();
            string purpose = textBox1.Text.Trim();

            // 3. Send to Database
            int result = controllerObj.BookAppointment(selectedDate, selectedTime, purpose, AnimalID, vetID);

            // 4. Handle the result
            if (result > 0)
            {
                MessageBox.Show("Appointment booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the pop-up and return to the dashboard
            }
        }

        private void cmpDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAvailableTimes();
            lblError.Visible = false; // Hide any previous error messages when they change the vet
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            UpdateAvailableTimes();
            lblError.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblError.Visible = false; // Hide any previous error messages when they start typing a reason
        }

        private void AvailableTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblError.Visible = false; // Hide any previous error messages when they change the time
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
