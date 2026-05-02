namespace PawPulse
{
    partial class ManageAdoptionFeesUC
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblFilterTag = new System.Windows.Forms.Label();
            this.lblSearchTag = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnِSet = new System.Windows.Forms.Button();
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.dgvFees = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblState = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 75);
            this.panel1.TabIndex = 73;
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
            this.lblDate.Tag = "Header";
            this.lblDate.Text = "--/--/----";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblWelcome.Location = new System.Drawing.Point(29, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(206, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Tag = "Header";
            this.lblWelcome.Text = "Adoption Fees";
            // 
            // lblFilterTag
            // 
            this.lblFilterTag.AutoSize = true;
            this.lblFilterTag.Location = new System.Drawing.Point(255, 18);
            this.lblFilterTag.Name = "lblFilterTag";
            this.lblFilterTag.Size = new System.Drawing.Size(38, 16);
            this.lblFilterTag.TabIndex = 72;
            this.lblFilterTag.Text = "Fees";
            // 
            // lblSearchTag
            // 
            this.lblSearchTag.AutoSize = true;
            this.lblSearchTag.Location = new System.Drawing.Point(19, 18);
            this.lblSearchTag.Name = "lblSearchTag";
            this.lblSearchTag.Size = new System.Drawing.Size(57, 16);
            this.lblSearchTag.TabIndex = 79;
            this.lblSearchTag.Text = "Species";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(745, 178);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 51);
            this.btnClear.TabIndex = 78;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnِSet
            // 
            this.btnِSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnِSet.FlatAppearance.BorderSize = 0;
            this.btnِSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnِSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnِSet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnِSet.ForeColor = System.Drawing.Color.White;
            this.btnِSet.Location = new System.Drawing.Point(550, 178);
            this.btnِSet.Name = "btnِSet";
            this.btnِSet.Size = new System.Drawing.Size(156, 48);
            this.btnِSet.TabIndex = 77;
            this.btnِSet.Text = "SET FEES";
            this.btnِSet.UseVisualStyleBackColor = false;
            this.btnِSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecies.FormattingEnabled = true;
            this.cmbSpecies.Location = new System.Drawing.Point(6, 41);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(205, 24);
            this.cmbSpecies.TabIndex = 76;
            this.cmbSpecies.SelectedIndexChanged += new System.EventHandler(this.cmbSpecies_SelectedIndexChanged);
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(258, 41);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(203, 22);
            this.txtFees.TabIndex = 75;
            // 
            // dgvFees
            // 
            this.dgvFees.AllowUserToAddRows = false;
            this.dgvFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFees.EnableHeadersVisualStyles = false;
            this.dgvFees.Location = new System.Drawing.Point(47, 288);
            this.dgvFees.Name = "dgvFees";
            this.dgvFees.ReadOnly = true;
            this.dgvFees.RowHeadersVisible = false;
            this.dgvFees.RowHeadersWidth = 51;
            this.dgvFees.RowTemplate.Height = 24;
            this.dgvFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFees.Size = new System.Drawing.Size(576, 265);
            this.dgvFees.TabIndex = 74;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSpecies);
            this.groupBox1.Controls.Add(this.txtFees);
            this.groupBox1.Controls.Add(this.lblSearchTag);
            this.groupBox1.Controls.Add(this.lblFilterTag);
            this.groupBox1.Location = new System.Drawing.Point(51, 153);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 96);
            this.groupBox1.TabIndex = 83;
            this.groupBox1.TabStop = false;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = System.Drawing.Color.Red;
            this.lblState.Location = new System.Drawing.Point(54, 252);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(113, 16);
            this.lblState.TabIndex = 84;
            this.lblState.Text = "Status notificatiion";
            // 
            // ManageAdoptionFeesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnِSet);
            this.Controls.Add(this.dgvFees);
            this.Name = "ManageAdoptionFeesUC";
            this.Size = new System.Drawing.Size(932, 606);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblFilterTag;
        private System.Windows.Forms.Label lblSearchTag;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnِSet;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.DataGridView dgvFees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblState;
    }
}
