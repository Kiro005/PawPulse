namespace PawPulse
{
    partial class AdoptionClientUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAddoption = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabMyApplications = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowAvailable = new System.Windows.Forms.FlowLayoutPanel();
            this.tabAvailablePets = new System.Windows.Forms.TabPage();
            this.flowMyRequests = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabMyApplications.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabAvailablePets.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblAddoption);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 75);
            this.panel1.TabIndex = 16;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDate.Location = new System.Drawing.Point(671, 25);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(106, 31);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "--/--/----";
            // 
            // lblAddoption
            // 
            this.lblAddoption.AutoSize = true;
            this.lblAddoption.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddoption.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblAddoption.Location = new System.Drawing.Point(29, 18);
            this.lblAddoption.Name = "lblAddoption";
            this.lblAddoption.Size = new System.Drawing.Size(235, 38);
            this.lblAddoption.TabIndex = 0;
            this.lblAddoption.Text = "Adoption Center";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabMyApplications);
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 522);
            this.panel2.TabIndex = 17;
            // 
            // tabMyApplications
            // 
            this.tabMyApplications.Controls.Add(this.tabPage1);
            this.tabMyApplications.Controls.Add(this.tabAvailablePets);
            this.tabMyApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMyApplications.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMyApplications.Location = new System.Drawing.Point(0, 0);
            this.tabMyApplications.Name = "tabMyApplications";
            this.tabMyApplications.SelectedIndex = 0;
            this.tabMyApplications.Size = new System.Drawing.Size(848, 522);
            this.tabMyApplications.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowAvailable);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(840, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Available Pets";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowAvailable
            // 
            this.flowAvailable.AutoScroll = true;
            this.flowAvailable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowAvailable.Location = new System.Drawing.Point(68, 29);
            this.flowAvailable.Name = "flowAvailable";
            this.flowAvailable.Size = new System.Drawing.Size(705, 457);
            this.flowAvailable.TabIndex = 17;
            // 
            // tabAvailablePets
            // 
            this.tabAvailablePets.Controls.Add(this.flowMyRequests);
            this.tabAvailablePets.Location = new System.Drawing.Point(4, 32);
            this.tabAvailablePets.Name = "tabAvailablePets";
            this.tabAvailablePets.Padding = new System.Windows.Forms.Padding(3);
            this.tabAvailablePets.Size = new System.Drawing.Size(840, 486);
            this.tabAvailablePets.TabIndex = 1;
            this.tabAvailablePets.Text = "My Requests";
            this.tabAvailablePets.UseVisualStyleBackColor = true;
            // 
            // flowMyRequests
            // 
            this.flowMyRequests.AutoScroll = true;
            this.flowMyRequests.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowMyRequests.Location = new System.Drawing.Point(70, 29);
            this.flowMyRequests.Name = "flowMyRequests";
            this.flowMyRequests.Size = new System.Drawing.Size(700, 457);
            this.flowMyRequests.TabIndex = 18;
            // 
            // AdoptionClientUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "AdoptionClientUC";
            this.Size = new System.Drawing.Size(848, 594);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabMyApplications.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabAvailablePets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAddoption;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabMyApplications;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabAvailablePets;
        private System.Windows.Forms.FlowLayoutPanel flowAvailable;
        private System.Windows.Forms.FlowLayoutPanel flowMyRequests;
    }
}
