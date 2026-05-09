namespace PawPulse
{
    partial class ManageAdoptionFeesShelterUC
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
            this.lblSearchTag = new System.Windows.Forms.Label();
            this.lblFilterTag = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.cmbSpecies = new System.Windows.Forms.ComboBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvFees = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 94);
            this.panel1.TabIndex = 85;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDate.Location = new System.Drawing.Point(755, 31);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(129, 38);
            this.lblDate.TabIndex = 1;
            this.lblDate.Tag = "Header";
            this.lblDate.Text = "--/--/----";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblWelcome.Location = new System.Drawing.Point(79, 31);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(242, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Tag = "Header";
            this.lblWelcome.Text = "Adoption Fees";
            // 
            // lblSearchTag
            // 
            this.lblSearchTag.AutoSize = true;
            this.lblSearchTag.Location = new System.Drawing.Point(97, 22);
            this.lblSearchTag.Name = "lblSearchTag";
            this.lblSearchTag.Size = new System.Drawing.Size(66, 20);
            this.lblSearchTag.TabIndex = 79;
            this.lblSearchTag.Text = "Species";
            // 
            // lblFilterTag
            // 
            this.lblFilterTag.AutoSize = true;
            this.lblFilterTag.Location = new System.Drawing.Point(333, 22);
            this.lblFilterTag.Name = "lblFilterTag";
            this.lblFilterTag.Size = new System.Drawing.Size(45, 20);
            this.lblFilterTag.TabIndex = 72;
            this.lblFilterTag.Text = "Fees";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(831, 165);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(136, 44);
            this.btnClear.TabIndex = 88;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSet
            // 
            this.btnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.ForeColor = System.Drawing.Color.White;
            this.btnSet.Location = new System.Drawing.Point(605, 165);
            this.btnSet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(166, 44);
            this.btnSet.TabIndex = 87;
            this.btnSet.Text = "SET FEES";
            this.btnSet.UseVisualStyleBackColor = false;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cmbSpecies
            // 
            this.cmbSpecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecies.FormattingEnabled = true;
            this.cmbSpecies.Location = new System.Drawing.Point(101, 51);
            this.cmbSpecies.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbSpecies.Name = "cmbSpecies";
            this.cmbSpecies.Size = new System.Drawing.Size(174, 28);
            this.cmbSpecies.TabIndex = 76;
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(312, 51);
            this.txtFees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(177, 26);
            this.txtFees.TabIndex = 75;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSpecies);
            this.groupBox1.Controls.Add(this.txtFees);
            this.groupBox1.Controls.Add(this.lblSearchTag);
            this.groupBox1.Controls.Add(this.lblFilterTag);
            this.groupBox1.Location = new System.Drawing.Point(46, 136);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(495, 105);
            this.groupBox1.TabIndex = 89;
            this.groupBox1.TabStop = false;
            // 
            // dgvFees
            // 
            this.dgvFees.AllowUserToAddRows = false;
            this.dgvFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFees.EnableHeadersVisualStyles = false;
            this.dgvFees.Location = new System.Drawing.Point(62, 249);
            this.dgvFees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvFees.Name = "dgvFees";
            this.dgvFees.ReadOnly = true;
            this.dgvFees.RowHeadersVisible = false;
            this.dgvFees.RowHeadersWidth = 51;
            this.dgvFees.RowTemplate.Height = 24;
            this.dgvFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFees.Size = new System.Drawing.Size(866, 297);
            this.dgvFees.TabIndex = 86;
            this.dgvFees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFees_CellContentClick);
            // 
            // ManageAdoptionFeesShelterUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvFees);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ManageAdoptionFeesShelterUC";
            this.Size = new System.Drawing.Size(998, 559);
            this.Load += new System.EventHandler(this.ManageAdoptionFeesShelterUC_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSearchTag;
        private System.Windows.Forms.Label lblFilterTag;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.ComboBox cmbSpecies;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFees;
    }
}
