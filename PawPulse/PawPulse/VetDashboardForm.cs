using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PawPulse
{
    public partial class VetDashboardForm : Form
    {
        private int _vetId;
        private string _vetName;

        private Panel sidebarPanel;
        private Panel whiteBgPanel;
        private Panel mainContentPanel;
        private Panel headerPanel;
        private Label lblPawPulse;
        private Label lblVetName;
        private Panel divider;

        private Button btnDashboard;
        private Button btnAppointments;
        private Button btnMedicalRecords;
        private Button btnPrescriptions;
        private Button btnLabTests;
        private Button btnVaccinations;
        private Button btnHealthClearance;
        private Button btnRegisterAnimal;
        private Button btnLogOut;

        public VetDashboardForm(int vetId, string vetName)
        {
            _vetId = vetId;
            _vetName = vetName;
            InitializeComponent();
            BuildUI();
            SetupIcons();
        }

        private void BuildUI()
        {
            this.ClientSize = new Size(1098, 654);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Text = "PawPulse - Vet Portal";
            this.AutoScaleMode = AutoScaleMode.None;
            this.MaximizeBox = false;

            sidebarPanel = new Panel();
            sidebarPanel.BackColor = Color.FromArgb(31, 38, 62);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Size = new Size(250, 654);

            lblPawPulse = new Label();
            lblPawPulse.Text = "       PawPulse";
            lblPawPulse.Font = new Font("Segoe UI", 22.2f, FontStyle.Bold);
            lblPawPulse.ForeColor = Color.White;
            lblPawPulse.AutoSize = true;
            lblPawPulse.Location = new Point(11, 33);

            divider = new Panel();
            divider.BackColor = Color.SteelBlue;
            divider.Location = new Point(20, 90);
            divider.Size = new Size(200, 1);

            btnDashboard = MakeSidebarButton("   Dashboard", new Point(12, 108));
            btnAppointments = MakeSidebarButton("   My Appointments", new Point(12, 166));
            btnMedicalRecords = MakeSidebarButton("   Medical Records", new Point(12, 224));
            btnPrescriptions = MakeSidebarButton("   Prescriptions", new Point(12, 282));
            btnLabTests = MakeSidebarButton("   Lab Tests", new Point(12, 340));
            btnVaccinations = MakeSidebarButton("   Vaccinations", new Point(12, 398));
            btnHealthClearance = MakeSidebarButton("   Health Clearance", new Point(12, 456));
            btnRegisterAnimal = MakeSidebarButton("   Register Animal", new Point(12, 514));

            btnLogOut = MakeSidebarButton("   Log Out", new Point(12, 590));
            btnLogOut.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            btnDashboard.Click += (s, e) => { HighlightButton(btnDashboard); LoadUC(new VetDashboardUC(_vetId, _vetName)); };
            btnAppointments.Click += (s, e) => { HighlightButton(btnAppointments); LoadUC(new AppointmentsUC(_vetId)); };
            btnMedicalRecords.Click += (s, e) => { HighlightButton(btnMedicalRecords); LoadUC(new MedicalRecordsUC(_vetId)); };
            btnPrescriptions.Click += (s, e) => { HighlightButton(btnPrescriptions); LoadUC(new PrescriptionsUC(_vetId)); };
            btnLabTests.Click += (s, e) => { HighlightButton(btnLabTests); LoadUC(new LabTestsUC(_vetId)); };
            btnVaccinations.Click += (s, e) => { HighlightButton(btnVaccinations); LoadUC(new VaccinationsUC()); };
            btnHealthClearance.Click += (s, e) => { HighlightButton(btnHealthClearance); LoadUC(new HealthClearanceUC()); };
            btnRegisterAnimal.Click += (s, e) => { HighlightButton(btnRegisterAnimal); LoadUC(new RegisterAnimalUC()); };
            btnLogOut.Click += BtnLogOut_Click;

            sidebarPanel.Controls.Add(lblPawPulse);
            sidebarPanel.Controls.Add(divider);
            sidebarPanel.Controls.Add(btnDashboard);
            sidebarPanel.Controls.Add(btnAppointments);
            sidebarPanel.Controls.Add(btnMedicalRecords);
            sidebarPanel.Controls.Add(btnPrescriptions);
            sidebarPanel.Controls.Add(btnLabTests);
            sidebarPanel.Controls.Add(btnVaccinations);
            sidebarPanel.Controls.Add(btnHealthClearance);
            sidebarPanel.Controls.Add(btnRegisterAnimal);
            sidebarPanel.Controls.Add(btnLogOut);

            headerPanel = new Panel();
            headerPanel.BackColor = Color.FromArgb(245, 246, 250);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Size = new Size(848, 60);

            var searchBox = new TextBox();
            searchBox.BackColor = SystemColors.Menu;
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.Font = new Font("Segoe UI", 10.8f);
            searchBox.ForeColor = Color.FromArgb(150, 150, 150);
            searchBox.Text = "🔍 Search...";
            searchBox.Location = new Point(51, 15);
            searchBox.Size = new Size(250, 31);

            lblVetName = new Label();
            lblVetName.Text = _vetName;
            lblVetName.Font = new Font("Segoe UI", 10.8f, FontStyle.Bold);
            lblVetName.AutoSize = true;
            lblVetName.Location = new Point(640, 19);

            headerPanel.Controls.Add(searchBox);
            headerPanel.Controls.Add(lblVetName);

            whiteBgPanel = new Panel();
            whiteBgPanel.BackColor = Color.FromArgb(245, 246, 250);
            whiteBgPanel.Dock = DockStyle.Fill;

            mainContentPanel = new Panel();
            mainContentPanel.Dock = DockStyle.Fill;

            whiteBgPanel.Controls.Add(mainContentPanel);
            whiteBgPanel.Controls.Add(headerPanel);

            this.Controls.Add(whiteBgPanel);
            this.Controls.Add(sidebarPanel);
        }

        private Button MakeSidebarButton(string text, Point location)
        {
            var btn = new Button();
            btn.Text = text;
            btn.Location = location;
            btn.Size = new Size(224, 50);
            btn.BackColor = Color.FromArgb(31, 38, 62);
            btn.ForeColor = Color.FromArgb(200, 200, 200);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80);
            btn.Font = new Font("Segoe UI Semibold", 11f, FontStyle.Bold);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.UseVisualStyleBackColor = false;
            return btn;
        }

        private void SetupIcons()
        {
            btnDashboard.Image = LoadIcon("dashboard.png", 28);
            btnAppointments.Image = LoadIcon("appointment.png", 28);
            btnMedicalRecords.Image = LoadIcon("stethoscope.png", 28);
            btnPrescriptions.Image = LoadIcon("Prescription.png", 28);
            btnLabTests.Image = LoadIcon("Testtube.png", 28);
            btnVaccinations.Image = LoadIcon("Syringe.png", 28);
            btnHealthClearance.Image = LoadIcon("Certificate.png", 28);
            btnRegisterAnimal.Image = LoadIcon("paw.png", 28);
            btnLogOut.Image = LoadIcon("logout.png", 28);
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
            Button[] all = { btnDashboard, btnAppointments, btnMedicalRecords, btnPrescriptions, btnLabTests, btnVaccinations, btnHealthClearance, btnRegisterAnimal };
            foreach (var btn in all)
            {
                btn.BackColor = Color.FromArgb(31, 38, 62);
                btn.ForeColor = Color.FromArgb(200, 200, 200);
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 55, 80);
            }
            active.BackColor = Color.FromArgb(113, 196, 175);
            active.ForeColor = Color.White;
            active.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 179, 113);
        }

        private void LoadUC(UserControl uc)
        {
            mainContentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            mainContentPanel.Controls.Add(uc);
            uc.BringToFront();
        }

        private void VetDashboardForm_Load(object sender, EventArgs e)
        {
            HighlightButton(btnDashboard);
            LoadUC(new VetDashboardUC(_vetId, _vetName));
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
