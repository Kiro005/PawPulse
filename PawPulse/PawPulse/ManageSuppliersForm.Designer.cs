namespace PawPulse
{
    partial class ManageSuppliersForm
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
            this.lblselectsup = new System.Windows.Forms.Label();
            this.cmbSuppliers = new System.Windows.Forms.ComboBox();
            this.btnAddsupp = new System.Windows.Forms.Button();
            this.lblphone = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblselectsup
            // 
            this.lblselectsup.AutoSize = true;
            this.lblselectsup.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblselectsup.Location = new System.Drawing.Point(21, 42);
            this.lblselectsup.Name = "lblselectsup";
            this.lblselectsup.Size = new System.Drawing.Size(101, 16);
            this.lblselectsup.TabIndex = 0;
            this.lblselectsup.Text = "Select Supplier:";
            // 
            // cmbSuppliers
            // 
            this.cmbSuppliers.FormattingEnabled = true;
            this.cmbSuppliers.Location = new System.Drawing.Point(155, 42);
            this.cmbSuppliers.Name = "cmbSuppliers";
            this.cmbSuppliers.Size = new System.Drawing.Size(148, 24);
            this.cmbSuppliers.TabIndex = 2;
            this.cmbSuppliers.SelectedIndexChanged += new System.EventHandler(this.cmbSuppliers_SelectedIndexChanged);
            // 
            // btnAddsupp
            // 
            this.btnAddsupp.Location = new System.Drawing.Point(332, 42);
            this.btnAddsupp.Name = "btnAddsupp";
            this.btnAddsupp.Size = new System.Drawing.Size(136, 24);
            this.btnAddsupp.TabIndex = 3;
            this.btnAddsupp.Text = "+ Add Supplier";
            this.btnAddsupp.UseVisualStyleBackColor = true;
            this.btnAddsupp.Click += new System.EventHandler(this.btnAddsupp_Click);
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblphone.Location = new System.Drawing.Point(21, 99);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(94, 16);
            this.lblphone.TabIndex = 1;
            this.lblphone.Text = "Contact Phone";
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbladdress.Location = new System.Drawing.Point(21, 236);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(111, 16);
            this.lbladdress.TabIndex = 4;
            this.lbladdress.Text = "Supplier Address";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblemail.Location = new System.Drawing.Point(21, 164);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(95, 16);
            this.lblemail.TabIndex = 5;
            this.lblemail.Text = "Email Address";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(54, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 38);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = " Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(24, 128);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(314, 22);
            this.txtphone.TabIndex = 69;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(24, 199);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(314, 22);
            this.txtemail.TabIndex = 70;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(24, 271);
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(314, 22);
            this.txtaddress.TabIndex = 71;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(316, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 40);
            this.btnSave.TabIndex = 72;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ManageSuppliersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(38)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(480, 391);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.btnAddsupp);
            this.Controls.Add(this.cmbSuppliers);
            this.Controls.Add(this.lblphone);
            this.Controls.Add(this.lblselectsup);
            this.Name = "ManageSuppliersForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblselectsup;
        private System.Windows.Forms.ComboBox cmbSuppliers;
        private System.Windows.Forms.Button btnAddsupp;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Button btnSave;
    }
}