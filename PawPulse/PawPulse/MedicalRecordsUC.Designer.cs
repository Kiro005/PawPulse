namespace PawPulse
{
    partial class MedicalRecordsUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent() {            this.addForm2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.cmbAppointment2 = new System.Windows.Forms.ComboBox();
            this.txtWeight2 = new System.Windows.Forms.TextBox();
            this.txtNotes2 = new System.Windows.Forms.TextBox();
            this.txtDiagnosis2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAnimal2 = new System.Windows.Forms.ComboBox();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.topBar = new System.Windows.Forms.Panel();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.addForm2.SuspendLayout();
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // addForm2
            // 
            this.addForm2.BackColor = System.Drawing.Color.White;
            this.addForm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addForm2.Controls.Add(this.btnSave);
            this.addForm2.Controls.Add(this.btnCancelAdd);
            this.addForm2.Controls.Add(this.cmbAppointment2);
            this.addForm2.Controls.Add(this.txtWeight2);
            this.addForm2.Controls.Add(this.txtNotes2);
            this.addForm2.Controls.Add(this.txtDiagnosis2);
            this.addForm2.Controls.Add(this.label5);
            this.addForm2.Controls.Add(this.label4);
            this.addForm2.Controls.Add(this.label3);
            this.addForm2.Controls.Add(this.label2);
            this.addForm2.Controls.Add(this.label1);
            this.addForm2.Controls.Add(this.cmbAnimal2);
            this.addForm2.Controls.Add(this.lblAddTitle);
            this.addForm2.Location = new System.Drawing.Point(231, 74);
            this.addForm2.Name = "addForm2";
            this.addForm2.Size = new System.Drawing.Size(400, 370);
            this.addForm2.TabIndex = 11;
            this.addForm2.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(200, 328);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancelAdd.ForeColor = System.Drawing.Color.White;
            this.btnCancelAdd.Location = new System.Drawing.Point(300, 328);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(90, 32);
            this.btnCancelAdd.TabIndex = 11;
            this.btnCancelAdd.Text = "Cancel";
            this.btnCancelAdd.UseVisualStyleBackColor = false;
            // 
            // cmbAppointment2
            // 
            this.cmbAppointment2.FormattingEnabled = true;
            this.cmbAppointment2.Location = new System.Drawing.Point(185, 292);
            this.cmbAppointment2.Name = "cmbAppointment2";
            this.cmbAppointment2.Size = new System.Drawing.Size(195, 24);
            this.cmbAppointment2.TabIndex = 10;
            // 
            // txtWeight2
            // 
            this.txtWeight2.Location = new System.Drawing.Point(150, 250);
            this.txtWeight2.Name = "txtWeight2";
            this.txtWeight2.Size = new System.Drawing.Size(230, 22);
            this.txtWeight2.TabIndex = 9;
            // 
            // txtNotes2
            // 
            this.txtNotes2.Location = new System.Drawing.Point(150, 165);
            this.txtNotes2.Multiline = true;
            this.txtNotes2.Name = "txtNotes2";
            this.txtNotes2.Size = new System.Drawing.Size(230, 55);
            this.txtNotes2.TabIndex = 8;
            // 
            // txtDiagnosis2
            // 
            this.txtDiagnosis2.Location = new System.Drawing.Point(150, 110);
            this.txtDiagnosis2.Name = "txtDiagnosis2";
            this.txtDiagnosis2.Size = new System.Drawing.Size(230, 22);
            this.txtDiagnosis2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 253);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Weight (kg) :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Appointment (optional) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Notes :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Diagnosis :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Animal :";
            // 
            // cmbAnimal2
            // 
            this.cmbAnimal2.FormattingEnabled = true;
            this.cmbAnimal2.Location = new System.Drawing.Point(150, 55);
            this.cmbAnimal2.Name = "cmbAnimal2";
            this.cmbAnimal2.Size = new System.Drawing.Size(230, 24);
            this.cmbAnimal2.TabIndex = 1;
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.lblAddTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(203, 28);
            this.lblAddTitle.TabIndex = 0;
            this.lblAddTitle.Text = "Add Medical Record";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(680, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+ Add Record";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Medical Records";
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.topBar.Controls.Add(this.button2);
            this.topBar.Controls.Add(this.button1);
            this.topBar.Controls.Add(this.btnAdd);
            this.topBar.Controls.Add(this.lblTitle);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(848, 60);
            this.topBar.TabIndex = 9;
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(20, 74);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersWidth = 51;
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(808, 520);
            this.dgv2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(359, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(517, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 34);
            this.button2.TabIndex = 3;
            this.button2.Text = "- Delete";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // MedicalRecordsUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.addForm2);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.dgv2);
            this.Name = "MedicalRecordsUC";
            this.Size = new System.Drawing.Size(848, 594);
            this.addForm2.ResumeLayout(false);
            this.addForm2.PerformLayout();
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);

}

        private System.Windows.Forms.Panel addForm2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAnimal2;
        private System.Windows.Forms.Label lblAddTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.TextBox txtNotes2;
        private System.Windows.Forms.TextBox txtDiagnosis2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAppointment2;
        private System.Windows.Forms.TextBox txtWeight2;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
