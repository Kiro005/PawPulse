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
    public partial class ManageUsersUC : UserControl
    {
        Controller controllerObj;
        DataView currentDataView; // Generic name for filtering
        int AdminID;
        string AdminName;
        string currentView; // Tracks "Employee" or "Client"

        // Updated Constructor with viewType parameter
        public ManageUsersUC(int adminId, string adminName, string viewType = "Employee")
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.AdminID = adminId;
            this.AdminName = adminName;
            this.currentView = viewType;

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            // Setup UI and Data based on view type
            ApplyViewConfiguration();
        }
        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Validate that the click is on a valid row (not the header)
            if (e.RowIndex >= 0)
            {
                string columnName = dgvEmployees.Columns[e.ColumnIndex].Name;
                string headerText = dgvEmployees.Columns[e.ColumnIndex].HeaderText;
                var cellValue = dgvEmployees.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (cellValue == null || cellValue == DBNull.Value) return;

                // 2. Show details if the user double-clicks on Email or Address fields
                if (headerText.Contains("Email") || headerText.Contains("Street") || headerText.Contains("City"))
                {
                    string detailValue = cellValue.ToString();

                    // Show a professional message box with the detail
                    MessageBox.Show($"{headerText}: {detailValue}",
                                    "Contact Details",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
        }

        private void ApplyViewConfiguration()
        {
            // 1. Initialize Filters and Visibility
            if (currentView == "Client")
            {
                btnِAddUser.Visible = false;      // Clients sign up themselves
                cmbRoleFilter.Visible = false;   // Roles not applicable to clients
                lblFilterTag.Visible = false;
                lblSubTitle.Text = "Client Directory";
                btnEditusr.Top = 140; // Move Edit button up to align with clients' shorter info
                button1.Text = "Delete Client"; // Change button text for clients
                button1.Top = 140; // Move Delete button up as well
                button1.Left= 300; // Move Delete button to the right for better spacing
                dgvEmployees.Width= 600; // Expand grid width for client info

            }
            else
            {
                btnِAddUser.Visible = true;
                cmbRoleFilter.Visible = true;
                lblFilterTag.Visible = true;
                lblSubTitle.Text = "Employee Directory";

                cmbRoleFilter.Items.Clear();
                cmbRoleFilter.Items.AddRange(new string[] { "All", "Veterinarian", "Receptionist", "Manager", "Shelter Staff" });
                cmbRoleFilter.SelectedIndex = 0;
            }

            // 2. Format Grid and Load Data
            StyleDataGridView();
            RefreshGrid();
            StyleInputControls();
            StyleLabels();
        }

        private void RefreshGrid()
        {
            // 1. Clear existing binding to reset the grid schema
            dgvEmployees.DataSource = null;
            dgvEmployees.Columns.Clear(); // Clear manual columns like btnStatus to recreate them

            DataTable dt;
            if (currentView == "Client")
            {
                dt = controllerObj.GetAllClients();
            }
            else
            {
                dt = controllerObj.GetAllEmployees();
            }

            if (dt != null)
            {
                currentDataView = new DataView(dt);

                // 2. Re-apply styling and the Status button AFTER setting the new data
                StyleDataGridView();
                dgvEmployees.DataSource = currentDataView;

                // 3. Hide the correct ID column based on view
                string idCol = (currentView == "Client") ? "ClientID" : "EmployeeID";
                if (dgvEmployees.Columns.Contains(idCol)) dgvEmployees.Columns[idCol].Visible = false;
                if (dgvEmployees.Columns.Contains("IsActive")) dgvEmployees.Columns["IsActive"].Visible = false;

                // Ensure the status button is at the end
                if (dgvEmployees.Columns.Contains("btnStatus"))
                    dgvEmployees.Columns["btnStatus"].DisplayIndex = dgvEmployees.Columns.Count - 1;
            }
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            if (currentDataView == null) return;

            // Adjust search query based on available columns
            if (currentView == "Client")
            {
                // Clients use FirstName and Email
                currentDataView.RowFilter = string.Format("FirstName LIKE '%{0}%' OR Email LIKE '%{0}%'", txtSearchUser.Text);
            }
            else
            {
                // Employees use FullName and [Work Email]
                currentDataView.RowFilter = string.Format("FullName LIKE '%{0}%' OR [Work Email] LIKE '%{0}%'", txtSearchUser.Text);
            }
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentDataView == null || currentView == "Client") return;

            string selectedRole = cmbRoleFilter.SelectedItem.ToString();
            if (selectedRole == "All")
                currentDataView.RowFilter = "";
            else
                currentDataView.RowFilter = string.Format("Role = '{0}'", selectedRole);
        }

        private void StyleDataGridView()
        {
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.EnableHeadersVisualStyles = false;

            // Add Status Button column if missing
            if (!dgvEmployees.Columns.Contains("btnStatus"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "btnStatus";
                btnCol.HeaderText = "Status";
                btnCol.FlatStyle = FlatStyle.Flat;
                dgvEmployees.Columns.Add(btnCol);
            }

            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.RowTemplate.Height = 45;
            dgvEmployees.ColumnHeadersHeight = 50;

            // Dark Navy Header Style
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 40, 55);
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Row Styling
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 240, 245);
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 40, 55);
            dgvEmployees.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            if (dgvEmployees.Columns.Contains("btnStatus"))
            {
                dgvEmployees.Columns["btnStatus"].DefaultCellStyle.SelectionBackColor = Color.White;
                dgvEmployees.Columns["btnStatus"].FillWeight = 60;
            }
            //if (currentView == "Client")
            //{
            //    // English comments: Adjusting column weights for better visibility
            //    if (dgvEmployees.Columns.Contains("Email")) dgvEmployees.Columns["Email"].FillWeight = 150;
            //    if (dgvEmployees.Columns.Contains("Street")) dgvEmployees.Columns["Street"].FillWeight = 150;
            //    if (dgvEmployees.Columns.Contains("Phone")) dgvEmployees.Columns["Phone"].FillWeight = 100;
            //}
        }

        private void dgvEmployees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (!dgvEmployees.Columns.Contains("btnStatus")) return;

            foreach (DataGridViewRow row in dgvEmployees.Rows)
            {
                if (row.Cells["IsActive"].Value != DBNull.Value)
                {
                    bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
                    var statusCell = row.Cells["btnStatus"];

                    if (isActive)
                    {
                        statusCell.Value = "Active";
                        statusCell.Style.ForeColor = Color.Green;
                        statusCell.Style.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        statusCell.Value = "Inactive";
                        statusCell.Style.ForeColor = Color.Red;
                        statusCell.Style.SelectionForeColor = Color.Red;
                    }
                }
            }
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEmployees.Columns[e.ColumnIndex].Name == "btnStatus")
            {
                // Dynamic ID identification
                string idCol = currentView == "Client" ? "ClientID" : "EmployeeID";
                int targetId = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells[idCol].Value);
                bool currentStatus = Convert.ToBoolean(dgvEmployees.Rows[e.RowIndex].Cells["IsActive"].Value);

                string action = currentStatus ? "deactivate" : "activate";

                DialogResult result = MessageBox.Show($"Are you sure you want to {action} this user?",
                                    "Confirm Status Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int newStatusValue = currentStatus ? 0 : 1;

                    // Update status based on type
                    int rowsAffected = (currentView == "Client")
                        ? controllerObj.UpdateClientStatus(targetId, newStatusValue)
                        : controllerObj.UpdateEmployeeStatus(targetId, newStatusValue);

                    if (rowsAffected > 0)
                    {
                        dgvEmployees.Rows[e.RowIndex].Cells["IsActive"].Value = (newStatusValue == 1);
                        MessageBox.Show($"User {action}d successfully!");
                        RefreshGrid(); // Refresh to apply visual styles
                    }
                }
            }
        }

        private void btnِAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addFrm = new AddUserForm();
            if (addFrm.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void btnEditusr_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                string idCol = currentView == "Client" ? "ClientID" : "EmployeeID";
                int id = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[idCol].Value);

                if (currentView == "Client")
                {
                     
                     EditClientForm editFrm = new EditClientForm(id);
                    editFrm.ShowDialog();
                        RefreshGrid();
                }
                else
                {
                    EditUserForm editFrm = new EditUserForm(id);
                    if (editFrm.ShowDialog() == DialogResult.OK) RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a record to edit.");
            }
        }

        private void button1_Click(object sender, EventArgs e) // Fire/Delete Button
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                string idCol = currentView == "Client" ? "ClientID" : "EmployeeID";
                int targetID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[idCol].Value);

                // Check if the current view is Employee to validate the Manager role
                if (currentView != "Client")
                {
                    // Retrieve the role from the selected row (Change "EmployeeRole" if your column name is different)
                    string employeeRole = dgvEmployees.SelectedRows[0].Cells["Role"].Value.ToString();

                    if (employeeRole == "Manager")
                    {
                        // Block deletion and show the custom message
                        MessageBox.Show("Can't fire our Great and kind manager!", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return; // Exit the method early
                    }
                }

                string msg = currentView == "Client" ? "delete this client?" : "fire this employee?";

                DialogResult result = MessageBox.Show($"Are you sure you want to {msg}", "Confirm Action",
                                             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int affected = (currentView == "Client")
                        ? controllerObj.DeleteClient(targetID)
                        : controllerObj.DeleteEmployee(targetID);

                    if (affected > 0)
                    {
                        MessageBox.Show("Record removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshGrid();
                    }
                }
            }
        }

        // --- Styling Helper Methods ---
        private void StyleInputControls()
        {
            txtSearchUser.BorderStyle = BorderStyle.FixedSingle;
            txtSearchUser.Font = new Font("Segoe UI", 11);
            cmbRoleFilter.FlatStyle = FlatStyle.Flat;
            cmbRoleFilter.Font = new Font("Segoe UI", 10);
        }

        private void StyleLabels()
        {
            lblSearchTag.ForeColor = Color.DimGray;
            lblSearchTag.Font = new Font("Segoe UI Semibold", 9);
            lblFilterTag.ForeColor = Color.DimGray;
            lblFilterTag.Font = new Font("Segoe UI Semibold", 9);
        }
    }
}