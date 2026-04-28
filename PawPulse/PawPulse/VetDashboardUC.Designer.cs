namespace PawPulse
{
    partial class VetDashboardUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent() {            this.banner = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.accentLine = new System.Windows.Forms.Panel();
            this.card1 = new System.Windows.Forms.Panel();
            this.card1Bar = new System.Windows.Forms.Panel();
            this.lblCard1Title = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.icon1 = new System.Windows.Forms.PictureBox();
            this.card2 = new System.Windows.Forms.Panel();
            this.icon2 = new System.Windows.Forms.PictureBox();
            this.lblScheduledVal2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.icon3 = new System.Windows.Forms.PictureBox();
            this.lblPatientsVal2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRecent = new System.Windows.Forms.Label();
            this.tealBar = new System.Windows.Forms.Panel();
            this.dgvRecent2 = new System.Windows.Forms.DataGridView();
            this.banner.SuspendLayout();
            this.card1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).BeginInit();
            this.card2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent2)).BeginInit();
            this.SuspendLayout();
            // 
            // banner
            // 
            this.banner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.banner.Controls.Add(this.lblDate);
            this.banner.Controls.Add(this.lblWelcome);
            this.banner.Location = new System.Drawing.Point(0, 45);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(848, 110);
            this.banner.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(30, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(332, 41);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back, Dr. Vet";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(200)))), ((int)(((byte)(190)))));
            this.lblDate.Location = new System.Drawing.Point(32, 58);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(48, 23);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // accentLine
            // 
            this.accentLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.accentLine.Location = new System.Drawing.Point(0, 152);
            this.accentLine.Name = "accentLine";
            this.accentLine.Size = new System.Drawing.Size(848, 3);
            this.accentLine.TabIndex = 1;
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.Color.White;
            this.card1.Controls.Add(this.icon1);
            this.card1.Controls.Add(this.label1);
            this.card1.Controls.Add(this.lblCard1Title);
            this.card1.Controls.Add(this.card1Bar);
            this.card1.Location = new System.Drawing.Point(30, 175);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(236, 115);
            this.card1.TabIndex = 2;
            // 
            // card1Bar
            // 
            this.card1Bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.card1Bar.Location = new System.Drawing.Point(0, 0);
            this.card1Bar.Name = "card1Bar";
            this.card1Bar.Size = new System.Drawing.Size(5, 115);
            this.card1Bar.TabIndex = 0;
            // 
            // lblCard1Title
            // 
            this.lblCard1Title.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCard1Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.lblCard1Title.Location = new System.Drawing.Point(18, 18);
            this.lblCard1Title.Name = "lblCard1Title";
            this.lblCard1Title.Size = new System.Drawing.Size(160, 18);
            this.lblCard1Title.TabIndex = 1;
            this.lblCard1Title.Text = "TODAY\'S APPOINTMENTS";
            this.lblCard1Title.Click += new System.EventHandler(this.lblCard1Title_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 72);
            this.label1.TabIndex = 2;
            this.label1.Text = "0";
            // 
            // icon1
            // 
            this.icon1.BackColor = System.Drawing.Color.Transparent;
            this.icon1.Location = new System.Drawing.Point(178, 35);
            this.icon1.Name = "icon1";
            this.icon1.Size = new System.Drawing.Size(45, 45);
            this.icon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon1.TabIndex = 3;
            this.icon1.TabStop = false;
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.Color.White;
            this.card2.Controls.Add(this.icon2);
            this.card2.Controls.Add(this.lblScheduledVal2);
            this.card2.Controls.Add(this.label3);
            this.card2.Controls.Add(this.panel2);
            this.card2.Location = new System.Drawing.Point(306, 175);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(236, 115);
            this.card2.TabIndex = 3;
            // 
            // icon2
            // 
            this.icon2.BackColor = System.Drawing.Color.Transparent;
            this.icon2.Location = new System.Drawing.Point(178, 35);
            this.icon2.Name = "icon2";
            this.icon2.Size = new System.Drawing.Size(45, 45);
            this.icon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon2.TabIndex = 3;
            this.icon2.TabStop = false;
            // 
            // lblScheduledVal2
            // 
            this.lblScheduledVal2.AutoSize = true;
            this.lblScheduledVal2.Font = new System.Drawing.Font("Segoe UI", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScheduledVal2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.lblScheduledVal2.Location = new System.Drawing.Point(18, 40);
            this.lblScheduledVal2.Name = "lblScheduledVal2";
            this.lblScheduledVal2.Size = new System.Drawing.Size(61, 72);
            this.lblScheduledVal2.TabIndex = 2;
            this.lblScheduledVal2.Text = "0";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.label3.Location = new System.Drawing.Point(18, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "SCHEDULED";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(133)))), ((int)(((byte)(237)))));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 115);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.icon3);
            this.panel1.Controls.Add(this.lblPatientsVal2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(582, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 115);
            this.panel1.TabIndex = 4;
            // 
            // icon3
            // 
            this.icon3.BackColor = System.Drawing.Color.Transparent;
            this.icon3.Location = new System.Drawing.Point(178, 35);
            this.icon3.Name = "icon3";
            this.icon3.Size = new System.Drawing.Size(45, 45);
            this.icon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon3.TabIndex = 3;
            this.icon3.TabStop = false;
            // 
            // lblPatientsVal2
            // 
            this.lblPatientsVal2.AutoSize = true;
            this.lblPatientsVal2.Font = new System.Drawing.Font("Segoe UI", 31.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientsVal2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.lblPatientsVal2.Location = new System.Drawing.Point(18, 40);
            this.lblPatientsVal2.Name = "lblPatientsVal2";
            this.lblPatientsVal2.Size = new System.Drawing.Size(61, 72);
            this.lblPatientsVal2.TabIndex = 2;
            this.lblPatientsVal2.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.label4.Location = new System.Drawing.Point(18, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "MY PATIENTS";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 115);
            this.panel3.TabIndex = 0;
            // 
            // lblRecent
            // 
            this.lblRecent.AutoSize = true;
            this.lblRecent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.lblRecent.Location = new System.Drawing.Point(36, 370);
            this.lblRecent.Name = "lblRecent";
            this.lblRecent.Size = new System.Drawing.Size(217, 28);
            this.lblRecent.TabIndex = 5;
            this.lblRecent.Text = "Recent Appointments";
            // 
            // tealBar
            // 
            this.tealBar.BackColor = System.Drawing.Color.Purple;
            this.tealBar.Location = new System.Drawing.Point(30, 368);
            this.tealBar.Name = "tealBar";
            this.tealBar.Size = new System.Drawing.Size(4, 36);
            this.tealBar.TabIndex = 6;
            // 
            // dgvRecent2
            // 
            this.dgvRecent2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecent2.Location = new System.Drawing.Point(30, 403);
            this.dgvRecent2.Name = "dgvRecent2";
            this.dgvRecent2.RowHeadersWidth = 51;
            this.dgvRecent2.RowTemplate.Height = 24;
            this.dgvRecent2.Size = new System.Drawing.Size(788, 175);
            this.dgvRecent2.TabIndex = 7;
            this.dgvRecent2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecent2_CellContentClick);
            // 
            // VetDashboardUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.Controls.Add(this.dgvRecent2);
            this.Controls.Add(this.tealBar);
            this.Controls.Add(this.lblRecent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card1);
            this.Controls.Add(this.accentLine);
            this.Controls.Add(this.banner);
            this.Name = "VetDashboardUC";
            this.Size = new System.Drawing.Size(848, 594);
            this.banner.ResumeLayout(false);
            this.banner.PerformLayout();
            this.card1.ResumeLayout(false);
            this.card1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon1)).EndInit();
            this.card2.ResumeLayout(false);
            this.card2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecent2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

}

        private System.Windows.Forms.Panel banner;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel accentLine;
        private System.Windows.Forms.Panel card1;
        private System.Windows.Forms.Label lblCard1Title;
        private System.Windows.Forms.Panel card1Bar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox icon1;
        private System.Windows.Forms.Panel card2;
        private System.Windows.Forms.PictureBox icon2;
        private System.Windows.Forms.Label lblScheduledVal2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox icon3;
        private System.Windows.Forms.Label lblPatientsVal2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRecent;
        private System.Windows.Forms.Panel tealBar;
        private System.Windows.Forms.DataGridView dgvRecent2;
    }
}
