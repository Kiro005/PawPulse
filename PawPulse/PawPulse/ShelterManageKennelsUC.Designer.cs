namespace PawPulse
{
    partial class ShelterManageKennelsUC
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
            this.dgvKennels = new System.Windows.Forms.DataGridView();
            this.cmbUnassignedAnimals = new System.Windows.Forms.ComboBox();
            this.btnAssign = new MaterialSkin.Controls.MaterialButton();
            this.btnRemove = new MaterialSkin.Controls.MaterialButton();
            this.btnUpdateStatus = new MaterialSkin.Controls.MaterialButton();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKennels)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKennels
            // 
            this.dgvKennels.ColumnHeadersHeight = 34;
            this.dgvKennels.Location = new System.Drawing.Point(23, 225);
            this.dgvKennels.Name = "dgvKennels";
            this.dgvKennels.RowHeadersWidth = 62;
            this.dgvKennels.Size = new System.Drawing.Size(952, 320);
            this.dgvKennels.TabIndex = 0;
            // 
            // cmbUnassignedAnimals
            // 
            this.cmbUnassignedAnimals.FormattingEnabled = true;
            this.cmbUnassignedAnimals.Location = new System.Drawing.Point(318, 37);
            this.cmbUnassignedAnimals.Name = "cmbUnassignedAnimals";
            this.cmbUnassignedAnimals.Size = new System.Drawing.Size(121, 28);
            this.cmbUnassignedAnimals.TabIndex = 1;
            this.cmbUnassignedAnimals.SelectedIndexChanged += new System.EventHandler(this.cmbUnassignedAnimals_SelectedIndexChanged);
            // 
            // btnAssign
            // 
            this.btnAssign.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAssign.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAssign.Depth = 0;
            this.btnAssign.HighEmphasis = true;
            this.btnAssign.Icon = null;
            this.btnAssign.Location = new System.Drawing.Point(771, 130);
            this.btnAssign.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAssign.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAssign.Size = new System.Drawing.Size(214, 36);
            this.btnAssign.TabIndex = 2;
            this.btnAssign.Text = "Assign animal to kennel";
            this.btnAssign.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAssign.UseAccentColor = false;
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemove.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRemove.Depth = 0;
            this.btnRemove.HighEmphasis = true;
            this.btnRemove.Icon = null;
            this.btnRemove.Location = new System.Drawing.Point(383, 130);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemove.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnRemove.Size = new System.Drawing.Size(242, 36);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove animal from kennel";
            this.btnRemove.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnRemove.UseAccentColor = false;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnUpdateStatus.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnUpdateStatus.Depth = 0;
            this.btnUpdateStatus.HighEmphasis = true;
            this.btnUpdateStatus.Icon = null;
            this.btnUpdateStatus.Location = new System.Drawing.Point(23, 130);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnUpdateStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnUpdateStatus.Size = new System.Drawing.Size(210, 36);
            this.btnUpdateStatus.TabIndex = 4;
            this.btnUpdateStatus.Text = "Update cleaning status";
            this.btnUpdateStatus.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnUpdateStatus.UseAccentColor = false;
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Available",
            "Needs Cleaning"});
            this.cmbStatus.Location = new System.Drawing.Point(854, 41);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 28);
            this.cmbStatus.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(34, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select Unassigned Animal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(610, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select Cleaning Status:";
            // 
            // ShelterManageKennelsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.cmbUnassignedAnimals);
            this.Controls.Add(this.dgvKennels);
            this.Name = "ShelterManageKennelsUC";
            this.Size = new System.Drawing.Size(998, 559);
            this.Load += new System.EventHandler(this.ShelterManageKennelsUC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKennels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKennels;
        private System.Windows.Forms.ComboBox cmbUnassignedAnimals;
        private MaterialSkin.Controls.MaterialButton btnAssign;
        private MaterialSkin.Controls.MaterialButton btnRemove;
        private MaterialSkin.Controls.MaterialButton btnUpdateStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
