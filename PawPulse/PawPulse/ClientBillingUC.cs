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
    public partial class ClientBillingUC : UserControl
    {
        Controller controllerObj;
        int clientID;
        string clientName;
        public ClientBillingUC(int clientID, string clientName)
        {
            InitializeComponent();
            controllerObj = new Controller();
            this.clientID = clientID;
            this.clientName = clientName;

            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");

            StyleDataGrid(dgvBills);
            StyleDataGrid(dgvBillItems);

            LoadBills();
        }
        private void StyleDataGrid(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Crucial for clicking bills!
            dgv.MultiSelect = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 41, 55);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.RowTemplate.Height = 40;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(242, 140, 40);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);
        }

        private void LoadBills()
        {
            DataTable dtBills = controllerObj.GetClientBills(clientID);
            dgvBills.DataSource = dtBills;

            // Hide the BillID column so the user doesn't see it, but we can still use it!
            if (dgvBills.Columns["BillID"] != null)
            {
                dgvBills.Columns["BillID"].Visible = false;
            }
        }

        private void dgvBills_SelectionChanged(object sender, EventArgs e)
        {
            // 1. Make sure a row is actually selected
            if (dgvBills.SelectedRows.Count > 0)
            {
                // 2. Grab the hidden BillID from the selected row
                int selectedBillID = Convert.ToInt32(dgvBills.SelectedRows[0].Cells["BillID"].Value);

                // 3. Fetch the items for this specific bill
                DataTable dtItems = controllerObj.GetBillItems(selectedBillID);

                // 4. Display them in the second grid!
                dgvBillItems.DataSource = dtItems;

                // Optional: Clear any default selection so it looks clean
                dgvBillItems.ClearSelection();
            }
            else
            {
                // If nothing is selected, clear the items grid
                dgvBillItems.DataSource = null;
            }
        }

        private void ClientBillingUC_Load(object sender, EventArgs e)
        {

        }
    }
}
