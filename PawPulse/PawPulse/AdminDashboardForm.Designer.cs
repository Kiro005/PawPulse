namespace PawPulse
{
    partial class AdminDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            this.whitebg = new System.Windows.Forms.Panel();
            this.MainContentPanel = new System.Windows.Forms.Panel();
            this.header = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmsUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.emplyeeDircToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnAdoptionfees = new System.Windows.Forms.Button();
            this.btnKennels = new System.Windows.Forms.Button();
            this.btnMedicines = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.whitebg.SuspendLayout();
            this.header.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // whitebg
            // 
            this.whitebg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.whitebg.Controls.Add(this.MainContentPanel);
            this.whitebg.Controls.Add(this.header);
            this.whitebg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.whitebg.Location = new System.Drawing.Point(281, 0);
            this.whitebg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.whitebg.Name = "whitebg";
            this.whitebg.Size = new System.Drawing.Size(932, 672);
            this.whitebg.TabIndex = 3;
            // 
            // MainContentPanel
            // 
            this.MainContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContentPanel.Location = new System.Drawing.Point(0, 75);
            this.MainContentPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainContentPanel.Name = "MainContentPanel";
            this.MainContentPanel.Size = new System.Drawing.Size(932, 612);
            this.MainContentPanel.TabIndex = 2;
            // 
            // header
            // 
            this.header.Controls.Add(this.pictureBox1);
            this.header.Controls.Add(this.lblUsername);
            this.header.Controls.Add(this.textBox1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(932, 60);
            this.header.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(779, 19);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 30);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Logger";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.textBox1.Location = new System.Drawing.Point(57, 19);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 36);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "🔍 Search...";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnReports);
            this.panel1.Controls.Add(this.btnAdoptionfees);
            this.panel1.Controls.Add(this.btnKennels);
            this.panel1.Controls.Add(this.btnMedicines);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 672);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SteelBlue;
            this.panel3.Location = new System.Drawing.Point(20, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 1);
            this.panel3.TabIndex = 6;
            // 
            // cmsUser
            // 
            this.cmsUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.cmsUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsUser.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emplyeeDircToolStripMenuItem,
            this.clientDirectoryToolStripMenuItem});
            this.cmsUser.Name = "contextMenuStrip1";
            this.cmsUser.Size = new System.Drawing.Size(229, 60);
            // 
            // emplyeeDircToolStripMenuItem
            // 
            this.emplyeeDircToolStripMenuItem.Name = "emplyeeDircToolStripMenuItem";
            this.emplyeeDircToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.emplyeeDircToolStripMenuItem.Text = "Employee Directory";
            this.emplyeeDircToolStripMenuItem.Click += new System.EventHandler(this.emplyeeDircToolStripMenuItem_Click);
            // 
            // clientDirectoryToolStripMenuItem
            // 
            this.clientDirectoryToolStripMenuItem.Name = "clientDirectoryToolStripMenuItem";
            this.clientDirectoryToolStripMenuItem.Size = new System.Drawing.Size(228, 28);
            this.clientDirectoryToolStripMenuItem.Text = "Client Directory";
            this.clientDirectoryToolStripMenuItem.Click += new System.EventHandler(this.clientDirectoryToolStripMenuItem_Click);
            this.clientDirectoryToolStripMenuItem.MouseEnter += new System.EventHandler(this.clientDirectoryToolStripMenuItem_MouseEnter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(728, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 40);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(12, 603);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(252, 71);
            this.button5.TabIndex = 7;
            this.button5.Text = "Log Out";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReports
            // 
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.Location = new System.Drawing.Point(14, 535);
            this.btnReports.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(252, 71);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "  Reports";
            this.btnReports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnAdoptionfees
            // 
            this.btnAdoptionfees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.btnAdoptionfees.FlatAppearance.BorderSize = 0;
            this.btnAdoptionfees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.btnAdoptionfees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdoptionfees.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdoptionfees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnAdoptionfees.Image = ((System.Drawing.Image)(resources.GetObject("btnAdoptionfees.Image")));
            this.btnAdoptionfees.Location = new System.Drawing.Point(14, 441);
            this.btnAdoptionfees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdoptionfees.Name = "btnAdoptionfees";
            this.btnAdoptionfees.Size = new System.Drawing.Size(252, 71);
            this.btnAdoptionfees.TabIndex = 4;
            this.btnAdoptionfees.Text = "  Adoption Fees   ";
            this.btnAdoptionfees.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdoptionfees.UseVisualStyleBackColor = false;
            this.btnAdoptionfees.Click += new System.EventHandler(this.btnAdoptionfees_Click);
            // 
            // btnKennels
            // 
            this.btnKennels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.btnKennels.FlatAppearance.BorderSize = 0;
            this.btnKennels.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.btnKennels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKennels.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKennels.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnKennels.Image = ((System.Drawing.Image)(resources.GetObject("btnKennels.Image")));
            this.btnKennels.Location = new System.Drawing.Point(14, 351);
            this.btnKennels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKennels.Name = "btnKennels";
            this.btnKennels.Size = new System.Drawing.Size(252, 71);
            this.btnKennels.TabIndex = 3;
            this.btnKennels.Text = "    Kennels";
            this.btnKennels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKennels.UseVisualStyleBackColor = false;
            this.btnKennels.Click += new System.EventHandler(this.btnKennels_Click);
            // 
            // btnMedicines
            // 
            this.btnMedicines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.btnMedicines.FlatAppearance.BorderSize = 0;
            this.btnMedicines.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            this.btnMedicines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicines.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedicines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.btnMedicines.Image = ((System.Drawing.Image)(resources.GetObject("btnMedicines.Image")));
            this.btnMedicines.Location = new System.Drawing.Point(14, 258);
            this.btnMedicines.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMedicines.Name = "btnMedicines";
            this.btnMedicines.Size = new System.Drawing.Size(252, 71);
            this.btnMedicines.TabIndex = 2;
            this.btnMedicines.Text = "    Medicines";
            this.btnMedicines.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMedicines.UseVisualStyleBackColor = false;
            this.btnMedicines.Click += new System.EventHandler(this.btnMedicines_Click_1);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Image = ((System.Drawing.Image)(resources.GetObject("btnUsers.Image")));
            this.btnUsers.Location = new System.Drawing.Point(14, 162);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(252, 71);
            this.btnUsers.TabIndex = 1;
            this.btnUsers.Text = "     Users";
            this.btnUsers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            this.btnUsers.MouseEnter += new System.EventHandler(this.btnUsers_MouseEnter);
            this.btnUsers.MouseLeave += new System.EventHandler(this.btnUsers_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "       PawPulse";
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 672);
            this.Controls.Add(this.whitebg);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AdminDashboardForm";
            this.Text = "AdminDashboardForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDashboardForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminDashboardForm_Load);
            this.whitebg.ResumeLayout(false);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel whitebg;
        private System.Windows.Forms.Panel MainContentPanel;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnAdoptionfees;
        private System.Windows.Forms.Button btnKennels;
        private System.Windows.Forms.Button btnMedicines;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.ContextMenuStrip cmsUser;
        private System.Windows.Forms.ToolStripMenuItem emplyeeDircToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientDirectoryToolStripMenuItem;
    }
}