using System;
using System.Data;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class HealthClearanceShelterStaffUC : UserControl
    {
        Controller controllerObj;

        public HealthClearanceShelterStaffUC()
        {
            InitializeComponent();
            controllerObj = new Controller();
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvClearance.DataSource = controllerObj.GetShelterAnimals();
        }

        //private void btnIssueClearance_Click(object sender, EventArgs e)
        //{
        //    if (dgvClearance.SelectedRows.Count == 0 && dgvClearance.SelectedCells.Count == 0)
        //    {
        //        MessageBox.Show("Please select an animal to clear.");
        //        return;
        //    }

        //    int rowIndex = dgvClearance.CurrentCell.RowIndex;
        //    int animalId = Convert.ToInt32(dgvClearance.Rows[rowIndex].Cells["AnimalID"].Value);
        //    string animalName = dgvClearance.Rows[rowIndex].Cells["AnimalName"].Value.ToString();
        //    string latestDiagnosis = dgvClearance.Rows[rowIndex].Cells["LatestDiagnosis"].Value.ToString();

        //    if (latestDiagnosis == "Cleared for Adoption")
        //    {
        //        MessageBox.Show("This animal has already been cleared for adoption.");
        //        return;
        //    }

        //    DialogResult confirm = MessageBox.Show($"Issue health clearance for {animalName}?", "Confirm Clearance", MessageBoxButtons.YesNo);

        //    if (confirm == DialogResult.Yes)
        //    {
        //        if (controllerObj.IssueClearance(animalId))
        //        {
        //            MessageBox.Show($"{animalName} is now medically cleared and ready for adoption.");
        //            RefreshGrid();
        //        }
        //        else
        //        {
        //            MessageBox.Show("System encountered an error issuing the clearance.");
        //        }
        //    }
        //}

        //private void btnRefresh2_Click(object sender, EventArgs e)
        //{
        //    RefreshGrid();
        //}

      
    }
}