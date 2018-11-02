namespace UCSAPI_SiwonSRI
{
    partial class SetUserInfoForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUniqueID = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkFingerprint = new System.Windows.Forms.CheckBox();
            this.chkFPCard = new System.Windows.Forms.CheckBox();
            this.chkPassword = new System.Windows.Forms.CheckBox();
            this.chkCard = new System.Windows.Forms.CheckBox();
            this.chkCardID = new System.Windows.Forms.CheckBox();
            this.chkAndOperation = new System.Windows.Forms.CheckBox();
            this.chkIdentify = new System.Windows.Forms.CheckBox();
            this.chkAdmin = new System.Windows.Forms.CheckBox();
            this.groupAccessAuthority = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDateType = new System.Windows.Forms.ComboBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAccessAuthority = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupRFID = new System.Windows.Forms.GroupBox();
            this.txtRFID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupPassword = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupFingerPrint = new System.Windows.Forms.GroupBox();
            this.btnEnrollFromTerminal = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.cmbSecuLevel = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupAccessAuthority.SuspendLayout();
            this.groupRFID.SuspendLayout();
            this.groupPassword.SuspendLayout();
            this.groupFingerPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtUniqueID);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(744, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Info";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(399, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 5;
            // 
            // txtUniqueID
            // 
            this.txtUniqueID.Location = new System.Drawing.Point(244, 16);
            this.txtUniqueID.Name = "txtUniqueID";
            this.txtUniqueID.Size = new System.Drawing.Size(100, 21);
            this.txtUniqueID.TabIndex = 4;
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(64, 16);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Unique ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*User ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkFingerprint);
            this.groupBox2.Controls.Add(this.chkFPCard);
            this.groupBox2.Controls.Add(this.chkPassword);
            this.groupBox2.Controls.Add(this.chkCard);
            this.groupBox2.Controls.Add(this.chkCardID);
            this.groupBox2.Controls.Add(this.chkAndOperation);
            this.groupBox2.Controls.Add(this.chkIdentify);
            this.groupBox2.Controls.Add(this.chkAdmin);
            this.groupBox2.Location = new System.Drawing.Point(13, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(744, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Properties";
            // 
            // chkFingerprint
            // 
            this.chkFingerprint.AutoSize = true;
            this.chkFingerprint.Location = new System.Drawing.Point(535, 23);
            this.chkFingerprint.Name = "chkFingerprint";
            this.chkFingerprint.Size = new System.Drawing.Size(83, 16);
            this.chkFingerprint.TabIndex = 7;
            this.chkFingerprint.Text = "Fingerprint";
            this.chkFingerprint.UseVisualStyleBackColor = true;
            this.chkFingerprint.CheckedChanged += new System.EventHandler(this.chkFingerprint_CheckedChanged);
            // 
            // chkFPCard
            // 
            this.chkFPCard.AutoSize = true;
            this.chkFPCard.Location = new System.Drawing.Point(463, 23);
            this.chkFPCard.Name = "chkFPCard";
            this.chkFPCard.Size = new System.Drawing.Size(66, 16);
            this.chkFPCard.TabIndex = 6;
            this.chkFPCard.Text = "FPCard";
            this.chkFPCard.UseVisualStyleBackColor = true;
            this.chkFPCard.CheckedChanged += new System.EventHandler(this.chkFPCard_CheckedChanged);
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new System.Drawing.Point(376, 23);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(81, 16);
            this.chkPassword.TabIndex = 5;
            this.chkPassword.Text = "Password";
            this.chkPassword.UseVisualStyleBackColor = true;
            this.chkPassword.CheckedChanged += new System.EventHandler(this.chkPassword_CheckedChanged);
            // 
            // chkCard
            // 
            this.chkCard.AutoSize = true;
            this.chkCard.Location = new System.Drawing.Point(319, 23);
            this.chkCard.Name = "chkCard";
            this.chkCard.Size = new System.Drawing.Size(51, 16);
            this.chkCard.TabIndex = 4;
            this.chkCard.Text = "Card";
            this.chkCard.UseVisualStyleBackColor = true;
            this.chkCard.CheckedChanged += new System.EventHandler(this.chkCard_CheckedChanged);
            // 
            // chkCardID
            // 
            this.chkCardID.AutoSize = true;
            this.chkCardID.Location = new System.Drawing.Point(251, 23);
            this.chkCardID.Name = "chkCardID";
            this.chkCardID.Size = new System.Drawing.Size(62, 16);
            this.chkCardID.TabIndex = 3;
            this.chkCardID.Text = "CardID";
            this.chkCardID.UseVisualStyleBackColor = true;
            this.chkCardID.CheckedChanged += new System.EventHandler(this.chkCardID_CheckedChanged);
            // 
            // chkAndOperation
            // 
            this.chkAndOperation.AutoSize = true;
            this.chkAndOperation.Location = new System.Drawing.Point(145, 23);
            this.chkAndOperation.Name = "chkAndOperation";
            this.chkAndOperation.Size = new System.Drawing.Size(100, 16);
            this.chkAndOperation.TabIndex = 2;
            this.chkAndOperation.Text = "AndOperation";
            this.chkAndOperation.UseVisualStyleBackColor = true;
            this.chkAndOperation.CheckedChanged += new System.EventHandler(this.chkAndOperation_CheckedChanged);
            // 
            // chkIdentify
            // 
            this.chkIdentify.AutoSize = true;
            this.chkIdentify.Location = new System.Drawing.Point(75, 23);
            this.chkIdentify.Name = "chkIdentify";
            this.chkIdentify.Size = new System.Drawing.Size(64, 16);
            this.chkIdentify.TabIndex = 1;
            this.chkIdentify.Text = "Identify";
            this.chkIdentify.UseVisualStyleBackColor = true;
            this.chkIdentify.CheckedChanged += new System.EventHandler(this.chkIdentify_CheckedChanged);
            // 
            // chkAdmin
            // 
            this.chkAdmin.AutoSize = true;
            this.chkAdmin.Location = new System.Drawing.Point(8, 23);
            this.chkAdmin.Name = "chkAdmin";
            this.chkAdmin.Size = new System.Drawing.Size(60, 16);
            this.chkAdmin.TabIndex = 0;
            this.chkAdmin.Text = "Admin";
            this.chkAdmin.UseVisualStyleBackColor = true;
            this.chkAdmin.CheckedChanged += new System.EventHandler(this.chkAdmin_CheckedChanged);
            // 
            // groupAccessAuthority
            // 
            this.groupAccessAuthority.Controls.Add(this.dtpEndDate);
            this.groupAccessAuthority.Controls.Add(this.dtpStartDate);
            this.groupAccessAuthority.Controls.Add(this.cmbDateType);
            this.groupAccessAuthority.Controls.Add(this.txtGroupCode);
            this.groupAccessAuthority.Controls.Add(this.label7);
            this.groupAccessAuthority.Controls.Add(this.label6);
            this.groupAccessAuthority.Controls.Add(this.label5);
            this.groupAccessAuthority.Controls.Add(this.chkAccessAuthority);
            this.groupAccessAuthority.Controls.Add(this.label4);
            this.groupAccessAuthority.Location = new System.Drawing.Point(13, 127);
            this.groupAccessAuthority.Name = "groupAccessAuthority";
            this.groupAccessAuthority.Size = new System.Drawing.Size(744, 48);
            this.groupAccessAuthority.TabIndex = 2;
            this.groupAccessAuthority.TabStop = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(580, 15);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(155, 21);
            this.dtpEndDate.TabIndex = 8;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(399, 15);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(155, 21);
            this.dtpStartDate.TabIndex = 7;
            // 
            // cmbDateType
            // 
            this.cmbDateType.FormattingEnabled = true;
            this.cmbDateType.Items.AddRange(new object[] {
            "NOTUSE",
            "ALLOW",
            "RESTRICTION"});
            this.cmbDateType.Location = new System.Drawing.Point(244, 16);
            this.cmbDateType.Name = "cmbDateType";
            this.cmbDateType.Size = new System.Drawing.Size(100, 20);
            this.cmbDateType.TabIndex = 6;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Location = new System.Drawing.Point(86, 16);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(78, 21);
            this.txtGroupCode.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(560, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "~";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "DateType";
            // 
            // chkAccessAuthority
            // 
            this.chkAccessAuthority.AutoSize = true;
            this.chkAccessAuthority.Location = new System.Drawing.Point(0, 0);
            this.chkAccessAuthority.Name = "chkAccessAuthority";
            this.chkAccessAuthority.Size = new System.Drawing.Size(120, 16);
            this.chkAccessAuthority.TabIndex = 1;
            this.chkAccessAuthority.Text = "Access Authority";
            this.chkAccessAuthority.UseVisualStyleBackColor = true;
            this.chkAccessAuthority.CheckedChanged += new System.EventHandler(this.chkAccessAuthority_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Group code";
            // 
            // groupRFID
            // 
            this.groupRFID.Controls.Add(this.txtRFID);
            this.groupRFID.Controls.Add(this.label8);
            this.groupRFID.Enabled = false;
            this.groupRFID.Location = new System.Drawing.Point(13, 181);
            this.groupRFID.Name = "groupRFID";
            this.groupRFID.Size = new System.Drawing.Size(744, 49);
            this.groupRFID.TabIndex = 3;
            this.groupRFID.TabStop = false;
            this.groupRFID.Text = "RFID";
            // 
            // txtRFID
            // 
            this.txtRFID.Location = new System.Drawing.Point(75, 16);
            this.txtRFID.Name = "txtRFID";
            this.txtRFID.Size = new System.Drawing.Size(121, 21);
            this.txtRFID.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "RFID";
            // 
            // groupPassword
            // 
            this.groupPassword.Controls.Add(this.txtPassword);
            this.groupPassword.Controls.Add(this.label9);
            this.groupPassword.Enabled = false;
            this.groupPassword.Location = new System.Drawing.Point(13, 236);
            this.groupPassword.Name = "groupPassword";
            this.groupPassword.Size = new System.Drawing.Size(744, 47);
            this.groupPassword.TabIndex = 4;
            this.groupPassword.TabStop = false;
            this.groupPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(75, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Password";
            // 
            // groupFingerPrint
            // 
            this.groupFingerPrint.Controls.Add(this.btnEnrollFromTerminal);
            this.groupFingerPrint.Controls.Add(this.btnEnroll);
            this.groupFingerPrint.Controls.Add(this.cmbSecuLevel);
            this.groupFingerPrint.Controls.Add(this.label10);
            this.groupFingerPrint.Enabled = false;
            this.groupFingerPrint.Location = new System.Drawing.Point(12, 289);
            this.groupFingerPrint.Name = "groupFingerPrint";
            this.groupFingerPrint.Size = new System.Drawing.Size(744, 48);
            this.groupFingerPrint.TabIndex = 5;
            this.groupFingerPrint.TabStop = false;
            this.groupFingerPrint.Text = "Fingerprint";
            // 
            // btnEnrollFromTerminal
            // 
            this.btnEnrollFromTerminal.Location = new System.Drawing.Point(284, 14);
            this.btnEnrollFromTerminal.Name = "btnEnrollFromTerminal";
            this.btnEnrollFromTerminal.Size = new System.Drawing.Size(135, 23);
            this.btnEnrollFromTerminal.TabIndex = 3;
            this.btnEnrollFromTerminal.Text = "EnrollFrom Terminal";
            this.btnEnrollFromTerminal.UseVisualStyleBackColor = true;
            this.btnEnrollFromTerminal.Click += new System.EventHandler(this.btnEnrollFromTerminal_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(203, 14);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(75, 23);
            this.btnEnroll.TabIndex = 2;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // cmbSecuLevel
            // 
            this.cmbSecuLevel.FormattingEnabled = true;
            this.cmbSecuLevel.Items.AddRange(new object[] {
            "1:Lowest",
            "2:Lower",
            "3:Low",
            "4:Below Normal",
            "5:Normal",
            "6:Above Normal",
            "7:High",
            "8:Highter",
            "9:Highest"});
            this.cmbSecuLevel.Location = new System.Drawing.Point(76, 16);
            this.cmbSecuLevel.Name = "cmbSecuLevel";
            this.cmbSecuLevel.Size = new System.Drawing.Size(121, 20);
            this.cmbSecuLevel.TabIndex = 1;
            this.cmbSecuLevel.Text = "6:Above Normal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "SecuLevel";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(538, 343);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(106, 27);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(650, 343);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SetUserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 378);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupFingerPrint);
            this.Controls.Add(this.groupPassword);
            this.Controls.Add(this.groupRFID);
            this.Controls.Add(this.groupAccessAuthority);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SetUserInfoForm";
            this.Text = "User Infomation settings";
            this.Load += new System.EventHandler(this.SetUserInfoForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupAccessAuthority.ResumeLayout(false);
            this.groupAccessAuthority.PerformLayout();
            this.groupRFID.ResumeLayout(false);
            this.groupRFID.PerformLayout();
            this.groupPassword.ResumeLayout(false);
            this.groupPassword.PerformLayout();
            this.groupFingerPrint.ResumeLayout(false);
            this.groupFingerPrint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupAccessAuthority;
        private System.Windows.Forms.GroupBox groupRFID;
        private System.Windows.Forms.GroupBox groupPassword;
        private System.Windows.Forms.GroupBox groupFingerPrint;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUniqueID;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFingerprint;
        private System.Windows.Forms.CheckBox chkFPCard;
        private System.Windows.Forms.CheckBox chkPassword;
        private System.Windows.Forms.CheckBox chkCard;
        private System.Windows.Forms.CheckBox chkCardID;
        private System.Windows.Forms.CheckBox chkAndOperation;
        private System.Windows.Forms.CheckBox chkIdentify;
        private System.Windows.Forms.CheckBox chkAdmin;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cmbDateType;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAccessAuthority;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRFID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnEnrollFromTerminal;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.ComboBox cmbSecuLevel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}