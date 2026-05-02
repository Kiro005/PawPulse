namespace PawPulse
{
    partial class EditClientForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Address = new System.Windows.Forms.GroupBox();
            this.cmbCity = new System.Windows.Forms.ComboBox();
            this.txtBuilding = new System.Windows.Forms.TextBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnٍِِSave = new System.Windows.Forms.Button();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblLastname = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.lblFirstname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.Address.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(55)))));
            this.panel2.Controls.Add(this.Address);
            this.panel2.Controls.Add(this.lblError);
            this.panel2.Controls.Add(this.btnٍِِSave);
            this.panel2.Controls.Add(this.txtphone);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.txtLName);
            this.panel2.Controls.Add(this.txtFName);
            this.panel2.Controls.Add(this.lblemail);
            this.panel2.Controls.Add(this.lblLastname);
            this.panel2.Controls.Add(this.lblphone);
            this.panel2.Controls.Add(this.lblFirstname);
            this.panel2.Location = new System.Drawing.Point(226, -26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 457);
            this.panel2.TabIndex = 48;
            // 
            // Address
            // 
            this.Address.Controls.Add(this.cmbCity);
            this.Address.Controls.Add(this.txtBuilding);
            this.Address.Controls.Add(this.txtStreet);
            this.Address.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Address.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Address.Location = new System.Drawing.Point(15, 240);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(559, 66);
            this.Address.TabIndex = 59;
            this.Address.TabStop = false;
            this.Address.Text = "Address";
            // 
            // cmbCity
            // 
            this.cmbCity.FormattingEnabled = true;
            this.cmbCity.Location = new System.Drawing.Point(26, 29);
            this.cmbCity.Name = "cmbCity";
            this.cmbCity.Size = new System.Drawing.Size(138, 31);
            this.cmbCity.TabIndex = 61;
            this.cmbCity.Text = "City";
            // 
            // txtBuilding
            // 
            this.txtBuilding.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuilding.Location = new System.Drawing.Point(370, 29);
            this.txtBuilding.Name = "txtBuilding";
            this.txtBuilding.Size = new System.Drawing.Size(142, 30);
            this.txtBuilding.TabIndex = 60;
            // 
            // txtStreet
            // 
            this.txtStreet.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txtStreet.Location = new System.Drawing.Point(185, 29);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(155, 30);
            this.txtStreet.TabIndex = 57;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(37, 332);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(188, 23);
            this.lblError.TabIndex = 58;
            this.lblError.Text = "Please, Fill all the Fields";
            this.lblError.Visible = false;
            // 
            // btnٍِِSave
            // 
            this.btnٍِِSave.BackColor = System.Drawing.Color.LimeGreen;
            this.btnٍِِSave.FlatAppearance.BorderSize = 0;
            this.btnٍِِSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnٍِِSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnٍِِSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnٍِِSave.ForeColor = System.Drawing.Color.White;
            this.btnٍِِSave.Location = new System.Drawing.Point(385, 317);
            this.btnٍِِSave.Name = "btnٍِِSave";
            this.btnٍِِSave.Size = new System.Drawing.Size(169, 48);
            this.btnٍِِSave.TabIndex = 45;
            this.btnٍِِSave.Text = "✎ Save Edit";
            this.btnٍِِSave.UseVisualStyleBackColor = false;
            this.btnٍِِSave.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // txtphone
            // 
            this.txtphone.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.Location = new System.Drawing.Point(132, 135);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(130, 30);
            this.txtphone.TabIndex = 56;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(85, 204);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(249, 30);
            this.txtEmail.TabIndex = 54;
            // 
            // txtLName
            // 
            this.txtLName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLName.Location = new System.Drawing.Point(405, 66);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(122, 30);
            this.txtLName.TabIndex = 53;
            // 
            // txtFName
            // 
            this.txtFName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFName.Location = new System.Drawing.Point(148, 66);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(114, 30);
            this.txtFName.TabIndex = 52;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblemail.Location = new System.Drawing.Point(9, 200);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(70, 31);
            this.lblemail.TabIndex = 51;
            this.lblemail.Text = "Email";
            // 
            // lblLastname
            // 
            this.lblLastname.AutoSize = true;
            this.lblLastname.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLastname.Location = new System.Drawing.Point(270, 62);
            this.lblLastname.Name = "lblLastname";
            this.lblLastname.Size = new System.Drawing.Size(123, 31);
            this.lblLastname.TabIndex = 50;
            this.lblLastname.Text = "Last Name";
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblphone.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblphone.Location = new System.Drawing.Point(9, 131);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(79, 31);
            this.lblphone.TabIndex = 48;
            this.lblphone.Text = "Phone";
            // 
            // lblFirstname
            // 
            this.lblFirstname.AutoSize = true;
            this.lblFirstname.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFirstname.Location = new System.Drawing.Point(9, 62);
            this.lblFirstname.Name = "lblFirstname";
            this.lblFirstname.Size = new System.Drawing.Size(127, 31);
            this.lblFirstname.TabIndex = 46;
            this.lblFirstname.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label2.Location = new System.Drawing.Point(72, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-10, -29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 460);
            this.panel1.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label1.Location = new System.Drawing.Point(81, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDIT";
            // 
            // EditClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 403);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "EditClientForm";
            this.Text = "EditClientForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Address.ResumeLayout(false);
            this.Address.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnٍِِSave;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblLastname;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label lblFirstname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Address;
        private System.Windows.Forms.TextBox txtBuilding;
        private System.Windows.Forms.ComboBox cmbCity;
    }
}