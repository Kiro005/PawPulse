namespace PawPulse
{
    partial class MedicalHistoryClientForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.medicalReport = new System.Windows.Forms.TabPage();
            this.dgvVisits = new System.Windows.Forms.DataGridView();
            this.Prescriptions = new System.Windows.Forms.TabPage();
            this.dgvPrescriptions = new System.Windows.Forms.DataGridView();
            this.Vaccines = new System.Windows.Forms.TabPage();
            this.dgvVaccines = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvLabTests = new System.Windows.Forms.DataGridView();
            this.lblPetName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.medicalReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisits)).BeginInit();
            this.Prescriptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).BeginInit();
            this.Vaccines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccines)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabTests)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.medicalReport);
            this.tabControl1.Controls.Add(this.Prescriptions);
            this.tabControl1.Controls.Add(this.Vaccines);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 378);
            this.tabControl1.TabIndex = 0;
            // 
            // medicalReport
            // 
            this.medicalReport.Controls.Add(this.dgvVisits);
            this.medicalReport.Location = new System.Drawing.Point(4, 32);
            this.medicalReport.Name = "medicalReport";
            this.medicalReport.Padding = new System.Windows.Forms.Padding(3);
            this.medicalReport.Size = new System.Drawing.Size(788, 342);
            this.medicalReport.TabIndex = 0;
            this.medicalReport.Text = "Visit History";
            this.medicalReport.UseVisualStyleBackColor = true;
            // 
            // dgvVisits
            // 
            this.dgvVisits.AllowUserToAddRows = false;
            this.dgvVisits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisits.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVisits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVisits.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVisits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVisits.Location = new System.Drawing.Point(3, 3);
            this.dgvVisits.Name = "dgvVisits";
            this.dgvVisits.ReadOnly = true;
            this.dgvVisits.RowHeadersVisible = false;
            this.dgvVisits.RowHeadersWidth = 51;
            this.dgvVisits.RowTemplate.Height = 24;
            this.dgvVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisits.Size = new System.Drawing.Size(782, 336);
            this.dgvVisits.TabIndex = 2;
            this.dgvVisits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVisits_CellContentClick);
            // 
            // Prescriptions
            // 
            this.Prescriptions.Controls.Add(this.dgvPrescriptions);
            this.Prescriptions.Location = new System.Drawing.Point(4, 32);
            this.Prescriptions.Name = "Prescriptions";
            this.Prescriptions.Padding = new System.Windows.Forms.Padding(3);
            this.Prescriptions.Size = new System.Drawing.Size(788, 342);
            this.Prescriptions.TabIndex = 1;
            this.Prescriptions.Text = "Prescriptions";
            this.Prescriptions.UseVisualStyleBackColor = true;
            // 
            // dgvPrescriptions
            // 
            this.dgvPrescriptions.AllowUserToAddRows = false;
            this.dgvPrescriptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrescriptions.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPrescriptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPrescriptions.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPrescriptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrescriptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrescriptions.Location = new System.Drawing.Point(3, 3);
            this.dgvPrescriptions.Name = "dgvPrescriptions";
            this.dgvPrescriptions.ReadOnly = true;
            this.dgvPrescriptions.RowHeadersVisible = false;
            this.dgvPrescriptions.RowHeadersWidth = 51;
            this.dgvPrescriptions.RowTemplate.Height = 24;
            this.dgvPrescriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrescriptions.Size = new System.Drawing.Size(782, 336);
            this.dgvPrescriptions.TabIndex = 2;
            // 
            // Vaccines
            // 
            this.Vaccines.Controls.Add(this.dgvVaccines);
            this.Vaccines.Location = new System.Drawing.Point(4, 32);
            this.Vaccines.Name = "Vaccines";
            this.Vaccines.Padding = new System.Windows.Forms.Padding(3);
            this.Vaccines.Size = new System.Drawing.Size(788, 342);
            this.Vaccines.TabIndex = 2;
            this.Vaccines.Text = "Vaccines";
            this.Vaccines.UseVisualStyleBackColor = true;
            // 
            // dgvVaccines
            // 
            this.dgvVaccines.AllowUserToAddRows = false;
            this.dgvVaccines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVaccines.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvVaccines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVaccines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvVaccines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaccines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVaccines.Location = new System.Drawing.Point(3, 3);
            this.dgvVaccines.Name = "dgvVaccines";
            this.dgvVaccines.ReadOnly = true;
            this.dgvVaccines.RowHeadersVisible = false;
            this.dgvVaccines.RowHeadersWidth = 51;
            this.dgvVaccines.RowTemplate.Height = 24;
            this.dgvVaccines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVaccines.Size = new System.Drawing.Size(782, 336);
            this.dgvVaccines.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvLabTests);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(788, 342);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Lab Tests";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLabTests
            // 
            this.dgvLabTests.AllowUserToAddRows = false;
            this.dgvLabTests.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLabTests.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvLabTests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLabTests.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLabTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabTests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLabTests.Location = new System.Drawing.Point(3, 3);
            this.dgvLabTests.Name = "dgvLabTests";
            this.dgvLabTests.ReadOnly = true;
            this.dgvLabTests.RowHeadersVisible = false;
            this.dgvLabTests.RowHeadersWidth = 51;
            this.dgvLabTests.RowTemplate.Height = 24;
            this.dgvLabTests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLabTests.Size = new System.Drawing.Size(782, 336);
            this.dgvLabTests.TabIndex = 1;
            // 
            // lblPetName
            // 
            this.lblPetName.AutoSize = true;
            this.lblPetName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPetName.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblPetName.Location = new System.Drawing.Point(218, 18);
            this.lblPetName.Name = "lblPetName";
            this.lblPetName.Size = new System.Drawing.Size(372, 41);
            this.lblPetName.TabIndex = 0;
            this.lblPetName.Text = "Medical Profile: petname";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblPetName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 75);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(3, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(796, 378);
            this.panel2.TabIndex = 17;
            // 
            // MedicalHistoryClientForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MedicalHistoryClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MedicalHistoryClientForm";
            this.tabControl1.ResumeLayout(false);
            this.medicalReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisits)).EndInit();
            this.Prescriptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrescriptions)).EndInit();
            this.Vaccines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaccines)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabTests)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Prescriptions;
        private System.Windows.Forms.TabPage Vaccines;
        private System.Windows.Forms.Label lblPetName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage medicalReport;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvLabTests;
        private System.Windows.Forms.DataGridView dgvVisits;
        private System.Windows.Forms.DataGridView dgvPrescriptions;
        private System.Windows.Forms.DataGridView dgvVaccines;
    }
}