using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawPulse
{
    public partial class sidebarPanel2 : Form
    {
        private int _vetId;
        private string _vetName;
        private System.Collections.Generic.Dictionary<Button, Color> _originalColors;

        public sidebarPanel2(int vetId, string vetName)
        {
            _vetId = vetId;
            _vetName = vetName;
            InitializeComponent();
            SetupButtons();
            SetupIcons();
        }

        private void SetupButtons()
        {
            Button[] all = { btnDashboard2, btnAppointments2, btnMedicalRecords2, btnPrescriptions2, btnLabTests2, btnVaccinations2, btnHealthClearance2, btnRegisterAnimal2 };

            _originalColors = new System.Collections.Generic.Dictionary<Button, Color>();
            foreach (var btn in all)
            {
                _originalColors[btn] = btn.BackColor;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }
            btnLogOut2.TextAlign = ContentAlignment.MiddleLeft;
            btnLogOut2.TextImageRelation = TextImageRelation.ImageBeforeText;

            btnDashboard2.Click += (s, e) => { HighlightButton(btnDashboard2); LoadUC(new VetDashboardUC(_vetId, _vetName)); };
            btnAppointments2.Click += (s, e) => { HighlightButton(btnAppointments2); LoadUC(new AppointmentsUC(_vetId)); };
            btnMedicalRecords2.Click += (s, e) => { HighlightButton(btnMedicalRecords2); LoadUC(new MedicalRecordsUC(_vetId)); };
            btnPrescriptions2.Click += (s, e) => { HighlightButton(btnPrescriptions2); LoadUC(new PrescriptionsUC(_vetId)); };
            btnLabTests2.Click += (s, e) => { HighlightButton(btnLabTests2); LoadUC(new LabTestsUC(_vetId)); };
            btnVaccinations2.Click += (s, e) => { HighlightButton(btnVaccinations2); LoadUC(new VaccinationsUC()); };
            btnHealthClearance2.Click += (s, e) => { HighlightButton(btnHealthClearance2); LoadUC(new HealthClearanceUC()); };
            btnRegisterAnimal2.Click += (s, e) => { HighlightButton(btnRegisterAnimal2); LoadUC(new RegisterAnimalUC()); };
            btnLogOut2.Click += BtnLogOut_Click;
        }

        private void SetupIcons()
        {
            btnDashboard2.Image = LoadIcon("dashboard.png", 28);
            btnAppointments2.Image = LoadIcon("appointment.png", 28);
            btnMedicalRecords2.Image = LoadIcon("stethoscope.png", 28);
            btnPrescriptions2.Image = LoadIcon("Prescription.png", 28);
            btnLabTests2.Image = LoadIcon("Testtube.png", 28);
            btnVaccinations2.Image = LoadIcon("Syringe.png", 28);
            btnHealthClearance2.Image = LoadIcon("Certificate.png", 28);
            btnRegisterAnimal2.Image = LoadIcon("paw.png", 28);
            btnLogOut2.Image = LoadIcon("logout.png", 28);
        }

        public static Image LoadIcon(string filename, int size)
        {
            string path = Path.Combine(Application.StartupPath, "equipments", filename);
            if (!File.Exists(path)) return null;
            var orig = Image.FromFile(path);
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(orig, 0, 0, size, size);
            }
            orig.Dispose();
            return bmp;
        }

        private void HighlightButton(Button active)
        {
            foreach (var kvp in _originalColors)
                kvp.Key.BackColor = kvp.Value;
            active.BackColor = Color.FromArgb(113, 196, 175);
            active.ForeColor = Color.White;
        }

        private void LoadUC(UserControl uc)
        {
            mainContentPanel2.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainContentPanel2.Controls.Add(uc);
            uc.BringToFront();
        }

        private void VetDashboardForm_Load(object sender, EventArgs e)
        {
            lblVetName2.Text = _vetName;
            HighlightButton(btnDashboard2);
            LoadUC(new VetDashboardUC(_vetId, _vetName));
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void button1_Click(object sender, EventArgs e) { }
    }
}
