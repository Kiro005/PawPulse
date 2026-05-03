namespace PawPulse
{
    partial class VaccinationsUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent() {            this.topBar = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.addForm2 = new System.Windows.Forms.Panel();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.lblData = new System.Windows.Forms.Label();
            this.cmbVaccine2 = new System.Windows.Forms.ComboBox();
            this.lblVaccine = new System.Windows.Forms.Label();
            this.cmbAnimal2 = new System.Windows.Forms.ComboBox();
            this.lblAnimal = new System.Windows.Forms.Label();
            this.lblAddTitle = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.topBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.addForm2.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.topBar.Controls.Add(this.button2);
            this.topBar.Controls.Add(this.btnAdd);
            this.topBar.Controls.Add(this.lblTitle);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(848, 60);
            this.topBar.TabIndex = 0;
            this.topBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(645, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(155, 34);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+ Add Vaccination";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Vaccinations";
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(20, 70);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowHeadersWidth = 51;
            this.dgv2.RowTemplate.Height = 24;
            this.dgv2.Size = new System.Drawing.Size(808, 520);
            this.dgv2.TabIndex = 1;
            // 
            // addForm2
            // 
            this.addForm2.BackColor = System.Drawing.Color.White;
            this.addForm2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addForm2.Controls.Add(this.btnCancelAdd);
            this.addForm2.Controls.Add(this.btnSave);
            this.addForm2.Controls.Add(this.dtpDate2);
            this.addForm2.Controls.Add(this.lblData);
            this.addForm2.Controls.Add(this.cmbVaccine2);
            this.addForm2.Controls.Add(this.lblVaccine);
            this.addForm2.Controls.Add(this.cmbAnimal2);
            this.addForm2.Controls.Add(this.lblAnimal);
            this.addForm2.Controls.Add(this.lblAddTitle);
            this.addForm2.Location = new System.Drawing.Point(230, 70);
            this.addForm2.Name = "addForm2";
            this.addForm2.Size = new System.Drawing.Size(380, 230);
            this.addForm2.TabIndex = 2;
            this.addForm2.Visible = false;
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnCancelAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelAdd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancelAdd.ForeColor = System.Drawing.Color.White;
            this.btnCancelAdd.Location = new System.Drawing.Point(280, 190);
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
            this.btnSave.Location = new System.Drawing.Point(185, 190);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // dtpDate2
            // 
            this.dtpDate2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate2.Location = new System.Drawing.Point(120, 145);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.Size = new System.Drawing.Size(240, 30);
            this.dtpDate2.TabIndex = 6;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblData.Location = new System.Drawing.Point(15, 148);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(46, 20);
            this.lblData.TabIndex = 5;
            this.lblData.Text = "Date:";
            // 
            // cmbVaccine2
            // 
            this.cmbVaccine2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVaccine2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmbVaccine2.FormattingEnabled = true;
            this.cmbVaccine2.Location = new System.Drawing.Point(120, 100);
            this.cmbVaccine2.Name = "cmbVaccine2";
            this.cmbVaccine2.Size = new System.Drawing.Size(245, 31);
            this.cmbVaccine2.TabIndex = 4;
            // 
            // lblVaccine
            // 
            this.lblVaccine.AutoSize = true;
            this.lblVaccine.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVaccine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblVaccine.Location = new System.Drawing.Point(15, 103);
            this.lblVaccine.Name = "lblVaccine";
            this.lblVaccine.Size = new System.Drawing.Size(69, 20);
            this.lblVaccine.TabIndex = 3;
            this.lblVaccine.Text = "Vaccine :";
            // 
            // cmbAnimal2
            // 
            this.cmbAnimal2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnimal2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.cmbAnimal2.FormattingEnabled = true;
            this.cmbAnimal2.Location = new System.Drawing.Point(120, 55);
            this.cmbAnimal2.Name = "cmbAnimal2";
            this.cmbAnimal2.Size = new System.Drawing.Size(245, 31);
            this.cmbAnimal2.TabIndex = 2;
            // 
            // lblAnimal
            // 
            this.lblAnimal.AutoSize = true;
            this.lblAnimal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnimal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblAnimal.Location = new System.Drawing.Point(15, 58);
            this.lblAnimal.Name = "lblAnimal";
            this.lblAnimal.Size = new System.Drawing.Size(67, 20);
            this.lblAnimal.TabIndex = 1;
            this.lblAnimal.Text = "Animal :";
            // 
            // lblAddTitle
            // 
            this.lblAddTitle.AutoSize = true;
            this.lblAddTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.lblAddTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAddTitle.Name = "lblAddTitle";
            this.lblAddTitle.Size = new System.Drawing.Size(165, 28);
            this.lblAddTitle.TabIndex = 0;
            this.lblAddTitle.Text = "Add Vaccination";
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
            // VaccinationsUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.addForm2);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.topBar);
            this.Name = "VaccinationsUC";
            this.Size = new System.Drawing.Size(848, 594);
            this.Load += new System.EventHandler(this.VaccinationsUC_Load);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.addForm2.ResumeLayout(false);
            this.addForm2.PerformLayout();
            this.ResumeLayout(false);

}

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Panel addForm2;
        private System.Windows.Forms.Label lblAddTitle;
        private System.Windows.Forms.ComboBox cmbVaccine2;
        private System.Windows.Forms.Label lblVaccine;
        private System.Windows.Forms.ComboBox cmbAnimal2;
        private System.Windows.Forms.Label lblAnimal;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpDate2;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Button button2;
    }
}
