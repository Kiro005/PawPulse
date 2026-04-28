namespace PawPulse
{
    partial class AppointmentsUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent() {            this.topBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.btnFilterAll2 = new System.Windows.Forms.Button();
            this.btnFilterScheduled2 = new System.Windows.Forms.Button();
            this.btnFilterCompleted2 = new System.Windows.Forms.Button();
            this.btnFilterCancelled2 = new System.Windows.Forms.Button();
            this.ActionPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.ActionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.topBar.Controls.Add(this.btnFilterCancelled2);
            this.topBar.Controls.Add(this.btnFilterCompleted2);
            this.topBar.Controls.Add(this.btnFilterScheduled2);
            this.topBar.Controls.Add(this.btnFilterAll2);
            this.topBar.Controls.Add(this.lblTitle);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(848, 60);
            this.topBar.TabIndex = 12;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(208, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Appointments";
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(20, 74);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersWidth = 51;
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(808, 520);
            this.dgv2.TabIndex = 13;
            // 
            // btnFilterAll2
            // 
            this.btnFilterAll2.AutoSize = true;
            this.btnFilterAll2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnFilterAll2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterAll2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFilterAll2.ForeColor = System.Drawing.Color.White;
            this.btnFilterAll2.Location = new System.Drawing.Point(240, 12);
            this.btnFilterAll2.Name = "btnFilterAll2";
            this.btnFilterAll2.Size = new System.Drawing.Size(55, 35);
            this.btnFilterAll2.TabIndex = 1;
            this.btnFilterAll2.Text = "All";
            this.btnFilterAll2.UseVisualStyleBackColor = false;
            // 
            // btnFilterScheduled2
            // 
            this.btnFilterScheduled2.AutoSize = true;
            this.btnFilterScheduled2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.btnFilterScheduled2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterScheduled2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFilterScheduled2.ForeColor = System.Drawing.Color.White;
            this.btnFilterScheduled2.Location = new System.Drawing.Point(397, 17);
            this.btnFilterScheduled2.Name = "btnFilterScheduled2";
            this.btnFilterScheduled2.Size = new System.Drawing.Size(105, 35);
            this.btnFilterScheduled2.TabIndex = 2;
            this.btnFilterScheduled2.Text = "Scheduled";
            this.btnFilterScheduled2.UseVisualStyleBackColor = false;
            // 
            // btnFilterCompleted2
            // 
            this.btnFilterCompleted2.AutoSize = true;
            this.btnFilterCompleted2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.btnFilterCompleted2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterCompleted2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFilterCompleted2.ForeColor = System.Drawing.Color.White;
            this.btnFilterCompleted2.Location = new System.Drawing.Point(522, 17);
            this.btnFilterCompleted2.Name = "btnFilterCompleted2";
            this.btnFilterCompleted2.Size = new System.Drawing.Size(111, 35);
            this.btnFilterCompleted2.TabIndex = 3;
            this.btnFilterCompleted2.Text = "Completed";
            this.btnFilterCompleted2.UseVisualStyleBackColor = false;
            // 
            // btnFilterCancelled2
            // 
            this.btnFilterCancelled2.AutoSize = true;
            this.btnFilterCancelled2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.btnFilterCancelled2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterCancelled2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnFilterCancelled2.ForeColor = System.Drawing.Color.White;
            this.btnFilterCancelled2.Location = new System.Drawing.Point(659, 15);
            this.btnFilterCancelled2.Name = "btnFilterCancelled2";
            this.btnFilterCancelled2.Size = new System.Drawing.Size(99, 35);
            this.btnFilterCancelled2.TabIndex = 4;
            this.btnFilterCancelled2.Text = "Cancelled";
            this.btnFilterCancelled2.UseVisualStyleBackColor = false;
            this.btnFilterCancelled2.Click += new System.EventHandler(this.btnFilterCancelled2_Click);
            // 
            // ActionPanel
            // 
            this.ActionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ActionPanel.Controls.Add(this.lblHint);
            this.ActionPanel.Controls.Add(this.btnCancel2);
            this.ActionPanel.Controls.Add(this.button1);
            this.ActionPanel.Location = new System.Drawing.Point(0, 540);
            this.ActionPanel.Name = "ActionPanel";
            this.ActionPanel.Size = new System.Drawing.Size(848, 55);
            this.ActionPanel.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(20, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "✓  Approve";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCancel2
            // 
            this.btnCancel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel2.ForeColor = System.Drawing.Color.White;
            this.btnCancel2.Location = new System.Drawing.Point(165, 10);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(130, 34);
            this.btnCancel2.TabIndex = 1;
            this.btnCancel2.Text = "✕  Cancel";
            this.btnCancel2.UseVisualStyleBackColor = false;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblHint.Location = new System.Drawing.Point(315, 20);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(368, 23);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "Select a Scheduled appointment to approve.";
            // 
            // AppointmentsUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.ActionPanel);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.dgv2);
            this.Name = "AppointmentsUC";
            this.Size = new System.Drawing.Size(848, 594);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ActionPanel.ResumeLayout(false);
            this.ActionPanel.PerformLayout();
            this.ResumeLayout(false);

}
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Button btnFilterAll2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Button btnFilterCancelled2;
        private System.Windows.Forms.Button btnFilterCompleted2;
        private System.Windows.Forms.Button btnFilterScheduled2;
        private System.Windows.Forms.Panel ActionPanel;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button button1;
    }
}
