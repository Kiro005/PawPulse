namespace PawPulse
{
    partial class ManageUsersUC
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
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.cmbRoleFilter = new System.Windows.Forms.ComboBox();
            this.btnِAddUser = new System.Windows.Forms.Button();
            this.btnEditusr = new System.Windows.Forms.Button();
            this.lblFilterTag = new System.Windows.Forms.Label();
            this.lblSearchTag = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblSubTitle);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblWelcome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 75);
            this.panel1.TabIndex = 21;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSubTitle.Location = new System.Drawing.Point(118, 45);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(126, 16);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Employee Directory";
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
            this.lblWelcome.Size = new System.Drawing.Size(87, 38);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Users";
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.EnableHeadersVisualStyles = false;
            this.dgvEmployees.Location = new System.Drawing.Point(21, 240);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowHeadersVisible = false;
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.RowTemplate.Height = 24;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(662, 327);
            this.dgvEmployees.TabIndex = 22;
            this.dgvEmployees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellContentClick);
            this.dgvEmployees.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployees_CellDoubleClick);
            this.dgvEmployees.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEmployees_DataBindingComplete);
            // 
            // txtSearchUser
            // 
            this.txtSearchUser.Location = new System.Drawing.Point(21, 150);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.Size = new System.Drawing.Size(328, 22);
            this.txtSearchUser.TabIndex = 23;
            this.txtSearchUser.TextChanged += new System.EventHandler(this.txtSearchUser_TextChanged);
            // 
            // cmbRoleFilter
            // 
            this.cmbRoleFilter.FormattingEnabled = true;
            this.cmbRoleFilter.Location = new System.Drawing.Point(478, 150);
            this.cmbRoleFilter.Name = "cmbRoleFilter";
            this.cmbRoleFilter.Size = new System.Drawing.Size(205, 24);
            this.cmbRoleFilter.TabIndex = 24;
            this.cmbRoleFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRoleFilter_SelectedIndexChanged);
            // 
            // btnِAddUser
            // 
            this.btnِAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.btnِAddUser.FlatAppearance.BorderSize = 0;
            this.btnِAddUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnِAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnِAddUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnِAddUser.ForeColor = System.Drawing.Color.White;
            this.btnِAddUser.Location = new System.Drawing.Point(689, 273);
            this.btnِAddUser.Name = "btnِAddUser";
            this.btnِAddUser.Size = new System.Drawing.Size(156, 48);
            this.btnِAddUser.TabIndex = 25;
            this.btnِAddUser.Text = "+ Add User";
            this.btnِAddUser.UseVisualStyleBackColor = false;
            this.btnِAddUser.Click += new System.EventHandler(this.btnِAddUser_Click);
            // 
            // btnEditusr
            // 
            this.btnEditusr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnEditusr.FlatAppearance.BorderSize = 0;
            this.btnEditusr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEditusr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditusr.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditusr.ForeColor = System.Drawing.Color.White;
            this.btnEditusr.Location = new System.Drawing.Point(689, 381);
            this.btnEditusr.Name = "btnEditusr";
            this.btnEditusr.Size = new System.Drawing.Size(156, 51);
            this.btnEditusr.TabIndex = 26;
            this.btnEditusr.Text = "✎ Edit User";
            this.btnEditusr.UseVisualStyleBackColor = false;
            this.btnEditusr.Click += new System.EventHandler(this.btnEditusr_Click);
            // 
            // lblFilterTag
            // 
            this.lblFilterTag.AutoSize = true;
            this.lblFilterTag.Location = new System.Drawing.Point(485, 131);
            this.lblFilterTag.Name = "lblFilterTag";
            this.lblFilterTag.Size = new System.Drawing.Size(113, 16);
            this.lblFilterTag.TabIndex = 3;
            this.lblFilterTag.Text = "FILTER BY ROLE";
            // 
            // lblSearchTag
            // 
            this.lblSearchTag.AutoSize = true;
            this.lblSearchTag.Location = new System.Drawing.Point(20, 131);
            this.lblSearchTag.Name = "lblSearchTag";
            this.lblSearchTag.Size = new System.Drawing.Size(191, 16);
            this.lblSearchTag.TabIndex = 27;
            this.lblSearchTag.Text = "SEARCH BY NAME OR EMAIL";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(688, 476);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 51);
            this.button1.TabIndex = 60;
            this.button1.Text = "× FIRE USER";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblFilterTag);
            this.Controls.Add(this.lblSearchTag);
            this.Controls.Add(this.btnEditusr);
            this.Controls.Add(this.btnِAddUser);
            this.Controls.Add(this.cmbRoleFilter);
            this.Controls.Add(this.txtSearchUser);
            this.Controls.Add(this.dgvEmployees);
            this.Controls.Add(this.panel1);
            this.Name = "ManageUsers";
            this.Size = new System.Drawing.Size(848, 594);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.ComboBox cmbRoleFilter;
        private System.Windows.Forms.Button btnِAddUser;
        private System.Windows.Forms.Button btnEditusr;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Label lblFilterTag;
        private System.Windows.Forms.Label lblSearchTag;
        private System.Windows.Forms.Button button1;
    }
}
