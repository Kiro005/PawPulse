namespace PawPulse
{
    partial class ShelterStaffDashboardForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.btnRegisterAnimal = new System.Windows.Forms.Button();
            this.btnHealthChecks = new System.Windows.Forms.Button();
            this.btnAdoptions = new System.Windows.Forms.Button();
            this.btnManageKennels = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnHealthChecks);
            this.panel1.Controls.Add(this.btnAdoptions);
            this.panel1.Controls.Add(this.btnManageKennels);
            this.panel1.Controls.Add(this.btnInvoices);
            this.panel1.Controls.Add(this.btnRegisterAnimal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 592);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(224, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 91);
            this.panel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Turquoise;
            this.label1.Location = new System.Drawing.Point(299, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shelter Staff";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1024, 592);
            this.pnlMainContent.TabIndex = 7;
            // 
            // btnInvoices
            // 
            this.btnInvoices.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnInvoices.Location = new System.Drawing.Point(0, 397);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(221, 53);
            this.btnInvoices.TabIndex = 6;
            this.btnInvoices.Text = "Invoices";
            this.btnInvoices.UseVisualStyleBackColor = true;
            // 
            // btnRegisterAnimal
            // 
            this.btnRegisterAnimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnRegisterAnimal.Location = new System.Drawing.Point(3, 224);
            this.btnRegisterAnimal.Name = "btnRegisterAnimal";
            this.btnRegisterAnimal.Size = new System.Drawing.Size(221, 53);
            this.btnRegisterAnimal.TabIndex = 7;
            this.btnRegisterAnimal.Text = "Register Animal";
            this.btnRegisterAnimal.UseVisualStyleBackColor = true;
            // 
            // btnHealthChecks
            // 
            this.btnHealthChecks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.btnHealthChecks.Location = new System.Drawing.Point(0, 473);
            this.btnHealthChecks.Name = "btnHealthChecks";
            this.btnHealthChecks.Size = new System.Drawing.Size(221, 53);
            this.btnHealthChecks.TabIndex = 8;
            this.btnHealthChecks.Text = "Health Checks";
            this.btnHealthChecks.UseVisualStyleBackColor = true;
            // 
            // btnAdoptions
            // 
            this.btnAdoptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btnAdoptions.Location = new System.Drawing.Point(0, 136);
            this.btnAdoptions.Name = "btnAdoptions";
            this.btnAdoptions.Size = new System.Drawing.Size(224, 53);
            this.btnAdoptions.TabIndex = 9;
            this.btnAdoptions.Text = "Adoptions";
            this.btnAdoptions.UseVisualStyleBackColor = true;
            // 
            // btnManageKennels
            // 
            this.btnManageKennels.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.btnManageKennels.Location = new System.Drawing.Point(0, 318);
            this.btnManageKennels.Name = "btnManageKennels";
            this.btnManageKennels.Size = new System.Drawing.Size(221, 53);
            this.btnManageKennels.TabIndex = 10;
            this.btnManageKennels.Text = "Manage Kennels";
            this.btnManageKennels.UseVisualStyleBackColor = true;
            // 
            // ShelterStaffDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 592);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlMainContent);
            this.Name = "ShelterStaffDashboardForm";
            this.Text = "ShelterStaffDashboardForm";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Button btnInvoices;
        private System.Windows.Forms.Button btnRegisterAnimal;
        private System.Windows.Forms.Button btnManageKennels;
        private System.Windows.Forms.Button btnAdoptions;
        private System.Windows.Forms.Button btnHealthChecks;
    }
}