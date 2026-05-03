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
    public partial class ShelterManageKennelsUC : UserControl
    {
        // 1. Instantiate your Controller
        Controller controllerObj = new Controller();

        public ShelterManageKennelsUC()
        {
            InitializeComponent();

            UIThemeManager.ApplyTheme(this);

        }

        private void ShelterManageKennelsUC_Load(object sender, EventArgs e)
        {
            // Populate the static status dropdown on load
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Needs Cleaning");

            // Fetch the database data
            RefreshData();
        }

        // Helper method to reload both the grid and the dropdown so it's always up to date
        public void RefreshData()
        {
            // 1. Fetch the data
            DataTable dtKennels = controllerObj.GetAllKennelsWithAnimals();

            // 2. Loop through the rows to make the text more human-friendly before displaying it
            for (int i = 0; i < dtKennels.Rows.Count; i++)
            {
                string status = dtKennels.Rows[i]["Status"].ToString();
                string occupiedBy = dtKennels.Rows[i]["Occupied By"].ToString();

                if (status == "Available" && occupiedBy != "Empty")
                {
                    dtKennels.Rows[i]["Status"] = "Partially Occupied";
                }
            }

            dgvKennels.DataSource = dtKennels;

            // 4. Load Dropdown with animals needing a home
            DataTable dtAnimals = controllerObj.GetUnassignedShelterAnimals();
            cmbUnassignedAnimals.DataSource = dtAnimals;
            cmbUnassignedAnimals.DisplayMember = "AnimalName";
            cmbUnassignedAnimals.ValueMember = "AnimalID";
            cmbUnassignedAnimals.SelectedIndex = -1;
        }

        // ASSIGN BUTTON
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (dgvKennels.SelectedRows.Count == 0 && dgvKennels.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a Kennel from the grid.");
                return;
            }
            if (cmbUnassignedAnimals.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an Animal from the dropdown.");
                return;
            }

            int rowIndex = dgvKennels.CurrentCell.RowIndex;
            int kennelId = Convert.ToInt32(dgvKennels.Rows[rowIndex].Cells["KennelID"].Value);
            int animalId = Convert.ToInt32(cmbUnassignedAnimals.SelectedValue);

            // LOGIC CHECK 1: Ensure the kennel is clean!
            string currentStatus = dgvKennels.Rows[rowIndex].Cells["Status"].Value.ToString();
            if (currentStatus == "Needs Cleaning")
            {
                MessageBox.Show("This kennel needs cleaning! Please clean it and update its status to 'Available' before assigning an animal.");
                return;
            }

            // LOGIC CHECK 2: Make sure the kennel actually has space left
            if (controllerObj.IsKennelFull(kennelId))
            {
                MessageBox.Show("This kennel has reached its maximum capacity! Please select another one.");
                return;
            }

            // Execute the assignment
            if (controllerObj.AssignAnimalToKennel(animalId, kennelId) > 0)
            {
                MessageBox.Show("Animal assigned to kennel successfully.");
                RefreshData(); // Immediately update the UI
            }
        }

        // REMOVE BUTTON
        // REMOVE BUTTON
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvKennels.SelectedRows.Count == 0 && dgvKennels.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a row from the grid to remove an animal.");
                return;
            }

            int rowIndex = dgvKennels.CurrentCell.RowIndex;
            string occupiedBy = dgvKennels.Rows[rowIndex].Cells["Occupied By"].Value.ToString();

            if (occupiedBy == "Empty" || string.IsNullOrWhiteSpace(occupiedBy))
            {
                MessageBox.Show("There is no animal in this slot to remove.");
                return;
            }

            // Grab BOTH IDs from the clicked row
            int kennelId = Convert.ToInt32(dgvKennels.Rows[rowIndex].Cells["KennelID"].Value);
            int animalId = Convert.ToInt32(dgvKennels.Rows[rowIndex].Cells["AnimalID"].Value);

            // Call the controller using both IDs
            if (controllerObj.RemoveAnimalFromKennel(animalId, kennelId) > 0)
            {
                MessageBox.Show($"Successfully removed {occupiedBy} from the kennel.");
                RefreshData(); // Immediately update the UI
            }
            else
            {
                MessageBox.Show("Error: Could not remove the animal. Check database connection.");
            }
        }

        // UPDATE STATUS BUTTON
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvKennels.SelectedRows.Count == 0 && dgvKennels.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select a Kennel from the grid to update.");
                return;
            }
            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a status (Available / Needs Cleaning).");
                return;
            }

            int rowIndex = dgvKennels.CurrentCell.RowIndex;
            int kennelId = Convert.ToInt32(dgvKennels.Rows[rowIndex].Cells["KennelID"].Value);
            string newStatus = cmbStatus.Text;
            string currentStatus = dgvKennels.Rows[rowIndex].Cells["Status"].Value.ToString();

            // Prevent marking a dirty kennel as Available without cleaning it (Optional, but good practice)
            // You can remove this if you want staff to just toggle it freely.

            if (controllerObj.UpdateKennelStatus(kennelId, newStatus) > 0)
            {
                MessageBox.Show("Kennel status updated.");
                RefreshData();
                cmbStatus.SelectedIndex = -1;
            }
        }

        // Keep this so the Designer doesn't break, but it can stay empty
        private void cmbUnassignedAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}