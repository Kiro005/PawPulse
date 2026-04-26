using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DBapplication;

namespace PawPulse
{
    public partial class VetDashboardUC : UserControl
    {
        private int _vetId;
        private string _vetName;
        private Controller _ctrl;

        private Label lblTodayVal;
        private Label lblScheduledVal;
        private Label lblPatientsVal;
        private DataGridView dgvRecent;

        public VetDashboardUC(int vetId, string vetName)
        {
            _vetId = vetId;
            _vetName = vetName;
            _ctrl = new Controller();
            InitializeComponent();
            BuildUI();
            LoadStats();
        }

        private void BuildUI()
        {
            this.BackColor = Color.FromArgb(245, 246, 250);
            this.Size = new Size(848, 594);

            var banner = new Panel();
            banner.BackColor = Color.FromArgb(31, 38, 62);
            banner.Location = new Point(0, 45);
            banner.Size = new Size(848, 110);

            var lblWelcome = new Label();
            lblWelcome.Text = "Welcome back, Dr. " + _vetName;
            lblWelcome.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(30, 20);

            var lblDate = new Label();
            lblDate.Text = DateTime.Today.ToString("dddd, MMMM d yyyy");
            lblDate.Font = new Font("Segoe UI", 10f);
            lblDate.ForeColor = Color.FromArgb(160, 200, 190);
            lblDate.AutoSize = true;
            lblDate.Location = new Point(32, 58);

            banner.Controls.Add(lblWelcome);
            banner.Controls.Add(lblDate);

            var accentLine = new Panel();
            accentLine.BackColor = Color.FromArgb(113, 196, 175);
            accentLine.Location = new Point(0, 152);
            accentLine.Size = new Size(848, 3);


            var card1 = MakeCard("Today's Appointments", "appointment.png", Color.FromArgb(113, 196, 175), out lblTodayVal);
            card1.Location = new Point(30, 175);

            var card2 = MakeCard("Scheduled", "stethoscope.png", Color.FromArgb(72, 133, 237), out lblScheduledVal);
            card2.Location = new Point(306, 175);

            var card3 = MakeCard("My Patients", "paw.png", Color.FromArgb(255, 160, 80), out lblPatientsVal);
            card3.Location = new Point(582, 175);

            var lblRecent = new Label();
            lblRecent.Text = "Recent Appointments";
            lblRecent.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            lblRecent.ForeColor = Color.FromArgb(31, 38, 62);
            lblRecent.AutoSize = true;
            lblRecent.Location = new Point(36, 370);

            var tealBar = new Panel();
            tealBar.BackColor = Color.FromArgb(113, 196, 175);
            tealBar.Location = new Point(30, 368);
            tealBar.Size = new Size(4, 26);

            dgvRecent = new DataGridView();
            dgvRecent.Location = new Point(30, 403);
            dgvRecent.Size = new Size(788, 175);
            StyleGrid(dgvRecent);

            this.Controls.Add(dgvRecent);
            this.Controls.Add(lblRecent);
            this.Controls.Add(tealBar);
            this.Controls.Add(card1);
            this.Controls.Add(card2);
            this.Controls.Add(card3);
            this.Controls.Add(accentLine);
            this.Controls.Add(banner);
        }

        private Panel MakeCard(string title, string iconFile, Color accentColor, out Label valueLabel)
        {
            var card = new Panel();
            card.BackColor = Color.White;
            card.Size = new Size(236, 115);

            var leftBar = new Panel();
            leftBar.BackColor = accentColor;
            leftBar.Location = new Point(0, 0);
            leftBar.Size = new Size(5, 115);

            var lblTitle = new Label();
            lblTitle.AutoSize = false;
            lblTitle.Size = new Size(160, 18);
            lblTitle.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(130, 130, 150);
            lblTitle.Location = new Point(18, 18);
            lblTitle.Text = title.ToUpper();

            valueLabel = new Label();
            valueLabel.AutoSize = true;
            valueLabel.Font = new Font("Segoe UI Black", 32f, FontStyle.Bold);
            valueLabel.ForeColor = Color.FromArgb(31, 38, 62);
            valueLabel.Location = new Point(18, 40);
            valueLabel.Text = "—";

            var icon = new PictureBox();
            icon.Location = new Point(178, 35);
            icon.Size = new Size(45, 45);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.BackColor = Color.Transparent;
            string iconPath = Path.Combine(Application.StartupPath, "equipments", iconFile);
            if (File.Exists(iconPath))
                icon.Image = VetDashboardForm.LoadIcon(iconFile, 45);

            card.Controls.Add(leftBar);
            card.Controls.Add(lblTitle);
            card.Controls.Add(valueLabel);
            card.Controls.Add(icon);
            return card;
        }

        private void StyleGrid(DataGridView g)
        {
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.RowHeadersVisible = false;
            g.AllowUserToAddRows = false;
            g.ReadOnly = true;
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.MultiSelect = false;
            g.Font = new Font("Segoe UI", 9.5f);
            g.RowTemplate.Height = 34;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Color.FromArgb(230, 230, 235);
            g.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 38, 62);
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold);
            g.ColumnHeadersHeight = 38;
            g.EnableHeadersVisualStyles = false;
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(113, 196, 175);
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 252);
        }

        private void LoadStats()
        {
            try
            {
                lblTodayVal.Text = _ctrl.GetTodayAppointmentsCount(_vetId).ToString();
                lblScheduledVal.Text = _ctrl.GetScheduledAppointmentsCount(_vetId).ToString();
                lblPatientsVal.Text = _ctrl.GetTotalPatientsCount(_vetId).ToString();

                var dt = _ctrl.GetVetAppointments(_vetId);
                if (dt != null)
                {
                    var recent = dt.Clone();
                    int count = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (count >= 5) break;
                        recent.ImportRow(row);
                        count++;
                    }
                    dgvRecent.DataSource = recent;
                    if (dgvRecent.Columns.Contains("AppointmentID")) dgvRecent.Columns["AppointmentID"].Visible = false;

                    foreach (DataGridViewRow row in dgvRecent.Rows)
                    {
                        string status = row.Cells["Status"]?.Value?.ToString() ?? "";
                        if (status == "Completed")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(34, 139, 34);
                        else if (status == "Cancelled")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(200, 60, 60);
                        else if (status == "Scheduled")
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 100, 200);
                    }
                }
            }
            catch { }
        }
    }
}
