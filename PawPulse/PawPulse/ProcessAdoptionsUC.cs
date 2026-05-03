using DBapplication;
using System;
using System.Data;
using System.Windows.Forms;

namespace PawPulse
{
    public partial class ProcessAdoptionsUC : UserControl
    {
        Controller controllerObj = new Controller();

        // For testing, we use a placeholder Staff ID (e.g., 4)
        // In the final version, pass the actual logged-in EmployeeID here
        int currentStaffId;

        public ProcessAdoptionsUC(int staffId)
        {
            InitializeComponent();

            UIThemeManager.ApplyTheme(this);

            currentStaffId = staffId;
        }

        private void ProcessAdoptionsUC_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            // Fills the grid with pending applications from the database
            dgvPendingAdoptions.DataSource = controllerObj.GetPendingAdoptions();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvPendingAdoptions.SelectedRows.Count == 0 && dgvPendingAdoptions.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select an application from the grid first.");
                return;
            }

            int rowIndex = dgvPendingAdoptions.CurrentCell.RowIndex;

            // Collect the IDs needed for the transaction
            int adoptionId = Convert.ToInt32(dgvPendingAdoptions.Rows[rowIndex].Cells["AdoptionID"].Value);
            int animalId = Convert.ToInt32(dgvPendingAdoptions.Rows[rowIndex].Cells["AnimalID"].Value);
            int clientId = Convert.ToInt32(dgvPendingAdoptions.Rows[rowIndex].Cells["ClientID"].Value);
            string animalName = dgvPendingAdoptions.Rows[rowIndex].Cells["AnimalName"].Value.ToString();

            DialogResult confirm = MessageBox.Show($"Approve adoption for {animalName}?", "Confirm", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                // This call updates the Adoption, the Animal, and the Kennel in one go
                if (controllerObj.ApproveAdoption(adoptionId, animalId, clientId, currentStaffId) > 0)
                {
                    MessageBox.Show("Adoption Approved! The animal is now owned by the client and the kennel is marked for cleaning.");
                    RefreshGrid();
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvPendingAdoptions.SelectedRows.Count == 0 && dgvPendingAdoptions.SelectedCells.Count == 0) return;

            int rowIndex = dgvPendingAdoptions.CurrentCell.RowIndex;
            int adoptionId = Convert.ToInt32(dgvPendingAdoptions.Rows[rowIndex].Cells["AdoptionID"].Value);

            if (controllerObj.RejectAdoption(adoptionId, currentStaffId) > 0)
            {
                MessageBox.Show("Application Rejected.");
                RefreshGrid();
            }
        }
    }
}