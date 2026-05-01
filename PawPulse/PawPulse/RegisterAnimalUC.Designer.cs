namespace PawPulse
{
    partial class RegisterAnimalUC
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent() {            this.TopBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.formCard = new System.Windows.Forms.Panel();
            this.txtWeight2 = new System.Windows.Forms.TextBox();
            this.btnClear2 = new System.Windows.Forms.Button();
            this.btnRegister2 = new System.Windows.Forms.Button();
            this.cmbKennel2 = new System.Windows.Forms.ComboBox();
            this.lblKeneel = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.dtpDOB2 = new System.Windows.Forms.DateTimePicker();
            this.textBreed2 = new System.Windows.Forms.TextBox();
            this.txtSpecies2 = new System.Windows.Forms.TextBox();
            this.lblDOB = new System.Windows.Forms.Label();
            this.cmbGender2 = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblBreed = new System.Windows.Forms.Label();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.txtAnimalName = new System.Windows.Forms.TextBox();
            this.lblAnimalName = new System.Windows.Forms.Label();
            this.lblForm = new System.Windows.Forms.Label();
            this.accentBar = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TopBar.SuspendLayout();
            this.formCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.TopBar.Controls.Add(this.button2);
            this.TopBar.Controls.Add(this.button1);
            this.TopBar.Controls.Add(this.lblTitle);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(848, 60);
            this.TopBar.TabIndex = 0;
            this.TopBar.Paint += new System.Windows.Forms.PaintEventHandler(this.TopBar_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(292, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Register Incoming Animal";
            // 
            // formCard
            // 
            this.formCard.BackColor = System.Drawing.Color.White;
            this.formCard.Controls.Add(this.txtWeight2);
            this.formCard.Controls.Add(this.btnClear2);
            this.formCard.Controls.Add(this.btnRegister2);
            this.formCard.Controls.Add(this.cmbKennel2);
            this.formCard.Controls.Add(this.lblKeneel);
            this.formCard.Controls.Add(this.lblWeight);
            this.formCard.Controls.Add(this.dtpDOB2);
            this.formCard.Controls.Add(this.textBreed2);
            this.formCard.Controls.Add(this.txtSpecies2);
            this.formCard.Controls.Add(this.lblDOB);
            this.formCard.Controls.Add(this.cmbGender2);
            this.formCard.Controls.Add(this.lblGender);
            this.formCard.Controls.Add(this.lblBreed);
            this.formCard.Controls.Add(this.lblSpecies);
            this.formCard.Controls.Add(this.txtAnimalName);
            this.formCard.Controls.Add(this.lblAnimalName);
            this.formCard.Controls.Add(this.lblForm);
            this.formCard.Controls.Add(this.accentBar);
            this.formCard.Location = new System.Drawing.Point(165, 80);
            this.formCard.Name = "formCard";
            this.formCard.Size = new System.Drawing.Size(520, 420);
            this.formCard.TabIndex = 1;
            this.formCard.Paint += new System.Windows.Forms.PaintEventHandler(this.formCard_Paint);
            // 
            // txtWeight2
            // 
            this.txtWeight2.Location = new System.Drawing.Point(200, 288);
            this.txtWeight2.Name = "txtWeight2";
            this.txtWeight2.Size = new System.Drawing.Size(280, 22);
            this.txtWeight2.TabIndex = 19;
            // 
            // btnClear2
            // 
            this.btnClear2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.btnClear2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear2.ForeColor = System.Drawing.Color.Black;
            this.btnClear2.Location = new System.Drawing.Point(365, 375);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(90, 38);
            this.btnClear2.TabIndex = 18;
            this.btnClear2.Text = "Clear";
            this.btnClear2.UseVisualStyleBackColor = false;
            // 
            // btnRegister2
            // 
            this.btnRegister2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.btnRegister2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister2.ForeColor = System.Drawing.Color.Black;
            this.btnRegister2.Location = new System.Drawing.Point(200, 375);
            this.btnRegister2.Name = "btnRegister2";
            this.btnRegister2.Size = new System.Drawing.Size(155, 38);
            this.btnRegister2.TabIndex = 17;
            this.btnRegister2.Text = "Register Animal";
            this.btnRegister2.UseVisualStyleBackColor = false;
            // 
            // cmbKennel2
            // 
            this.cmbKennel2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKennel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKennel2.FormattingEnabled = true;
            this.cmbKennel2.Location = new System.Drawing.Point(200, 333);
            this.cmbKennel2.Name = "cmbKennel2";
            this.cmbKennel2.Size = new System.Drawing.Size(280, 31);
            this.cmbKennel2.TabIndex = 16;
            // 
            // lblKeneel
            // 
            this.lblKeneel.AutoSize = true;
            this.lblKeneel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeneel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblKeneel.Location = new System.Drawing.Point(20, 337);
            this.lblKeneel.Name = "lblKeneel";
            this.lblKeneel.Size = new System.Drawing.Size(92, 23);
            this.lblKeneel.TabIndex = 15;
            this.lblKeneel.Text = "Kennel :  *";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblWeight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblWeight.Location = new System.Drawing.Point(20, 292);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(112, 23);
            this.lblWeight.TabIndex = 13;
            this.lblWeight.Text = "Weight (kg):";
            // 
            // dtpDOB2
            // 
            this.dtpDOB2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.dtpDOB2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB2.Location = new System.Drawing.Point(200, 245);
            this.dtpDOB2.Name = "dtpDOB2";
            this.dtpDOB2.Size = new System.Drawing.Size(280, 30);
            this.dtpDOB2.TabIndex = 12;
            // 
            // textBreed2
            // 
            this.textBreed2.Location = new System.Drawing.Point(200, 155);
            this.textBreed2.Name = "textBreed2";
            this.textBreed2.Size = new System.Drawing.Size(280, 22);
            this.textBreed2.TabIndex = 11;
            // 
            // txtSpecies2
            // 
            this.txtSpecies2.Location = new System.Drawing.Point(200, 110);
            this.txtSpecies2.Name = "txtSpecies2";
            this.txtSpecies2.Size = new System.Drawing.Size(280, 22);
            this.txtSpecies2.TabIndex = 10;
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblDOB.Location = new System.Drawing.Point(20, 249);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(82, 16);
            this.lblDOB.TabIndex = 9;
            this.lblDOB.Text = "Date of Birth:";
            // 
            // cmbGender2
            // 
            this.cmbGender2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGender2.FormattingEnabled = true;
            this.cmbGender2.Location = new System.Drawing.Point(200, 200);
            this.cmbGender2.Name = "cmbGender2";
            this.cmbGender2.Size = new System.Drawing.Size(280, 31);
            this.cmbGender2.TabIndex = 8;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblGender.Location = new System.Drawing.Point(20, 203);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(96, 23);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Gender :  *";
            // 
            // lblBreed
            // 
            this.lblBreed.AutoSize = true;
            this.lblBreed.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblBreed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblBreed.Location = new System.Drawing.Point(20, 159);
            this.lblBreed.Name = "lblBreed";
            this.lblBreed.Size = new System.Drawing.Size(80, 23);
            this.lblBreed.TabIndex = 6;
            this.lblBreed.Text = "Breed : *";
            // 
            // lblSpecies
            // 
            this.lblSpecies.AutoSize = true;
            this.lblSpecies.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblSpecies.Location = new System.Drawing.Point(20, 114);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.Size = new System.Drawing.Size(97, 23);
            this.lblSpecies.TabIndex = 4;
            this.lblSpecies.Text = "Species :  *";
            // 
            // txtAnimalName
            // 
            this.txtAnimalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnimalName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnimalName.Location = new System.Drawing.Point(200, 65);
            this.txtAnimalName.Name = "txtAnimalName";
            this.txtAnimalName.Size = new System.Drawing.Size(280, 30);
            this.txtAnimalName.TabIndex = 3;
            // 
            // lblAnimalName
            // 
            this.lblAnimalName.AutoSize = true;
            this.lblAnimalName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblAnimalName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(80)))));
            this.lblAnimalName.Location = new System.Drawing.Point(20, 69);
            this.lblAnimalName.Name = "lblAnimalName";
            this.lblAnimalName.Size = new System.Drawing.Size(142, 23);
            this.lblAnimalName.TabIndex = 2;
            this.lblAnimalName.Text = "Animal Name : *";
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.lblForm.Location = new System.Drawing.Point(25, 20);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(214, 30);
            this.lblForm.TabIndex = 1;
            this.lblForm.Text = "Animal Information";
            // 
            // accentBar
            // 
            this.accentBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(196)))), ((int)(((byte)(175)))));
            this.accentBar.Location = new System.Drawing.Point(0, 0);
            this.accentBar.Name = "accentBar";
            this.accentBar.Size = new System.Drawing.Size(6, 420);
            this.accentBar.TabIndex = 0;
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
            // RegisterAnimalUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.formCard);
            this.Controls.Add(this.TopBar);
            this.Name = "RegisterAnimalUC";
            this.Size = new System.Drawing.Size(848, 594);
            this.Load += new System.EventHandler(this.RegisterAnimalUC_Load);
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            this.formCard.ResumeLayout(false);
            this.formCard.PerformLayout();
            this.ResumeLayout(false);

}

        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel formCard;
        private System.Windows.Forms.Panel accentBar;
        private System.Windows.Forms.TextBox txtAnimalName;
        private System.Windows.Forms.Label lblAnimalName;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.Label lblBreed;
        private System.Windows.Forms.ComboBox cmbGender2;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox textBreed2;
        private System.Windows.Forms.TextBox txtSpecies2;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.ComboBox cmbKennel2;
        private System.Windows.Forms.Label lblKeneel;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.DateTimePicker dtpDOB2;
        private System.Windows.Forms.Button btnClear2;
        private System.Windows.Forms.Button btnRegister2;
        private System.Windows.Forms.TextBox txtWeight2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
