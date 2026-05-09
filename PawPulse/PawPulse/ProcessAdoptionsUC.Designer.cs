namespace PawPulse
{
    partial class ProcessAdoptionsUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPendingAdoptions = new System.Windows.Forms.DataGridView();
            this.btnApprove = new MaterialSkin.Controls.MaterialButton();
            this.btnReject = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingAdoptions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(26, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pending Adoption Applications";
            // 
            // dgvPendingAdoptions
            // 
            this.dgvPendingAdoptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendingAdoptions.Location = new System.Drawing.Point(3, 124);
            this.dgvPendingAdoptions.Name = "dgvPendingAdoptions";
            this.dgvPendingAdoptions.RowHeadersWidth = 62;
            this.dgvPendingAdoptions.RowTemplate.Height = 28;
            this.dgvPendingAdoptions.Size = new System.Drawing.Size(976, 305);
            this.dgvPendingAdoptions.TabIndex = 1;
            // 
            // btnApprove
            // 
            this.btnApprove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnApprove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnApprove.Depth = 0;
            this.btnApprove.HighEmphasis = true;
            this.btnApprove.Icon = null;
            this.btnApprove.Location = new System.Drawing.Point(226, 466);
            this.btnApprove.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnApprove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnApprove.Size = new System.Drawing.Size(174, 36);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "Accept Application";
            this.btnApprove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnApprove.UseAccentColor = false;
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReject.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReject.Depth = 0;
            this.btnReject.HighEmphasis = true;
            this.btnReject.Icon = null;
            this.btnReject.Location = new System.Drawing.Point(642, 466);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReject.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReject.Name = "btnReject";
            this.btnReject.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReject.Size = new System.Drawing.Size(172, 36);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "Reject Application";
            this.btnReject.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReject.UseAccentColor = false;
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // ProcessAdoptionsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.dgvPendingAdoptions);
            this.Controls.Add(this.label1);
            this.Name = "ProcessAdoptionsUC";
            this.Size = new System.Drawing.Size(998, 559);
            this.Load += new System.EventHandler(this.ProcessAdoptionsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingAdoptions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPendingAdoptions;
        private MaterialSkin.Controls.MaterialButton btnApprove;
        private MaterialSkin.Controls.MaterialButton btnReject;
    }
}
