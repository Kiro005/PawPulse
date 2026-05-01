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
    
    public partial class ManageUsers : UserControl
    {
        Controller controllerObj;
        DataView employeeView; // Global for filtering
        int ClientID;
        string ClientName;

        public ManageUsers(int clientID, string clientName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.ClientID = clientID;
            this.ClientName = clientName;
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            // 1. Initialize ComboBox Items
            cmbRoleFilter.Items.Clear();
            cmbRoleFilter.Items.AddRange(new string[] { "All", "Veterinarian", "Receptionist", "Manager", "Staff" });
            cmbRoleFilter.SelectedIndex = 0;

            // 2. Setup Grid Structure
            StyleDataGridView();

            // 3. Load Data
            RefreshGrid();

            // 4. Style Input Controls
            StyleInputControls();

            // 5. Style Labels
            StyleLabels();
        }


        private void RefreshGrid()
        {
            DataTable dt = controllerObj.GetAllEmployees(); // Using your method
            if (dt != null)
            {
                employeeView = new DataView(dt);
                dgvEmployees.DataSource = employeeView;

                // Hide raw data columns
                if (dgvEmployees.Columns.Contains("IsActive")) dgvEmployees.Columns["IsActive"].Visible = false;
                if (dgvEmployees.Columns.Contains("EmployeeID")) dgvEmployees.Columns["EmployeeID"].Visible = false;

                // Ensure the toggle button is on the far right
                if (dgvEmployees.Columns.Contains("btnStatus"))
                    dgvEmployees.Columns["btnStatus"].DisplayIndex = dgvEmployees.Columns.Count - 1;
            }
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {
            if (employeeView != null)
            {
                // Use the EXACT Aliases from your SQL: FullName and [Work Email]
                employeeView.RowFilter = string.Format("FullName LIKE '%{0}%' OR [Work Email] LIKE '%{0}%'", txtSearchUser.Text);
            }
        }

        private void cmbRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (employeeView == null) return;

            string selectedRole = cmbRoleFilter.SelectedItem.ToString();

            if (selectedRole == "All")
                employeeView.RowFilter = "";
            else
                // Use the [Role] alias from your SQL
                employeeView.RowFilter = string.Format("Role = '{0}'", selectedRole);
        }



        

        

        
        
        
        private void LoadEmployees()
        {
            DataTable dt = controllerObj.GetAllEmployees();
            dgvEmployees.DataSource = dt;

            // Technical Note: Hide sensitive columns like IDs if needed
            dgvEmployees.Columns["EmployeeID"].Visible = false;
        }

        // Filter logic for the ComboBox
        

        private void StyleDataGridView()
        {
            // --- 1. Reset & Setup ---
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Enable custom header styles
            dgvEmployees.EnableHeadersVisualStyles = false; 

    // --- 2. Add Status Button  ---
    if (!dgvEmployees.Columns.Contains("btnStatus"))
            {
                DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
                btnCol.Name = "btnStatus";
                btnCol.HeaderText = "Status"; 
        btnCol.FlatStyle = FlatStyle.Flat;
                dgvEmployees.Columns.Add(btnCol);
            }

            // --- 3. Manage Visibility & Order ---
            // Hide original checkbox column
            if (dgvEmployees.Columns.Contains("IsActive"))
                dgvEmployees.Columns["IsActive"].Visible = false; 

    // Move Status button to the far right
    dgvEmployees.Columns["btnStatus"].DisplayIndex = dgvEmployees.Columns.Count - 1; 

    // --- 4. Fix Column Squashing (FillWeights) ---
    dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 

    // Assign weights to prevent compression
    if (dgvEmployees.Columns.Contains("FullName")) dgvEmployees.Columns["FullName"].FillWeight = 150;
            if (dgvEmployees.Columns.Contains("EmployeeRole")) dgvEmployees.Columns["EmployeeRole"].FillWeight = 100;
            if (dgvEmployees.Columns.Contains("Email")) dgvEmployees.Columns["Email"].FillWeight = 120;
            dgvEmployees.Columns["btnStatus"].FillWeight = 60; // Keep button slim

            // --- 5. Styling & Colors ---
            dgvEmployees.RowTemplate.Height = 45;
            dgvEmployees.ColumnHeadersHeight = 50;

            // Header Colors
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 40, 55);
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Row Selection Colors
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 240, 245);
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 40, 55);

            if (dgvEmployees.Columns.Contains("btnStatus"))
            {
                // Force the selection background of this column to stay White
                dgvEmployees.Columns["btnStatus"].DefaultCellStyle.SelectionBackColor = Color.White;

                // Ensure the button weight stays correct
                dgvEmployees.Columns["btnStatus"].FillWeight = 60;
            }


            // Disable text wrapping to keep rows clean
            dgvEmployees.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
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
                        // Keep text Green even when the row is selected
                        statusCell.Style.SelectionForeColor = Color.Green;
                    }
                    else
                    {
                        statusCell.Value = "Inactive";
                        statusCell.Style.ForeColor = Color.Red;
                        // Keep text Red even when the row is selected
                        statusCell.Style.SelectionForeColor = Color.Red;
                    }
                }
            }
        }
        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure the click is on the button column and not the header
            if (e.RowIndex >= 0 && dgvEmployees.Columns[e.ColumnIndex].Name == "btnStatus")
            {
                int empId = Convert.ToInt32(dgvEmployees.Rows[e.RowIndex].Cells["EmployeeID"].Value);
                bool currentStatus = Convert.ToBoolean(dgvEmployees.Rows[e.RowIndex].Cells["IsActive"].Value);
                string action = currentStatus ? "deactivate" : "activate";

                DialogResult result = MessageBox.Show($"Are you sure you want to {action} this employee?",
                                                    "Confirm Status Change",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int newStatusValue = currentStatus ? 0 : 1;
                    int rowsAffected = controllerObj.UpdateEmployeeStatus(empId, newStatusValue);

                    if (rowsAffected > 0) // <--- THIS IS THE BLOCK
                    {
                        // 1. Update the hidden boolean cell value
                        dgvEmployees.Rows[e.RowIndex].Cells["IsActive"].Value = (newStatusValue == 1);

                        // 2. Reference the button cell to update its style
                        DataGridViewCell buttonCell = dgvEmployees.Rows[e.RowIndex].Cells["btnStatus"];

                        if (newStatusValue == 1)
                        {
                            buttonCell.Value = "Active";
                            buttonCell.Style.ForeColor = Color.Green;
                            buttonCell.Style.SelectionForeColor = Color.Green; // Keep color when selected
                        }
                        else
                        {
                            buttonCell.Value = "Inactive";
                            buttonCell.Style.ForeColor = Color.Red;
                            buttonCell.Style.SelectionForeColor = Color.Red; // Keep color when selected
                        }

                        MessageBox.Show($"Employee {action}d successfully!");
                    }
                }
            }
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validate row index and column name
            if (e.RowIndex >= 0 && dgvEmployees.Columns[e.ColumnIndex].HeaderText.Contains("Email"))
            {
                string fullEmail = dgvEmployees.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                MessageBox.Show($"Contact Email: {fullEmail}", "Employee Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void StyleInputControls()
        {
            // Search TextBox Styling
            txtSearchUser.BorderStyle = BorderStyle.FixedSingle;
            txtSearchUser.Font = new Font("Segoe UI", 11);
            txtSearchUser.BackColor = Color.White;

            // Role ComboBox Styling
            cmbRoleFilter.FlatStyle = FlatStyle.Flat;
            cmbRoleFilter.Font = new Font("Segoe UI", 10);
            cmbRoleFilter.BackColor = Color.White;
        }
        private void StyleLabels()
        {
            // Main Title Label (e.g., "Employee Management")
            //lblTitle.Font = new Font("Segoe UI", , FontStyle.Bold);

            // Search Label
            lblSearchTag.ForeColor = Color.DimGray; // Soft dark gray for labels
            lblSearchTag.Font = new Font("Segoe UI Semibold", 9);
            lblSearchTag.Text = "SEARCH BY NAME OR EMAIL";

            // Filter Label
            lblFilterTag.ForeColor = Color.DimGray;
            lblFilterTag.Font = new Font("Segoe UI Semibold", 9);
            lblFilterTag.Text = "FILTER BY ROLE";

            // Optional: Add a subtle separator line color if you have any
        }

        private void btnِAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addFrm = new AddUserForm();
            if (addFrm.ShowDialog() == DialogResult.OK)
            {
                RefreshGrid(); // Automatically update the table after adding
            }
        }

        private void btnEditusr_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                // Get the ID from the selected row (column "EmployeeID")
                int id = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);

                // Open Edit form and pass the ID
                EditUserForm editFrm = new EditUserForm(id);
                if (editFrm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid(); // Refresh the table after saving
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                // 2. Get the EmployeeID from the selected row
                int empID = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value);
                string empName = dgvEmployees.SelectedRows[0].Cells["FullName"].Value.ToString();

                // 3. Show a confirmation message box before deletion
                DialogResult result = MessageBox.Show($"Are you sure you want to fire {empName} and delete their record?",
                                                    "Confirm Deletion",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // 4. Call the controller to delete the record
                    int affectedRows = controllerObj.DeleteEmployee(empID);

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Employee has been removed successfully.");

                        // 5. Refresh the grid to show the updated list
                        RefreshGrid();
                    }
                    else
                    {
                        MessageBox.Show("Error: Could not delete the employee.");
                    }
                }
            }
            else
            {
                // Alert if the user clicked the button without selecting a row
                MessageBox.Show("Please select an employee first.");
            }
        }
    }


}

