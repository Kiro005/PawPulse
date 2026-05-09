namespace PawPulse
{
    partial class ManageMedicinesUC
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
            this.dltMedicine = new System.Windows.Forms.Button();
            this.lblFilterTag = new System.Windows.Forms.Label();
            this.lblSearchTag = new System.Windows.Forms.Label();
            this.btnEditMedicine = new System.Windows.Forms.Button();
            this.btnِAddMedicine = new System.Windows.Forms.Button();
            this.cmbTypeFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.dgvMedicine = new System.Windows.Forms.DataGridView();
            this.btnManageSup = new System.Windows.Forms.Button();
            this.btnresupply = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).BeginInit();
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
            this.panel1.TabIndex = 62;
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
            this.lblDate.Text = "--/--/----";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblWelcome.Location = new System.Drawing.Point(29, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(137, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Medicine";
            // 
            // dltMedicine
            // 
            this.dltMedicine.BackColor = System.Drawing.Color.Red;
            this.dltMedicine.FlatAppearance.BorderSize = 0;
            this.dltMedicine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.dltMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dltMedicine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dltMedicine.ForeColor = System.Drawing.Color.White;
            this.dltMedicine.Location = new System.Drawing.Point(771, 489);
            this.dltMedicine.Name = "dltMedicine";
            this.dltMedicine.Size = new System.Drawing.Size(156, 71);
            this.dltMedicine.TabIndex = 69;
            this.dltMedicine.Text = "× Remove Medicine";
            this.dltMedicine.UseVisualStyleBackColor = false;
            this.dltMedicine.Click += new System.EventHandler(this.dltMedicine_Click);
            // 
            // lblFilterTag
            // 
            this.lblFilterTag.AutoSize = true;
            this.lblFilterTag.Location = new System.Drawing.Point(33, 158);
            this.lblFilterTag.Name = "lblFilterTag";
            this.lblFilterTag.Size = new System.Drawing.Size(113, 16);
            this.lblFilterTag.TabIndex = 61;
            this.lblFilterTag.Text = "FILTER BY TYPE";
            // 
            // lblSearchTag
            // 
            this.lblSearchTag.AutoSize = true;
            this.lblSearchTag.Location = new System.Drawing.Point(23, 99);
            this.lblSearchTag.Name = "lblSearchTag";
            this.lblSearchTag.Size = new System.Drawing.Size(129, 16);
            this.lblSearchTag.TabIndex = 68;
            this.lblSearchTag.Text = "SEARCH BY NAME ";
            // 
            // btnEditMedicine
            // 
            this.btnEditMedicine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnEditMedicine.FlatAppearance.BorderSize = 0;
            this.btnEditMedicine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEditMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMedicine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditMedicine.ForeColor = System.Drawing.Color.White;
            this.btnEditMedicine.Location = new System.Drawing.Point(768, 332);
            this.btnEditMedicine.Name = "btnEditMedicine";
            this.btnEditMedicine.Size = new System.Drawing.Size(156, 51);
            this.btnEditMedicine.TabIndex = 67;
            this.btnEditMedicine.Text = "✎ Edit Medicine";
            this.btnEditMedicine.UseVisualStyleBackColor = false;
            this.btnEditMedicine.Click += new System.EventHandler(this.btnEditMedicine_Click);
            // 
            // btnِAddMedicine
            // 
            this.btnِAddMedicine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnِAddMedicine.FlatAppearance.BorderSize = 0;
            this.btnِAddMedicine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnِAddMedicine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnِAddMedicine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnِAddMedicine.ForeColor = System.Drawing.Color.White;
            this.btnِAddMedicine.Location = new System.Drawing.Point(768, 252);
            this.btnِAddMedicine.Name = "btnِAddMedicine";
            this.btnِAddMedicine.Size = new System.Drawing.Size(156, 48);
            this.btnِAddMedicine.TabIndex = 66;
            this.btnِAddMedicine.Text = "+ Add Medicine";
            this.btnِAddMedicine.UseVisualStyleBackColor = false;
            this.btnِAddMedicine.Click += new System.EventHandler(this.btnAddMedicine_Click);
            // 
            // cmbTypeFilter
            // 
            this.cmbTypeFilter.FormattingEnabled = true;
            this.cmbTypeFilter.Location = new System.Drawing.Point(26, 177);
            this.cmbTypeFilter.Name = "cmbTypeFilter";
            this.cmbTypeFilter.Size = new System.Drawing.Size(205, 24);
            this.cmbTypeFilter.TabIndex = 65;
            this.cmbTypeFilter.SelectedIndexChanged += new System.EventHandler(this.cmbTypeFilter_SelectedIndexChanged);
            this.cmbTypeFilter.Click += new System.EventHandler(this.cmbTypeFilter_SelectedIndexChanged);
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Location = new System.Drawing.Point(24, 118);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Size = new System.Drawing.Size(328, 22);
            this.txtSearchUser.TabIndex = 64;
            this.txtSearchUser.Click += new System.EventHandler(this.txtSearchUser_TextChanged);
            this.txtSearchUser.TextChanged += new System.EventHandler(this.txtSearchUser_TextChanged);
            // 
            // dgvMedicine
            // 
            this.dgvMedicine.AllowUserToAddRows = false;
            this.dgvMedicine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicine.EnableHeadersVisualStyles = false;
            this.dgvMedicine.Location = new System.Drawing.Point(3, 243);
            this.dgvMedicine.Name = "dgvMedicine";
            this.dgvMedicine.ReadOnly = true;
            this.dgvMedicine.RowHeadersVisible = false;
            this.dgvMedicine.RowHeadersWidth = 51;
            this.dgvMedicine.RowTemplate.Height = 24;
            this.dgvMedicine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicine.Size = new System.Drawing.Size(758, 332);
            this.dgvMedicine.TabIndex = 63;
            // 
            // btnManageSup
            // 
            this.btnManageSup.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnManageSup.FlatAppearance.BorderSize = 0;
            this.btnManageSup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnManageSup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageSup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageSup.ForeColor = System.Drawing.Color.White;
            this.btnManageSup.Location = new System.Drawing.Point(575, 118);
            this.btnManageSup.Name = "btnManageSup";
            this.btnManageSup.Size = new System.Drawing.Size(246, 56);
            this.btnManageSup.TabIndex = 70;
            this.btnManageSup.Text = "Manage Suppliers";
            this.btnManageSup.UseVisualStyleBackColor = false;
            this.btnManageSup.Click += new System.EventHandler(this.btnManageSup_Click);
            // 
            // btnresupply
            // 
            this.btnresupply.BackColor = System.Drawing.Color.Yellow;
            this.btnresupply.FlatAppearance.BorderSize = 0;
            this.btnresupply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnresupply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnresupply.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnresupply.ForeColor = System.Drawing.Color.Black;
            this.btnresupply.Location = new System.Drawing.Point(768, 400);
            this.btnresupply.Name = "btnresupply";
            this.btnresupply.Size = new System.Drawing.Size(156, 71);
            this.btnresupply.TabIndex = 71;
            this.btnresupply.Text = "Resupply";
            this.btnresupply.UseVisualStyleBackColor = false;
            this.btnresupply.Click += new System.EventHandler(this.btnresupply_Click);
            // 
            // ManageMedicinesUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnresupply);
            this.Controls.Add(this.btnManageSup);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dltMedicine);
            this.Controls.Add(this.lblFilterTag);
            this.Controls.Add(this.lblSearchTag);
            this.Controls.Add(this.btnEditMedicine);
            this.Controls.Add(this.btnِAddMedicine);
            this.Controls.Add(this.cmbTypeFilter);
            this.Controls.Add(this.txtSearchUser);
            this.Controls.Add(this.dgvMedicine);
            this.Name = "ManageMedicinesUC";
            this.Size = new System.Drawing.Size(932, 606);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button dltMedicine;
        private System.Windows.Forms.Label lblFilterTag;
        private System.Windows.Forms.Label lblSearchTag;
        private System.Windows.Forms.Button btnEditMedicine;
        private System.Windows.Forms.Button btnِAddMedicine;
        private System.Windows.Forms.ComboBox cmbTypeFilter;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.DataGridView dgvMedicine;
        private System.Windows.Forms.Button btnManageSup;
        private System.Windows.Forms.Button btnresupply;
    }
}
