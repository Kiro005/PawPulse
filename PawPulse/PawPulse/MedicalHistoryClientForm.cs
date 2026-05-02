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
    public partial class MedicalHistoryClientForm : Form
    {
        Controller controllerObj;
        public MedicalHistoryClientForm(int animalID, string petName)
        {
            InitializeComponent();
            controllerObj = new Controller();

            lblPetName.Text = $"{petName}'s Medical History";   

            LoadAllMedicalData(animalID);
        }

        private void LoadAllMedicalData(int animalID)
        {
            // 1. Load Visits
            dgvVisits.DataSource = controllerObj.GetPetVisits(animalID);
            StyleDataGridView(dgvVisits); // Apply styling to Visits DataGridView

            // 2. Load Prescriptions
            dgvPrescriptions.DataSource = controllerObj.GetPetPrescriptions(animalID);
            StyleDataGridView(dgvPrescriptions); // Apply styling to Prescriptions DataGridView

            // 3. Load Vaccines
            dgvVaccines.DataSource = controllerObj.GetPetVaccines(animalID);
            StyleDataGridView(dgvVaccines); // Apply styling to Vaccines DataGridView
            // 4. Load Lab Tests
            dgvLabTests.DataSource = controllerObj.GetPetLabTests(animalID);
            StyleDataGridView(dgvLabTests); // Apply styling to Lab Tests DataGridView
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            // Turn off default Windows styling so our colors work
            dgv.EnableHeadersVisualStyles = false;

            // Header colors
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 40, 55); // Your dark blue
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Make the rows a little taller so the text has room to breathe!
            dgv.RowTemplate.Height = 35;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVisits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
