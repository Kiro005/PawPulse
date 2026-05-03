namespace PawPulse
{
    partial class PrescriptionsUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent() {            this.topBar = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.addForm2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDuration2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRefills2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInstructions2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMedicine2 = new System.Windows.Forms.ComboBox();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbRecord2 = new System.Windows.Forms.ComboBox();
            this.lblAnimal = new System.Windows.Forms.Label();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.topBar.SuspendLayout();
            this.addForm2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
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
            this.topBar.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(648, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+ Add Prescription";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(154, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Prescriptions";
            // 
            // addForm2
            // 
            this.addForm2.BackColor = System.Drawing.Color.White;
            this.addForm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addForm2.Controls.Add(this.label4);
            this.addForm2.Controls.Add(this.txtDuration2);
            this.addForm2.Controls.Add(this.label3);
            this.addForm2.Controls.Add(this.txtRefills2);
            this.addForm2.Controls.Add(this.label2);
            this.addForm2.Controls.Add(this.txtInstructions2);
            this.addForm2.Controls.Add(this.label1);
            this.addForm2.Controls.Add(this.cmbMedicine2);
            this.addForm2.Controls.Add(this.btnCancelAdd);
            this.addForm2.Controls.Add(this.btnSave);
            this.addForm2.Controls.Add(this.cmbRecord2);
            this.addForm2.Controls.Add(this.lblAnimal);
            this.addForm2.Controls.Add(this.lblAddTitle);
            this.addForm2.Location = new System.Drawing.Point(231, 73);
            this.addForm2.Name = "addForm2";
            this.addForm2.Size = new System.Drawing.Size(420, 310);
            this.addForm2.TabIndex = 8;
            this.addForm2.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.label4.Location = new System.Drawing.Point(15, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Duration (days) :";
            // 
            // txtDuration2
            // 
            this.txtDuration2.Location = new System.Drawing.Point(165, 245);
            this.txtDuration2.Name = "txtDuration2";
            this.txtDuration2.Size = new System.Drawing.Size(240, 22);
            this.txtDuration2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.label3.Location = new System.Drawing.Point(15, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Refills Allowed :";
            // 
            // txtRefills2
            // 
            this.txtRefills2.Location = new System.Drawing.Point(165, 205);
            this.txtRefills2.Name = "txtRefills2";
            this.txtRefills2.Size = new System.Drawing.Size(240, 22);
            this.txtRefills2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(15, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Instructions :";
            // 
            // txtInstructions2
            // 
            this.txtInstructions2.Location = new System.Drawing.Point(165, 155);
            this.txtInstructions2.Name = "txtInstructions2";
            this.txtInstructions2.Size = new System.Drawing.Size(240, 22);
            this.txtInstructions2.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(15, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Medicine :";
            // 
            // cmbMedicine2
            // 
            this.cmbMedicine2.FormattingEnabled = true;
            this.cmbMedicine2.Location = new System.Drawing.Point(165, 105);
            this.cmbMedicine2.Name = "cmbMedicine2";
            this.cmbMedicine2.Size = new System.Drawing.Size(240, 24);
            this.cmbMedicine2.TabIndex = 9;
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancelAdd.ForeColor = System.Drawing.Color.White;
            this.btnCancelAdd.Location = new System.Drawing.Point(315, 270);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Size = new System.Drawing.Size(85, 30);
            this.btnCancelAdd.TabIndex = 8;
            this.btnCancelAdd.Text = "Cancel";
            this.btnCancelAdd.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(215, 270);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // cmbRecord2
            // 
            this.cmbRecord2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecord2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmbRecord2.FormattingEnabled = true;
            this.cmbRecord2.Location = new System.Drawing.Point(155, 55);
            this.cmbRecord2.Name = "cmbRecord2";
            this.cmbRecord2.Size = new System.Drawing.Size(245, 31);
            this.cmbRecord2.TabIndex = 2;
            // 
            // lblAnimal
            // 
            this.lblAnimal.AutoSize = true;
            this.lblAnimal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblAnimal.Location = new System.Drawing.Point(15, 58);
            this.lblAnimal.Name = "lblAnimal";
            this.lblAnimal.Size = new System.Drawing.Size(124, 20);
            this.lblAnimal.TabIndex = 1;
            this.lblAnimal.Text = "Medical Record :";
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.lblAddTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(170, 28);
            this.lblAddTitle.TabIndex = 0;
            this.lblAddTitle.Text = "Add Prescription";
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(20, 73);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersWidth = 51;
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(808, 520);
            this.dgv2.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Brown;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(438, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "- Delete";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(280, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // PrescriptionsUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.addForm2);
            this.Controls.Add(this.dgv2);
            this.Name = "PrescriptionsUC";
            this.Size = new System.Drawing.Size(848, 594);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.addForm2.ResumeLayout(false);
            this.addForm2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);

}

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel addForm2;
        private System.Windows.Forms.ComboBox cmbMedicine2;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbRecord2;
        private System.Windows.Forms.Label lblAnimal;
        private System.Windows.Forms.Label lblAddTitle;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRefills2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInstructions2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDuration2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
