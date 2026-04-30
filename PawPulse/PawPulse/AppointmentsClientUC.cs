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
    public partial class AppointmentsClientUC : UserControl
    {
        int ClientID;
        string ClientName;
        Controller controllerObj;
        public AppointmentsClientUC(int clientID, string clientName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.ClientID = clientID;
            this.ClientName = clientName;

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            //StyleDataGrid();

            cmbFilterStatus.Items.Clear();
            cmbFilterStatus.Items.AddRange(new string[] { "All", "Scheduled", "Completed", "Cancelled" });

            // Set it to "All" by default so the grid shows everything initially
            cmbFilterStatus.SelectedIndex = 0;

            LoadAppointments();

        }
        public void LoadAppointments()
        {
            DataTable dtApps = controllerObj.GetClientAppointments(ClientID);
            dataGridView1.DataSource = dtApps;

            // Hide the ID column so the UI stays clean
            if (dataGridView1.Columns["AppointmentID"] != null)
            {
                dataGridView1.Columns["AppointmentID"].Visible = false;
            }

            // Optional: Make it read-only and select whole rows instead of single cells
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Make sure they actually clicked a row
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 2. Extract the Status and ID from the selected row
                string currentStatus = dataGridView1.SelectedRows[0].Cells["Status"].Value.ToString();
                int appID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AppointmentID"].Value);

                // 3. Block them if it's already Completed or Cancelled
                if (currentStatus != "Scheduled")
                {
                    MessageBox.Show("You can only cancel appointments that are currently 'Scheduled'.", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 4. Confirm cancellation
                DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // 5. Execute and Refresh!
                    int result = controllerObj.CancelAppointment(appID);

                    if (result > 0)
                    {
                        MessageBox.Show("Appointment cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAppointments(); // Instantly reloads the grid to show the new 'Cancelled' status!
                        cmbFilterStatus_SelectedIndexChanged(null, null);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment from the list first.", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Make sure the grid actually has data loaded in it
            if (dataGridView1.DataSource is DataTable dt)
            {
                // 2. See what the user just clicked
                string selectedFilter = cmbFilterStatus.SelectedItem.ToString();

                // 3. Apply the filter to the data!
                if (selectedFilter == "All")
                {
                    // Empty string means "Remove the filter, show me everything"
                    dt.DefaultView.RowFilter = string.Empty;
                }
                else
                {
                    // This tells the grid: Only show rows where the [Status] column matches the dropdown!
                    // Notice we use [Status] because that is the exact name we gave it in our SQL query AS [Status]
                    dt.DefaultView.RowFilter = $"[Status] = '{selectedFilter}'";
                }
            }
        }

        private void StyleDataGrid()
        {
            // 1. Remove the annoying default behaviors
            dataGridView1.AllowUserToAddRows = false; // Kills the empty asterisk row at the bottom
            dataGridView1.RowHeadersVisible = false;  // Kills the left-most arrow column
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true; // Prevents users from typing directly into the grid

            // 2. Fix the "Gray Void" by making columns stretch to fill the space
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White; // Matches your clean card background
            dataGridView1.BorderStyle = BorderStyle.None;

            // 3. Style the Headers (Let's make them match your dark blue sidebar!)
            dataGridView1.EnableHeadersVisualStyles = false; // MUST be false to change header colors
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 41, 55); // Dark blue theme
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // 4. Style the Rows
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.RowTemplate.Height = 40; // Taller rows look much more modern
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Clean horizontal lines only

            // 5. Selection Color (Let's use your PawPulse Orange!)
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 140, 40);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            // Optional: Alternating row colors for readability
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
        }
    }
}
