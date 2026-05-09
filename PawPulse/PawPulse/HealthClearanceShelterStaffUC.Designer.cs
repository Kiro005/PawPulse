namespace PawPulse
{
    partial class HealthClearanceShelterStaffUC
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
            this.dgvClearance = new System.Windows.Forms.DataGridView();
            this.topBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClearance)).BeginInit();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClearance
            // 
            this.dgvClearance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClearance.Location = new System.Drawing.Point(16, 86);
            this.dgvClearance.Name = "dgvClearance";
            this.dgvClearance.RowHeadersWidth = 51;
            this.dgvClearance.RowTemplate.Height = 24;
            this.dgvClearance.Size = new System.Drawing.Size(979, 470);
            this.dgvClearance.TabIndex = 5;
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.topBar.Controls.Add(this.lblTitle);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(998, 60);
            this.topBar.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(171, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(269, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Registered Animals";
            // 
            // HealthClearanceShelterStaffUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvClearance);
            this.Controls.Add(this.topBar);
            this.Name = "HealthClearanceShelterStaffUC";
            this.Size = new System.Drawing.Size(998, 559);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClearance)).EndInit();
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClearance;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Label lblTitle;
    }
}
