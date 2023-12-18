namespace Blood_Donation
{
    partial class frmBloodUnit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpExpireDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grdUserDetails = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDonatedate = new System.Windows.Forms.DateTimePicker();
            this.cmbDonor = new System.Windows.Forms.ComboBox();
            this.cmpRecepiant = new System.Windows.Forms.ComboBox();
            this.cmpType = new System.Windows.Forms.ComboBox();
            this.cmpDrive = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 63);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(136, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Blood Unit Management Dashboard";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmpDrive);
            this.groupBox1.Controls.Add(this.cmpType);
            this.groupBox1.Controls.Add(this.cmpRecepiant);
            this.groupBox1.Controls.Add(this.cmbDonor);
            this.groupBox1.Controls.Add(this.dtpDonatedate);
            this.groupBox1.Controls.Add(this.dtpExpireDate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(0, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 227);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blood unit Details";
            // 
            // dtpExpireDate
            // 
            this.dtpExpireDate.Location = new System.Drawing.Point(113, 153);
            this.dtpExpireDate.Name = "dtpExpireDate";
            this.dtpExpireDate.Size = new System.Drawing.Size(223, 20);
            this.dtpExpireDate.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(261, 189);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Request";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Donation Date :";
            // 
            // grdUserDetails
            // 
            this.grdUserDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdUserDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserDetails.Location = new System.Drawing.Point(0, 294);
            this.grdUserDetails.Name = "grdUserDetails";
            this.grdUserDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdUserDetails.Size = new System.Drawing.Size(639, 144);
            this.grdUserDetails.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Blood Drive :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Donor :";
            // 
            // dtpDonatedate
            // 
            this.dtpDonatedate.Location = new System.Drawing.Point(113, 127);
            this.dtpDonatedate.Name = "dtpDonatedate";
            this.dtpDonatedate.Size = new System.Drawing.Size(223, 20);
            this.dtpDonatedate.TabIndex = 12;
            // 
            // cmbDonor
            // 
            this.cmbDonor.FormattingEnabled = true;
            this.cmbDonor.Location = new System.Drawing.Point(113, 19);
            this.cmbDonor.Name = "cmbDonor";
            this.cmbDonor.Size = new System.Drawing.Size(223, 21);
            this.cmbDonor.TabIndex = 13;
            // 
            // cmpRecepiant
            // 
            this.cmpRecepiant.FormattingEnabled = true;
            this.cmpRecepiant.Location = new System.Drawing.Point(113, 46);
            this.cmpRecepiant.Name = "cmpRecepiant";
            this.cmpRecepiant.Size = new System.Drawing.Size(223, 21);
            this.cmpRecepiant.TabIndex = 14;
            // 
            // cmpType
            // 
            this.cmpType.FormattingEnabled = true;
            this.cmpType.Location = new System.Drawing.Point(113, 73);
            this.cmpType.Name = "cmpType";
            this.cmpType.Size = new System.Drawing.Size(223, 21);
            this.cmpType.TabIndex = 15;
            // 
            // cmpDrive
            // 
            this.cmpDrive.FormattingEnabled = true;
            this.cmpDrive.Location = new System.Drawing.Point(113, 100);
            this.cmpDrive.Name = "cmpDrive";
            this.cmpDrive.Size = new System.Drawing.Size(223, 21);
            this.cmpDrive.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Recipient :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Blood Type :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Expiration Date :";
            // 
            // frmBloodUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 440);
            this.Controls.Add(this.grdUserDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmBloodUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blood Unit Management Dashboard";
            this.Load += new System.EventHandler(this.frmBloodUnit_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpExpireDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdUserDetails;
        private System.Windows.Forms.ComboBox cmpDrive;
        private System.Windows.Forms.ComboBox cmpType;
        private System.Windows.Forms.ComboBox cmpRecepiant;
        private System.Windows.Forms.ComboBox cmbDonor;
        private System.Windows.Forms.DateTimePicker dtpDonatedate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}