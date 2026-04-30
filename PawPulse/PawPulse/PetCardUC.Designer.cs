namespace PawPulse
{
    partial class PetCardUC
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
            this.picPetIcon = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBreed = new System.Windows.Forms.Label();
            this.lblStats = new System.Windows.Forms.Label();
            this.btnMedical = new System.Windows.Forms.Button();
            this.btnBookAppointment = new System.Windows.Forms.Button();
            this.btnUpdatePet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPetIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // picPetIcon
            // 
            this.picPetIcon.Location = new System.Drawing.Point(15, 20);
            this.picPetIcon.Name = "picPetIcon";
            this.picPetIcon.Size = new System.Drawing.Size(155, 147);
            this.picPetIcon.TabIndex = 0;
            this.picPetIcon.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(191, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 38);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblBreed
            // 
            this.lblBreed.AutoSize = true;
            this.lblBreed.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBreed.Location = new System.Drawing.Point(191, 73);
            this.lblBreed.Name = "lblBreed";
            this.lblBreed.Size = new System.Drawing.Size(134, 28);
            this.lblBreed.TabIndex = 2;
            this.lblBreed.Text = "specie - breed";
            // 
            // lblStats
            // 
            this.lblStats.AutoSize = true;
            this.lblStats.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStats.Location = new System.Drawing.Point(191, 111);
            this.lblStats.Name = "lblStats";
            this.lblStats.Size = new System.Drawing.Size(203, 28);
            this.lblStats.TabIndex = 3;
            this.lblStats.Text = "age yesrs old | weight";
            // 
            // btnMedical
            // 
            this.btnMedical.BackColor = System.Drawing.Color.DarkOrange;
            this.btnMedical.FlatAppearance.BorderSize = 0;
            this.btnMedical.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnMedical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedical.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedical.ForeColor = System.Drawing.Color.White;
            this.btnMedical.Location = new System.Drawing.Point(449, 24);
            this.btnMedical.Name = "btnMedical";
            this.btnMedical.Size = new System.Drawing.Size(213, 41);
            this.btnMedical.TabIndex = 18;
            this.btnMedical.Text = "Medical Record";
            this.btnMedical.UseVisualStyleBackColor = false;
            this.btnMedical.Click += new System.EventHandler(this.btnMedical_Click);
            // 
            // btnBookAppointment
            // 
            this.btnBookAppointment.BackColor = System.Drawing.Color.DarkOrange;
            this.btnBookAppointment.FlatAppearance.BorderSize = 0;
            this.btnBookAppointment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnBookAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookAppointment.ForeColor = System.Drawing.Color.White;
            this.btnBookAppointment.Location = new System.Drawing.Point(449, 83);
            this.btnBookAppointment.Name = "btnBookAppointment";
            this.btnBookAppointment.Size = new System.Drawing.Size(213, 41);
            this.btnBookAppointment.TabIndex = 19;
            this.btnBookAppointment.Text = "+ Add Appointment";
            this.btnBookAppointment.UseVisualStyleBackColor = false;
            this.btnBookAppointment.Click += new System.EventHandler(this.btnBookAppointment_Click);
            // 
            // btnUpdatePet
            // 
            this.btnUpdatePet.BackColor = System.Drawing.Color.DarkOrange;
            this.btnUpdatePet.FlatAppearance.BorderSize = 0;
            this.btnUpdatePet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnUpdatePet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePet.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePet.Location = new System.Drawing.Point(449, 141);
            this.btnUpdatePet.Name = "btnUpdatePet";
            this.btnUpdatePet.Size = new System.Drawing.Size(213, 41);
            this.btnUpdatePet.TabIndex = 20;
            this.btnUpdatePet.Text = "Edit Infos";
            this.btnUpdatePet.UseVisualStyleBackColor = false;
            this.btnUpdatePet.Click += new System.EventHandler(this.btnUpdatePet_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.OrangeRed;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(333, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PetCardUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUpdatePet);
            this.Controls.Add(this.btnBookAppointment);
            this.Controls.Add(this.btnMedical);
            this.Controls.Add(this.lblStats);
            this.Controls.Add(this.lblBreed);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPetIcon);
            this.Name = "PetCardUC";
            this.Size = new System.Drawing.Size(695, 200);
            ((System.ComponentModel.ISupportInitialize)(this.picPetIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPetIcon;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.Label lblStats;
        private System.Windows.Forms.Button btnMedical;
        private System.Windows.Forms.Button btnBookAppointment;
        private System.Windows.Forms.Button btnUpdatePet;
        private System.Windows.Forms.Button button1;
    }
}
