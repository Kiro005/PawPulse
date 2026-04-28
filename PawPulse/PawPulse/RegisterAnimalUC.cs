using System;
using System.Data;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class RegisterAnimalUC : UserControl
    {
        private Controller _ctrl;

        public RegisterAnimalUC()
        {
            _ctrl = new Controller();
            InitializeComponent();
            cmbGender2.Items.AddRange(new string[] { "Male", "Female" });
            cmbGender2.SelectedIndex = 0;
            dtpDOB2.Value = DateTime.Today.AddYears(-1);
            btnRegister2.Click += BtnRegister_Click;
            btnClear2.Click += (s, e) => ClearForm();
            LoadKennels();
        }

        private void LoadKennels()
        {
            try
            {
                var dt = _ctrl.GetAvailableKennels();
                if (dt == null) return;
                cmbKennel2.Items.Clear();
                foreach (DataRow r in dt.Rows)
                    cmbKennel2.Items.Add(new ComboItem(r["Display"].ToString(), Convert.ToInt32(r["KennelID"])));
                if (cmbKennel2.Items.Count > 0) cmbKennel2.SelectedIndex = 0;
                cmbKennel2.DisplayMember = "Display";
            }
            catch { }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnimalName.Text) || string.IsNullOrWhiteSpace(txtSpecies2.Text) || cmbKennel2.SelectedItem == null)
            { MessageBox.Show("Animal Name, Species and Kennel are required.", "PawPulse"); return; }

            decimal weight = 0;
            decimal.TryParse(txtWeight2.Text, out weight);
            int kennelId = ((ComboItem)cmbKennel2.SelectedItem).Value;
            string dob = dtpDOB2.Value.ToString("yyyy-MM-dd");

            bool ok = _ctrl.RegisterAnimal(
                txtAnimalName.Text.Trim(),
                txtSpecies2.Text.Trim(),
                string.IsNullOrWhiteSpace(textBreed2.Text) ? "Mixed" : textBreed2.Text.Trim(),
                cmbGender2.SelectedItem.ToString(),
                dob,
                weight,
                kennelId
            );

            if (ok)
            {
                MessageBox.Show($"{txtAnimalName.Text.Trim()} has been registered and assigned to a kennel.", "PawPulse");
                ClearForm();
                LoadKennels();
            }
            else
                MessageBox.Show("Failed to register animal.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ClearForm()
        {
            txtAnimalName.Clear();
            txtSpecies2.Clear();
            textBreed2.Clear();
            txtWeight2.Clear();
            cmbGender2.SelectedIndex = 0;
            dtpDOB2.Value = DateTime.Today.AddYears(-1);
        }

        private void RegisterAnimalUC_Load(object sender, EventArgs e) { }

        private void formCard_Paint(object sender, PaintEventArgs e) { }

        private void TopBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
