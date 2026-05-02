namespace PawPulse
{
    partial class MyRequestCardUC
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMedical = new System.Windows.Forms.Button();
            this.lblDetails2 = new System.Windows.Forms.Label();
            this.lblDetails1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.picPetIcon = new System.Windows.Forms.PictureBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPetIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.OrangeRed;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(458, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(213, 41);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel Request";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMedical
            // 
            this.btnMedical.BackColor = System.Drawing.Color.DarkOrange;
            this.btnMedical.FlatAppearance.BorderSize = 0;
            this.btnMedical.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Coral;
            this.btnMedical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedical.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMedical.ForeColor = System.Drawing.Color.White;
            this.btnMedical.Location = new System.Drawing.Point(458, 33);
            this.btnMedical.Name = "btnMedical";
            this.btnMedical.Size = new System.Drawing.Size(213, 41);
            this.btnMedical.TabIndex = 32;
            this.btnMedical.Text = "Medical Record";
            this.btnMedical.UseVisualStyleBackColor = false;
            this.btnMedical.Click += new System.EventHandler(this.btnMedical_Click);
            // 
            // lblDetails2
            // 
            this.lblDetails2.AutoSize = true;
            this.lblDetails2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails2.Location = new System.Drawing.Point(197, 106);
            this.lblDetails2.Name = "lblDetails2";
            this.lblDetails2.Size = new System.Drawing.Size(203, 28);
            this.lblDetails2.TabIndex = 31;
            this.lblDetails2.Text = "age yesrs old | weight";
            // 
            // lblDetails1
            // 
            this.lblDetails1.AutoSize = true;
            this.lblDetails1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails1.Location = new System.Drawing.Point(195, 71);
            this.lblDetails1.Name = "lblDetails1";
            this.lblDetails1.Size = new System.Drawing.Size(217, 28);
            this.lblDetails1.TabIndex = 30;
            this.lblDetails1.Text = "specie - breed - Gender";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI Black", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(195, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(99, 38);
            this.lblName.TabIndex = 29;
            this.lblName.Text = "Name";
            // 
            // picPetIcon
            // 
            this.picPetIcon.Location = new System.Drawing.Point(24, 27);
            this.picPetIcon.Name = "picPetIcon";
            this.picPetIcon.Size = new System.Drawing.Size(155, 147);
            this.picPetIcon.TabIndex = 28;
            this.picPetIcon.TabStop = false;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(197, 146);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(237, 28);
            this.lblDate.TabIndex = 34;
            this.lblDate.Text = "Application Date: --------";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(474, 139);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(171, 38);
            this.lblStatus.TabIndex = 35;
            this.lblStatus.Text = "Status: -----";
            // 
            // MyRequestCardUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnMedical);
            this.Controls.Add(this.lblDetails2);
            this.Controls.Add(this.lblDetails1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.picPetIcon);
            this.Name = "MyRequestCardUC";
            this.Size = new System.Drawing.Size(695, 200);
            ((System.ComponentModel.ISupportInitialize)(this.picPetIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMedical;
        private System.Windows.Forms.Label lblDetails2;
        private System.Windows.Forms.Label lblDetails1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picPetIcon;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStatus;
    }
}
