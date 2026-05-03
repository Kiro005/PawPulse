using System;
using System.Data;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class RegisterAnimalUC : UserControl
    {
        private Controller _ctrl;
        private bool _editMode = false;
        private int _editingAnimalId = 0;

        public RegisterAnimalUC()
        {
            _ctrl = new Controller();
            InitializeComponent();
            cmbGender2.Items.AddRange(new string[] { "Male", "Female" });
            cmbGender2.SelectedIndex = 0;
            dtpDOB2.Value = DateTime.Today.AddYears(-1);
            btnRegister2.Click += BtnRegister_Click;
            btnClear2.Click += (s, e) => ClearForm();
            button1.Click += BtnUpdate_Click;
            button2.Click += BtnDelete_Click;
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

        private static string ShowInputBox(string prompt, string title)
        {
            Form form = new Form() { Text = title, Size = new System.Drawing.Size(340, 140), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false };
            Label lbl = new Label() { Text = prompt, Left = 10, Top = 12, Width = 300 };
            TextBox txt = new TextBox() { Left = 10, Top = 35, Width = 300 };
            Button btnOk = new Button() { Text = "OK", Left = 145, Top = 65, Width = 75, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Cancel", Left = 230, Top = 65, Width = 75, DialogResult = DialogResult.Cancel };
            form.Controls.AddRange(new System.Windows.Forms.Control[] { lbl, txt, btnOk, btnCancel });
            form.AcceptButton = btnOk; form.CancelButton = btnCancel;
            return form.ShowDialog() == DialogResult.OK ? txt.Text : null;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string input = ShowInputBox("Enter Animal ID to update:", "Update Animal");
            if (string.IsNullOrWhiteSpace(input)) return;
            int animalId;
            if (!int.TryParse(input, out animalId)) { MessageBox.Show("Invalid Animal ID.", "PawPulse"); return; }

            var dt = _ctrl.GetAnimalById(animalId);
            if (dt == null || dt.Rows.Count == 0) { MessageBox.Show("Animal not found.", "PawPulse"); return; }

            DataRow r = dt.Rows[0];
            _editMode = true;
            _editingAnimalId = animalId;
            txtAnimalName.Text = r["AnimalName"].ToString();
            txtSpecies2.Text = r["Species"].ToString();
            textBreed2.Text = r["Breed"].ToString();
            cmbGender2.SelectedItem = r["Gender"].ToString();
            if (r["EstimatedDOB"] != DBNull.Value) dtpDOB2.Value = Convert.ToDateTime(r["EstimatedDOB"]);
            txtWeight2.Text = r["LatestWeight"].ToString();
            btnRegister2.Text = "Save Changes";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string input = ShowInputBox("Enter Animal ID to delete:", "Delete Animal");
            if (string.IsNullOrWhiteSpace(input)) return;
            int animalId;
            if (!int.TryParse(input, out animalId)) { MessageBox.Show("Invalid Animal ID.", "PawPulse"); return; }

            if (MessageBox.Show($"Archive Animal ID {animalId}? This will remove it from its kennel.", "PawPulse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            bool ok = _ctrl.DeleteAnimal(animalId);
            if (ok) MessageBox.Show("Animal archived successfully.", "PawPulse");
            else MessageBox.Show("Failed to archive animal.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnimalName.Text) || string.IsNullOrWhiteSpace(txtSpecies2.Text))
            { MessageBox.Show("Animal Name and Species are required.", "PawPulse"); return; }

            decimal weight = 0; decimal.TryParse(txtWeight2.Text, out weight);
            string dob = dtpDOB2.Value.ToString("yyyy-MM-dd");
            string breed = string.IsNullOrWhiteSpace(textBreed2.Text) ? "Mixed" : textBreed2.Text.Trim();
            string gender = cmbGender2.SelectedItem?.ToString() ?? "Male";

            if (_editMode)
            {
                bool ok = _ctrl.UpdateShelterAnimal(_editingAnimalId, txtAnimalName.Text.Trim(), txtSpecies2.Text.Trim(), breed, gender, dob, weight);
                if (ok) { MessageBox.Show("Animal updated.", "PawPulse"); ClearForm(); LoadKennels(); }
                else MessageBox.Show("Failed to update animal.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cmbKennel2.SelectedItem == null) { MessageBox.Show("Kennel is required for registration.", "PawPulse"); return; }
                int kennelId = ((ComboItem)cmbKennel2.SelectedItem).Value;
                bool ok = _ctrl.RegisterAnimal(txtAnimalName.Text.Trim(), txtSpecies2.Text.Trim(), breed, gender, dob, weight, kennelId);
                if (ok) { MessageBox.Show($"{txtAnimalName.Text.Trim()} has been registered and assigned to a kennel.", "PawPulse"); ClearForm(); LoadKennels(); }
                else MessageBox.Show("Failed to register animal.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            _editMode = false; _editingAnimalId = 0;
            btnRegister2.Text = "Register Animal";
            txtAnimalName.Clear(); txtSpecies2.Clear(); textBreed2.Clear(); txtWeight2.Clear();
            cmbGender2.SelectedIndex = 0;
            dtpDOB2.Value = DateTime.Today.AddYears(-1);
        }

        private void RegisterAnimalUC_Load(object sender, EventArgs e) { }

        private void formCard_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }

        private void TopBar_Paint(object sender, System.Windows.Forms.PaintEventArgs e) { }
    }
}
