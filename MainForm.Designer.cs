namespace UCSAPI_SiwonSRI
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbUserFileType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDoorStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lsvCommandList = new System.Windows.Forms.ListView();
            this.cmbLogType = new System.Windows.Forms.ComboBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtTerminalID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_reload_config = new System.Windows.Forms.Button();
            this.chkHideTerminalStatus = new System.Windows.Forms.CheckBox();
            this.lbxMessage = new System.Windows.Forms.ListBox();
            this.ctmResultMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkFingerprint = new System.Windows.Forms.CheckBox();
            this.chkFPCard = new System.Windows.Forms.CheckBox();
            this.chkPassword = new System.Windows.Forms.CheckBox();
            this.chkCard = new System.Windows.Forms.CheckBox();
            this.chkCardID = new System.Windows.Forms.CheckBox();
            this.chkAndOperation = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ctmResultMessage.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbUserFileType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbDoorStatus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lsvCommandList);
            this.groupBox1.Controls.Add(this.cmbLogType);
            this.groupBox1.Controls.Add(this.txtUserID);
            this.groupBox1.Controls.Add(this.txtTerminalID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(367, 659);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 39);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Command List";
            this.groupBox1.Visible = false;
            // 
            // cmbUserFileType
            // 
            this.cmbUserFileType.FormattingEnabled = true;
            this.cmbUserFileType.Items.AddRange(new object[] {
            "Text(CSV)",
            "Background(JPG)",
            "Success Voice(WAV)",
            "Fail Voice(WAV)",
            "Movie(MP4)"});
            this.cmbUserFileType.Location = new System.Drawing.Point(92, 72);
            this.cmbUserFileType.Name = "cmbUserFileType";
            this.cmbUserFileType.Size = new System.Drawing.Size(150, 20);
            this.cmbUserFileType.TabIndex = 10;
            this.cmbUserFileType.Text = "Text(CSV)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "*UserFileType";
            // 
            // cmbDoorStatus
            // 
            this.cmbDoorStatus.FormattingEnabled = true;
            this.cmbDoorStatus.Items.AddRange(new object[] {
            "Open",
            "UnLock",
            "Lock"});
            this.cmbDoorStatus.Location = new System.Drawing.Point(8, 72);
            this.cmbDoorStatus.Name = "cmbDoorStatus";
            this.cmbDoorStatus.Size = new System.Drawing.Size(74, 20);
            this.cmbDoorStatus.TabIndex = 8;
            this.cmbDoorStatus.Text = "Open";
            this.cmbDoorStatus.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "*DoorStatus";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lsvCommandList
            // 
            this.lsvCommandList.Font = new System.Drawing.Font("돋움", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lsvCommandList.FullRowSelect = true;
            this.lsvCommandList.Location = new System.Drawing.Point(8, 112);
            this.lsvCommandList.MultiSelect = false;
            this.lsvCommandList.Name = "lsvCommandList";
            this.lsvCommandList.Size = new System.Drawing.Size(286, 507);
            this.lsvCommandList.TabIndex = 6;
            this.toolTip1.SetToolTip(this.lsvCommandList, "원하는 명령을 더블클릭하세요.");
            this.lsvCommandList.UseCompatibleStateImageBehavior = false;
            this.lsvCommandList.View = System.Windows.Forms.View.Details;
            this.lsvCommandList.SelectedIndexChanged += new System.EventHandler(this.lsvCommandList_SelectedIndexChanged);
            this.lsvCommandList.DoubleClick += new System.EventHandler(this.lsvCommandList_DoubleClick);
            // 
            // cmbLogType
            // 
            this.cmbLogType.FormattingEnabled = true;
            this.cmbLogType.Items.AddRange(new object[] {
            "New",
            "Old",
            "All"});
            this.cmbLogType.Location = new System.Drawing.Point(168, 33);
            this.cmbLogType.Name = "cmbLogType";
            this.cmbLogType.Size = new System.Drawing.Size(74, 20);
            this.cmbLogType.TabIndex = 5;
            this.cmbLogType.Text = "New";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(88, 32);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(74, 21);
            this.txtUserID.TabIndex = 4;
            this.txtUserID.Text = "1";
            // 
            // txtTerminalID
            // 
            this.txtTerminalID.Location = new System.Drawing.Point(8, 32);
            this.txtTerminalID.Name = "txtTerminalID";
            this.txtTerminalID.Size = new System.Drawing.Size(74, 21);
            this.txtTerminalID.TabIndex = 3;
            this.txtTerminalID.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(166, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "*LogType";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "*User ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "*Terminal ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button_reload_config);
            this.groupBox2.Controls.Add(this.chkHideTerminalStatus);
            this.groupBox2.Controls.Add(this.lbxMessage);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(181, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(741, 625);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Communication Message";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(285, 595);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 24);
            this.button2.TabIndex = 7;
            this.button2.Text = "Stop Server";
            this.toolTip1.SetToolTip(this.button2, "결과리스트가 초기화 됩니다.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 595);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start Server";
            this.toolTip1.SetToolTip(this.button1, "결과리스트가 초기화 됩니다.");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button_reload_config
            // 
            this.button_reload_config.Location = new System.Drawing.Point(6, 595);
            this.button_reload_config.Name = "button_reload_config";
            this.button_reload_config.Size = new System.Drawing.Size(121, 24);
            this.button_reload_config.TabIndex = 5;
            this.button_reload_config.Text = "Reload Config";
            this.toolTip1.SetToolTip(this.button_reload_config, "결과리스트가 초기화 됩니다.");
            this.button_reload_config.UseVisualStyleBackColor = true;
            this.button_reload_config.Click += new System.EventHandler(this.button_reload_config_Click);
            // 
            // chkHideTerminalStatus
            // 
            this.chkHideTerminalStatus.AutoSize = true;
            this.chkHideTerminalStatus.Checked = true;
            this.chkHideTerminalStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideTerminalStatus.Location = new System.Drawing.Point(496, 603);
            this.chkHideTerminalStatus.Name = "chkHideTerminalStatus";
            this.chkHideTerminalStatus.Size = new System.Drawing.Size(142, 16);
            this.chkHideTerminalStatus.TabIndex = 4;
            this.chkHideTerminalStatus.Text = "Hide Terminal Status";
            this.chkHideTerminalStatus.UseVisualStyleBackColor = true;
            // 
            // lbxMessage
            // 
            this.lbxMessage.ContextMenuStrip = this.ctmResultMessage;
            this.lbxMessage.FormattingEnabled = true;
            this.lbxMessage.HorizontalScrollbar = true;
            this.lbxMessage.ItemHeight = 12;
            this.lbxMessage.Location = new System.Drawing.Point(6, 21);
            this.lbxMessage.Name = "lbxMessage";
            this.lbxMessage.Size = new System.Drawing.Size(727, 568);
            this.lbxMessage.TabIndex = 3;
            // 
            // ctmResultMessage
            // 
            this.ctmResultMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearCToolStripMenuItem});
            this.ctmResultMessage.Name = "ctmResultMessage";
            this.ctmResultMessage.Size = new System.Drawing.Size(118, 26);
            // 
            // clearCToolStripMenuItem
            // 
            this.clearCToolStripMenuItem.Name = "clearCToolStripMenuItem";
            this.clearCToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.clearCToolStripMenuItem.Text = "Clear(&C)";
            this.clearCToolStripMenuItem.Click += new System.EventHandler(this.clearCToolStripMenuItem_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(644, 595);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 24);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.toolTip1.SetToolTip(this.btnClear, "결과리스트가 초기화 됩니다.");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkFingerprint);
            this.groupBox3.Controls.Add(this.chkFPCard);
            this.groupBox3.Controls.Add(this.chkPassword);
            this.groupBox3.Controls.Add(this.chkCard);
            this.groupBox3.Controls.Add(this.chkCardID);
            this.groupBox3.Controls.Add(this.chkAndOperation);
            this.groupBox3.Location = new System.Drawing.Point(6, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(480, 45);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "AuthType for server authentication";
            this.groupBox3.Visible = false;
            // 
            // chkFingerprint
            // 
            this.chkFingerprint.AutoSize = true;
            this.chkFingerprint.Checked = true;
            this.chkFingerprint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFingerprint.Location = new System.Drawing.Point(396, 20);
            this.chkFingerprint.Name = "chkFingerprint";
            this.chkFingerprint.Size = new System.Drawing.Size(83, 16);
            this.chkFingerprint.TabIndex = 5;
            this.chkFingerprint.Text = "Fingerprint";
            this.chkFingerprint.UseVisualStyleBackColor = true;
            // 
            // chkFPCard
            // 
            this.chkFPCard.AutoSize = true;
            this.chkFPCard.Location = new System.Drawing.Point(324, 20);
            this.chkFPCard.Name = "chkFPCard";
            this.chkFPCard.Size = new System.Drawing.Size(66, 16);
            this.chkFPCard.TabIndex = 4;
            this.chkFPCard.Text = "FPCard";
            this.chkFPCard.UseVisualStyleBackColor = true;
            // 
            // chkPassword
            // 
            this.chkPassword.AutoSize = true;
            this.chkPassword.Location = new System.Drawing.Point(237, 20);
            this.chkPassword.Name = "chkPassword";
            this.chkPassword.Size = new System.Drawing.Size(81, 16);
            this.chkPassword.TabIndex = 3;
            this.chkPassword.Text = "Password";
            this.chkPassword.UseVisualStyleBackColor = true;
            // 
            // chkCard
            // 
            this.chkCard.AutoSize = true;
            this.chkCard.Checked = true;
            this.chkCard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCard.Location = new System.Drawing.Point(180, 20);
            this.chkCard.Name = "chkCard";
            this.chkCard.Size = new System.Drawing.Size(51, 16);
            this.chkCard.TabIndex = 2;
            this.chkCard.Text = "Card";
            this.chkCard.UseVisualStyleBackColor = true;
            // 
            // chkCardID
            // 
            this.chkCardID.AutoSize = true;
            this.chkCardID.Location = new System.Drawing.Point(112, 20);
            this.chkCardID.Name = "chkCardID";
            this.chkCardID.Size = new System.Drawing.Size(62, 16);
            this.chkCardID.TabIndex = 1;
            this.chkCardID.Text = "CardID";
            this.chkCardID.UseVisualStyleBackColor = true;
            // 
            // chkAndOperation
            // 
            this.chkAndOperation.AutoSize = true;
            this.chkAndOperation.Location = new System.Drawing.Point(6, 20);
            this.chkAndOperation.Name = "chkAndOperation";
            this.chkAndOperation.Size = new System.Drawing.Size(100, 16);
            this.chkAndOperation.TabIndex = 0;
            this.chkAndOperation.Text = "AndOperation";
            this.chkAndOperation.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(740, 655);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(174, 37);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "OK";
            this.toolTip1.SetToolTip(this.btnOk, "프로그램을 종료합니다.");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(142, 655);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(174, 37);
            this.btnSendCommand.TabIndex = 4;
            this.btnSendCommand.Text = "Send Command";
            this.toolTip1.SetToolTip(this.btnSendCommand, "Command를 선택후 버튼을 클릭하세요.");
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Visible = false;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 637);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 6000000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 655);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Siwon 출입통제 서버 V20181026";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ctmResultMessage.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvCommandList;
        private System.Windows.Forms.ComboBox cmbLogType;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtTerminalID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkAndOperation;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkFingerprint;
        private System.Windows.Forms.CheckBox chkFPCard;
        private System.Windows.Forms.CheckBox chkPassword;
        private System.Windows.Forms.CheckBox chkCard;
        private System.Windows.Forms.CheckBox chkCardID;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.ListBox lbxMessage;
        private System.Windows.Forms.ContextMenuStrip ctmResultMessage;
        private System.Windows.Forms.ToolStripMenuItem clearCToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbDoorStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbUserFileType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox chkHideTerminalStatus;
        private System.Windows.Forms.Button button_reload_config;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

