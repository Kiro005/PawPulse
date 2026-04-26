using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class RegisterAnimalUC : UserControl
    {
        private Controller _ctrl;
        private TextBox txtName;
        private TextBox txtSpecies;
        private TextBox txtBreed;
        private ComboBox cmbGender;
        private DateTimePicker dtpDOB;
        private TextBox txtWeight;
        private ComboBox cmbKennel;

        public RegisterAnimalUC()
        {
            _ctrl = new Controller();
            InitializeComponent();
            BuildUI();
            LoadKennels();
        }

        private void BuildUI()
        {
            this.BackColor = Color.FromArgb(245, 246, 250);

            var topBar = new Panel();
            topBar.BackColor = Color.FromArgb(31, 38, 62);
            topBar.Dock = DockStyle.Top;
            topBar.Height = 60;

            var lblTitle = new Label();
            lblTitle.Text = "Register Incoming Animal";
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 16);
            topBar.Controls.Add(lblTitle);

            var formCard = new Panel();
            formCard.BackColor = Color.White;
            formCard.Size = new Size(520, 420);
            formCard.Location = new Point(165, 80);
            formCard.BorderStyle = BorderStyle.None;

            var accentBar = new Panel();
            accentBar.BackColor = Color.FromArgb(113, 196, 175);
            accentBar.Location = new Point(0, 0);
            accentBar.Size = new Size(6, 420);

            var lblForm = new Label();
            lblForm.Text = "Animal Information";
            lblForm.Font = new Font("Segoe UI", 13f, FontStyle.Bold);
            lblForm.ForeColor = Color.FromArgb(31, 38, 62);
            lblForm.Location = new Point(25, 20);
            lblForm.AutoSize = true;

            AddField(formCard, "Animal Name: *", 65, out txtName, false);
            AddField(formCard, "Species: *", 110, out txtSpecies, false);
            AddField(formCard, "Breed:", 155, out txtBreed, false);

            var lblGender = MakeLabel(formCard, "Gender: *", 200);
            cmbGender = new ComboBox();
            cmbGender.Location = new Point(200, 200);
            cmbGender.Size = new Size(280, 28);
            cmbGender.Font = new Font("Segoe UI", 10f);
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.Items.AddRange(new string[] { "Male", "Female" });
            cmbGender.SelectedIndex = 0;
            formCard.Controls.Add(cmbGender);

            var lblDOB = MakeLabel(formCard, "Date of Birth:", 245);
            dtpDOB = new DateTimePicker();
            dtpDOB.Location = new Point(200, 243);
            dtpDOB.Size = new Size(280, 28);
            dtpDOB.Font = new Font("Segoe UI", 10f);
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Value = DateTime.Today.AddYears(-1);
            formCard.Controls.Add(dtpDOB);

            AddField(formCard, "Weight (kg):", 288, out txtWeight, false);

            var lblKennel = MakeLabel(formCard, "Kennel: *", 333);
            cmbKennel = new ComboBox();
            cmbKennel.Location = new Point(200, 333);
            cmbKennel.Size = new Size(280, 28);
            cmbKennel.Font = new Font("Segoe UI", 10f);
            cmbKennel.DropDownStyle = ComboBoxStyle.DropDownList;
            formCard.Controls.Add(cmbKennel);

            var btnRegister = new Button();
            btnRegister.Text = "Register Animal";
            btnRegister.Size = new Size(155, 38);
            btnRegister.Location = new Point(200, 375);
            btnRegister.BackColor = Color.FromArgb(113, 196, 175);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += BtnRegister_Click;

            var btnClear = new Button();
            btnClear.Text = "Clear";
            btnClear.Size = new Size(90, 38);
            btnClear.Location = new Point(365, 375);
            btnClear.BackColor = Color.FromArgb(150, 150, 170);
            btnClear.ForeColor = Color.White;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += (s, e) => ClearForm();

            formCard.Controls.Add(accentBar);
            formCard.Controls.Add(lblForm);
            formCard.Controls.Add(btnRegister);
            formCard.Controls.Add(btnClear);

            this.Controls.Add(formCard);
            this.Controls.Add(topBar);
        }

        private Label MakeLabel(Panel parent, string text, int y)
        {
            var lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(60, 60, 80);
            lbl.Location = new Point(20, y + 4);
            lbl.AutoSize = true;
            parent.Controls.Add(lbl);
            return lbl;
        }

        private void AddField(Panel parent, string label, int y, out TextBox txt, bool multiline)
        {
            MakeLabel(parent, label, y);
            txt = new TextBox();
            txt.Location = new Point(200, y);
            txt.Size = new Size(280, multiline ? 60 : 28);
            txt.Font = new Font("Segoe UI", 10f);
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Multiline = multiline;
            parent.Controls.Add(txt);
        }

        private void LoadKennels()
        {
            try
            {
                var dt = _ctrl.GetAvailableKennels();
                if (dt == null) return;
                cmbKennel.Items.Clear();
                foreach (DataRow r in dt.Rows)
                    cmbKennel.Items.Add(new ComboItem(r["Display"].ToString(), Convert.ToInt32(r["KennelID"])));
                if (cmbKennel.Items.Count > 0) cmbKennel.SelectedIndex = 0;
                cmbKennel.DisplayMember = "Display";
            }
            catch { }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSpecies.Text) || cmbKennel.SelectedItem == null)
            { MessageBox.Show("Animal Name, Species and Kennel are required.", "PawPulse"); return; }

            decimal weight = 0;
            decimal.TryParse(txtWeight.Text, out weight);
            int kennelId = ((ComboItem)cmbKennel.SelectedItem).Value;
            string dob = dtpDOB.Value.ToString("yyyy-MM-dd");

            bool ok = _ctrl.RegisterAnimal(
                txtName.Text.Trim(),
                txtSpecies.Text.Trim(),
                string.IsNullOrWhiteSpace(txtBreed.Text) ? "Mixed" : txtBreed.Text.Trim(),
                cmbGender.SelectedItem.ToString(),
                dob,
                weight,
                kennelId
            );

            if (ok)
            {
                MessageBox.Show($"{txtName.Text.Trim()} has been registered and assigned to a kennel.", "PawPulse");
                ClearForm();
                LoadKennels();
            }
            else
                MessageBox.Show("Failed to register animal.", "PawPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtSpecies.Clear();
            txtBreed.Clear();
            txtWeight.Clear();
            cmbGender.SelectedIndex = 0;
            dtpDOB.Value = DateTime.Today.AddYears(-1);
        }
    }
}
