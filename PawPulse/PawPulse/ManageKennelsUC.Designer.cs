namespace PawPulse
{
    partial class ManageKennelsUC
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
            this.btndlt = new System.Windows.Forms.Button();
            this.lblFilterTag = new System.Windows.Forms.Label();
            this.lblSearchTag = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbFilterCategory = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvKennels = new System.Windows.Forms.DataGridView();
            this.lblDetails = new System.Windows.Forms.Label();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.btnreassign = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKennels)).BeginInit();
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
            this.lblDate.Text = "--/--/----";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblWelcome.Location = new System.Drawing.Point(29, 18);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(119, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Kennels";
            // 
            // btndlt
            // 
            this.btndlt.BackColor = System.Drawing.Color.Red;
            this.btndlt.FlatAppearance.BorderSize = 0;
            this.btndlt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btndlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndlt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndlt.ForeColor = System.Drawing.Color.White;
            this.btndlt.Location = new System.Drawing.Point(771, 524);
            this.btndlt.Name = "btndlt";
            this.btndlt.Size = new System.Drawing.Size(156, 52);
            this.btndlt.TabIndex = 80;
            this.btndlt.Text = "× Remove ";
            this.btndlt.UseVisualStyleBackColor = false;
            this.btndlt.Click += new System.EventHandler(this.btndlt_Click);
            // 
            // lblFilterTag
            // 
            this.lblFilterTag.AutoSize = true;
            this.lblFilterTag.Location = new System.Drawing.Point(553, 113);
            this.lblFilterTag.Name = "lblFilterTag";
            this.lblFilterTag.Size = new System.Drawing.Size(152, 16);
            this.lblFilterTag.TabIndex = 72;
            this.lblFilterTag.Text = "FILTER BY CATEGORY";
            // 
            // lblSearchTag
            // 
            this.lblSearchTag.AutoSize = true;
            this.lblSearchTag.Location = new System.Drawing.Point(26, 155);
            this.lblSearchTag.Name = "lblSearchTag";
            this.lblSearchTag.Size = new System.Drawing.Size(153, 16);
            this.lblSearchTag.TabIndex = 79;
            this.lblSearchTag.Text = "SEARCH BY ID/ANIMAL";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(768, 348);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(156, 51);
            this.btnEdit.TabIndex = 78;
            this.btnEdit.Text = "✎ Edit Medicine";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(768, 268);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 48);
            this.btnAdd.TabIndex = 77;
            this.btnAdd.Text = "+ Add Medicine";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbFilterCategory
            // 
            this.cmbFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterCategory.FormattingEnabled = true;
            this.cmbFilterCategory.Location = new System.Drawing.Point(546, 132);
            this.cmbFilterCategory.Name = "cmbFilterCategory";
            this.cmbFilterCategory.Size = new System.Drawing.Size(231, 24);
            this.cmbFilterCategory.TabIndex = 76;
            this.cmbFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cmbFilterCategory_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(27, 174);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(328, 22);
            this.txtSearch.TabIndex = 75;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvKennels
            // 
            this.dgvKennels.AllowUserToAddRows = false;
            this.dgvKennels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKennels.EnableHeadersVisualStyles = false;
            this.dgvKennels.Location = new System.Drawing.Point(3, 268);
            this.dgvKennels.Name = "dgvKennels";
            this.dgvKennels.ReadOnly = true;
            this.dgvKennels.RowHeadersVisible = false;
            this.dgvKennels.RowHeadersWidth = 51;
            this.dgvKennels.RowTemplate.Height = 24;
            this.dgvKennels.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKennels.Size = new System.Drawing.Size(681, 323);
            this.dgvKennels.TabIndex = 74;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(553, 180);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(133, 16);
            this.lblDetails.TabIndex = 83;
            this.lblDetails.Text = "FILTER BY DETAILS";
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Location = new System.Drawing.Point(546, 199);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(231, 24);
            this.cmbFilterValue.TabIndex = 84;
            this.cmbFilterValue.SelectedIndexChanged += new System.EventHandler(this.cmbFilterValue_SelectedIndexChanged);
            // 
            // btnreassign
            // 
            this.btnreassign.BackColor = System.Drawing.Color.Yellow;
            this.btnreassign.FlatAppearance.BorderSize = 0;
            this.btnreassign.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnreassign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreassign.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreassign.ForeColor = System.Drawing.Color.Black;
            this.btnreassign.Location = new System.Drawing.Point(768, 437);
            this.btnreassign.Name = "btnreassign";
            this.btnreassign.Size = new System.Drawing.Size(156, 50);
            this.btnreassign.TabIndex = 82;
            this.btnreassign.Text = "Assign";
            this.btnreassign.UseVisualStyleBackColor = false;
            this.btnreassign.Click += new System.EventHandler(this.btnreassign_Click);
            // 
            // ManageKennelsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.cmbFilterValue);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnreassign);
            this.Controls.Add(this.btndlt);
            this.Controls.Add(this.lblFilterTag);
            this.Controls.Add(this.lblSearchTag);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbFilterCategory);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvKennels);
            this.Name = "ManageKennelsUC";
            this.Size = new System.Drawing.Size(932, 606);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKennels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btndlt;
        private System.Windows.Forms.Label lblFilterTag;
        private System.Windows.Forms.Label lblSearchTag;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbFilterCategory;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvKennels;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.ComboBox cmbFilterValue;
        private System.Windows.Forms.Button btnreassign;
    }
}
