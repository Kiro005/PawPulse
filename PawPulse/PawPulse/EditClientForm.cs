using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DBapplication;

namespace PawPulse
{
    public partial class EditClientForm : Form
    {
        Controller controllerObj;
        private int clientId;

        public EditClientForm(int id)
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.clientId = id;

            SetupCombo();
            LoadClientData();

            // Set Placeholders
            SetPlaceholder(txtStreet, "Street Name...");
            SetPlaceholder(txtBuilding, "Building Number...");
        }

        private void LoadClientData()
        {
            // Fetch client from 'Client' table
            DataTable dt = controllerObj.GetClientById(clientId);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Assign data and ensure text color is black
                txtFName.Text = row["FirstName"].ToString();
                txtFName.ForeColor = Color.Black;

                txtLName.Text = row["LastName"].ToString();
                txtLName.ForeColor = Color.Black;

                txtphone.Text = row["Phone"].ToString();
                txtphone.ForeColor = Color.Black;

                txtEmail.Text = row["Email"].ToString();
                txtEmail.ForeColor = Color.Black;

                // Handle City selection
                string city = row["City"].ToString();
                if (cmbCity.Items.Contains(city))
                {
                    cmbCity.SelectedItem = city;
                    cmbCity.ForeColor = Color.Black;
                }

                txtStreet.Text = row["Street"].ToString();
                txtStreet.ForeColor = Color.Black;

                txtBuilding.Text = row["BuildingNumber"].ToString();
                txtBuilding.ForeColor = Color.Black;
            }
            else
            {
                MessageBox.Show($"No data found for Client ID: {clientId}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            // 1. Comprehensive Validation (Similar to Employee logic)
            if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                string.IsNullOrWhiteSpace(txtLName.Text) ||
                string.IsNullOrWhiteSpace(txtphone.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbCity.SelectedIndex <= 0) // Ensures 'Select City...' is not chosen
            {
                MessageBox.Show("Please, Fill all the required fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Confirmation before saving
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to save these changes?",
                                               "Confirm Update",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    // 3. Execute update via controller
                    int result = controllerObj.UpdateClient(
                        clientId,
                        txtFName.Text,
                        txtLName.Text,
                        txtphone.Text,
                        txtEmail.Text,
                        cmbCity.SelectedItem.ToString(),
                        txtStreet.Text,
                        txtBuilding.Text
                    );

                    if (result > 0)
                    {
                        MessageBox.Show("Client data updated successfully!", "Success");
                        this.DialogResult = DialogResult.OK; // Trigger grid refresh in parent form
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No changes were applied.", "Update Notice");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "System Error");
                }
            }
        }

        // --- Windows API for Placeholders ---
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            SendMessage(txt.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        private void SetupCombo()
        {
            if (cmbCity.Items.Count == 0)
            {
                cmbCity.Items.AddRange(new string[] { "Select City...", "Cairo", "Giza", "Alexandria" });
            }
            cmbCity.SelectedIndex = 0;
            cmbCity.ForeColor = Color.Gray;
        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dynamic color change based on selection
            cmbCity.ForeColor = (cmbCity.SelectedIndex == 0) ? Color.Gray : Color.Black;
        }
    }
}