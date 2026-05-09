using System;
using System.Data;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class ManageAdoptionFeesShelterUC : UserControl
    {
        Controller controllerObj;

        public ManageAdoptionFeesShelterUC()
        {
            InitializeComponent();

            UIThemeManager.ApplyTheme(this);

            controllerObj = new Controller();

            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cmbSpecies.Items.Clear();
            DataTable speciesData = controllerObj.GetDistinctSpecies();

            if (speciesData != null)
            {
                foreach (DataRow row in speciesData.Rows)
                {
                    cmbSpecies.Items.Add(row["Species"].ToString());
                }
            }

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dgvFees.DataSource = controllerObj.GetAdoptionSettings();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbSpecies.Text) || string.IsNullOrWhiteSpace(txtFees.Text))
            {
                MessageBox.Show("Please enter both a species and a fee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtFees.Text, out decimal fee))
            {
                MessageBox.Show("Please enter a valid number for the fee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fee < 0)
            {
                MessageBox.Show("Adoption fees cannot be negative. Please enter a valid amount.", "Invalid Fee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string species = cmbSpecies.Text.Trim();

            if (controllerObj.SetAdoptionFee(species, fee) > 0)
            {
                MessageBox.Show($"Fee for {species} successfully set to {fee:C}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid();

                cmbSpecies.SelectedIndex = -1;
                txtFees.Clear();
            }
            else
            {
                MessageBox.Show("Failed to save the adoption fee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbSpecies.SelectedIndex = -1;
            txtFees.Clear();
        }

        private void dgvFees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFees.Rows[e.RowIndex];
                cmbSpecies.Text = row.Cells["Species"].Value.ToString();
                txtFees.Text = row.Cells["BaseFee"].Value.ToString();
            }

        }

        private void ManageAdoptionFeesShelterUC_Load(object sender, EventArgs e)
        {

        }
    }
}