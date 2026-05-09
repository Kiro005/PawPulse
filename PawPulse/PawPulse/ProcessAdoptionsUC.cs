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
            // Ensure a row is selected in the grid
            if (dgvPendingAdoptions.SelectedRows.Count == 0 && dgvPendingAdoptions.SelectedCells.Count == 0)
            {
                MessageBox.Show("Please select an adoption application to approve.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Grab the hidden IDs from the selected row in your grid
            int rowIndex = dgvPendingAdoptions.CurrentCell.RowIndex;

            int adoptionId = Convert.ToInt32(dgvPendingAdoptions.Rows[rowIndex].Cells["AdoptionID"].Value);
            int clientId = Convert.ToInt32(dgvPendingAdoptions.Rows[rowIndex].Cells["ClientID"].Value);
            int animalId = Convert.ToInt32(dgvPendingAdoptions.Rows[rowIndex].Cells["AnimalID"].Value);
            string species = dgvPendingAdoptions.Rows[rowIndex].Cells["Species"].Value.ToString();

            // Confirm the action with the staff member
            DialogResult confirm = MessageBox.Show($"Approve adoption and generate a bill for this {species}?", "Confirm Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Trigger the master database transaction we wrote in Step 1
                if (controllerObj.ApproveAdoptionAndBillClient(adoptionId, clientId, animalId, species))
                {
                    MessageBox.Show("Adoption approved! Ownership transferred and the fee has been added to the client's billing account.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the grid so the approved animal disappears from the pending list
                    RefreshGrid();
                }
                else
                {
                    MessageBox.Show("There was an error processing the adoption.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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