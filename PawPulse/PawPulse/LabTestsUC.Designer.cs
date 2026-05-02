namespace PawPulse
{
    partial class LabTestsUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent() {            this.topBar = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.addForm2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCost2 = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResults2 = new System.Windows.Forms.TextBox();
            this.lblTestType = new System.Windows.Forms.Label();
            this.txtTestType2 = new System.Windows.Forms.TextBox();
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
            this.topBar.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(660, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+ Add Lab Test";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(110, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lab Tests";
            // 
            // addForm2
            // 
            this.addForm2.BackColor = System.Drawing.Color.White;
            this.addForm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addForm2.Controls.Add(this.label1);
            this.addForm2.Controls.Add(this.txtCost2);
            this.addForm2.Controls.Add(this.lblResult);
            this.addForm2.Controls.Add(this.txtResults2);
            this.addForm2.Controls.Add(this.lblTestType);
            this.addForm2.Controls.Add(this.txtTestType2);
            this.addForm2.Controls.Add(this.btnCancelAdd);
            this.addForm2.Controls.Add(this.btnSave);
            this.addForm2.Controls.Add(this.cmbRecord2);
            this.addForm2.Controls.Add(this.lblAnimal);
            this.addForm2.Controls.Add(this.lblAddTitle);
            this.addForm2.Location = new System.Drawing.Point(231, 72);
            this.addForm2.Name = "addForm2";
            this.addForm2.Size = new System.Drawing.Size(400, 265);
            this.addForm2.TabIndex = 5;
            this.addForm2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(15, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cost (EGP) :";
            // 
            // txtCost2
            // 
            this.txtCost2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtCost2.Location = new System.Drawing.Point(155, 195);
            this.txtCost2.Name = "txtCost2";
            this.txtCost2.Size = new System.Drawing.Size(230, 30);
            this.txtCost2.TabIndex = 13;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblResult.Location = new System.Drawing.Point(15, 153);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(61, 20);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "Result :";
            // 
            // txtResults2
            // 
            this.txtResults2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtResults2.Location = new System.Drawing.Point(155, 150);
            this.txtResults2.Name = "txtResults2";
            this.txtResults2.Size = new System.Drawing.Size(230, 30);
            this.txtResults2.TabIndex = 11;
            // 
            // lblTestType
            // 
            this.lblTestType.AutoSize = true;
            this.lblTestType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblTestType.Location = new System.Drawing.Point(15, 108);
            this.lblTestType.Name = "lblTestType";
            this.lblTestType.Size = new System.Drawing.Size(83, 20);
            this.lblTestType.TabIndex = 10;
            this.lblTestType.Text = "Test Type :";
            // 
            // txtTestType2
            // 
            this.txtTestType2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.txtTestType2.Location = new System.Drawing.Point(155, 105);
            this.txtTestType2.Name = "txtTestType2";
            this.txtTestType2.Size = new System.Drawing.Size(230, 30);
            this.txtTestType2.TabIndex = 9;
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancelAdd.ForeColor = System.Drawing.Color.White;
            this.btnCancelAdd.Location = new System.Drawing.Point(300, 228);
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
            this.btnSave.Location = new System.Drawing.Point(205, 228);
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
            this.lblAddTitle.Size = new System.Drawing.Size(133, 28);
            this.lblAddTitle.TabIndex = 0;
            this.lblAddTitle.Text = "Add Lab Test";
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(20, 72);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersWidth = 51;
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(808, 520);
            this.dgv2.TabIndex = 4;
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
            // LabTestsUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.addForm2);
            this.Controls.Add(this.dgv2);
            this.Name = "LabTestsUC";
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
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbRecord2;
        private System.Windows.Forms.Label lblAnimal;
        private System.Windows.Forms.Label lblAddTitle;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Label lblTestType;
        private System.Windows.Forms.TextBox txtTestType2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResults2;
        private System.Windows.Forms.TextBox txtCost2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
