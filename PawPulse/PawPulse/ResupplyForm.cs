using System;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class ResupplyForm : Form
    {
        private Controller controllerObj;
        private int _medicineId;
        private decimal _unitPrice; // Stores the fixed unit price of the medicine

        // Constructor receives ID, Name, and fixed unit price
        public ResupplyForm(int medicineId, string medicineName, decimal currentPrice)
        {
            InitializeComponent();
            controllerObj = new Controller();
            _medicineId = medicineId;
            _unitPrice = currentPrice; // Save unit price internally

            lblMedName.Text = medicineName;

            SetupUI();

            // Calculate and display initial total price for 1 unit
            UpdateTotalPrice();
        }

        // Apply dark styling and set up event listeners
        private void SetupUI()
        {
            this.BackColor = Color.FromArgb(30, 40, 55);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Configure quantity input constraints
            numQuantity.Minimum = 1;
            numQuantity.Maximum = 10000;
            numQuantity.Value = 1;

            // Configure price field to be read-only since it auto-calculates
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 1000000;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.ReadOnly = true;
            numericUpDown1.Increment = 0; // Disable arrow changes on price

            // Styling labels
            lblMedName.ForeColor = Color.FromArgb(46, 204, 113);
            lblMedName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

            // Styling buttons
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;

            btncancel.BackColor = Color.FromArgb(100, 110, 120);
            btncancel.ForeColor = Color.White;
            btncancel.FlatStyle = FlatStyle.Flat;
            btncancel.FlatAppearance.BorderSize = 0;

            // Subscribe to ValueChanged event to calculate total price dynamically
            numQuantity.ValueChanged += NumQuantity_ValueChanged;
        }

        // Recalculates total price whenever the quantity changes
        private void NumQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        // Formula: Total Cost = Quantity * Unit Price
        private void UpdateTotalPrice()
        {
            decimal totalCost = numQuantity.Value * _unitPrice;
            numericUpDown1.Value = totalCost;
        }

        // Handles saving the transaction
        private void btnSave_Click(object sender, EventArgs e)
        {
            int addedQty = (int)numQuantity.Value;

            // Note: We pass '_unitPrice' (unit cost) and 'addedQty'. 
            // The DB log query will insert them, and the report will multiply them to get total expenses!
            int result = controllerObj.ResupplyMedicine(_medicineId, addedQty, _unitPrice);

            if (result > 0)
            {
                MessageBox.Show("Stock updated and purchase logged successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to complete transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}