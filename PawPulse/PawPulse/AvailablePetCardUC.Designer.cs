namespace PawPulse
{
    partial class AvailablePetCardUC
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
            this.btnMedical = new System.Windows.Forms.Button();
            this.lblDetails2 = new System.Windows.Forms.Label();
            this.lblDetails1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picPetIcon = new System.Windows.Forms.PictureBox();
            this.btnAdopt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPetIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMedical
            // 
            this.btnMedical.BackColor = System.Drawing.Color.DarkOrange;
            this.btnMedical.FlatAppearance.BorderSize = 0;
            this.btnMedical.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnMedical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedical.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedical.ForeColor = System.Drawing.Color.White;
            this.btnMedical.Location = new System.Drawing.Point(458, 46);
            this.btnMedical.Name = "btnMedical";
            this.btnMedical.Size = new System.Drawing.Size(213, 41);
            this.btnMedical.TabIndex = 26;
            this.btnMedical.Text = "Medical Record";
            this.btnMedical.UseVisualStyleBackColor = false;
            this.btnMedical.Click += new System.EventHandler(this.btnMedical_Click);
            // 
            // lblDetails2
            // 
            this.lblDetails2.AutoSize = true;
            this.lblDetails2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails2.Location = new System.Drawing.Point(195, 114);
            this.lblDetails2.Name = "lblDetails2";
            this.lblDetails2.Size = new System.Drawing.Size(203, 28);
            this.lblDetails2.TabIndex = 25;
            this.lblDetails2.Text = "age yesrs old | weight";
            // 
            // lblDetails1
            // 
            this.lblDetails1.AutoSize = true;
            this.lblDetails1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails1.Location = new System.Drawing.Point(195, 76);
            this.lblDetails1.Name = "lblDetails1";
            this.lblDetails1.Size = new System.Drawing.Size(217, 28);
            this.lblDetails1.TabIndex = 24;
            this.lblDetails1.Text = "specie - breed - Gender";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(195, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 38);
            this.lblName.TabIndex = 23;
            this.lblName.Text = "Name";
            // 
            // picPetIcon
            // 
            this.picPetIcon.Location = new System.Drawing.Point(24, 19);
            this.picPetIcon.Name = "picPetIcon";
            this.picPetIcon.Size = new System.Drawing.Size(155, 147);
            this.picPetIcon.TabIndex = 22;
            this.picPetIcon.TabStop = false;
            // 
            // btnAdopt
            // 
            this.btnAdopt.BackColor = System.Drawing.Color.DarkOrange;
            this.btnAdopt.FlatAppearance.BorderSize = 0;
            this.btnAdopt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnAdopt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdopt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdopt.ForeColor = System.Drawing.Color.White;
            this.btnAdopt.Location = new System.Drawing.Point(458, 105);
            this.btnAdopt.Name = "btnAdopt";
            this.btnAdopt.Size = new System.Drawing.Size(213, 41);
            this.btnAdopt.TabIndex = 27;
            this.btnAdopt.Text = "Fill for Adoption";
            this.btnAdopt.UseVisualStyleBackColor = false;
            this.btnAdopt.Click += new System.EventHandler(this.btnAdopt_Click);
            // 
            // AvailablePetCardUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.btnAdopt);
            this.Controls.Add(this.btnMedical);
            this.Controls.Add(this.lblDetails2);
            this.Controls.Add(this.lblDetails1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPetIcon);
            this.Name = "AvailablePetCardUC";
            this.Size = new System.Drawing.Size(695, 200);
            this.Load += new System.EventHandler(this.AvailablePetCardUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPetIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnMedical;
        private System.Windows.Forms.Label lblDetails2;
        private System.Windows.Forms.Label lblDetails1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picPetIcon;
        private System.Windows.Forms.Button btnAdopt;
    }
}
