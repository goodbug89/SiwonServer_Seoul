
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;
using UCSAPICOMLib;
using UCBioBSPCOMLib;

using Bea.Tuxedo.ATMI;
using System.IO;
using System.Diagnostics;

namespace UCSAPI_SiwonSRI
{


    public partial class MainForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);  

        public class localdevice
        {
            public string id;
            public string ipaddress;
            public string location;
            public string group;
            public string comment;
            public string empl_gubun;
        }
        public static List<localdevice> localdevices = new List<localdevice>();
        public class EmergencyGroup
        {
            public string groupname;
            public List<string> groups;
        }
        public static List<EmergencyGroup> EmergencyGroups = new List<EmergencyGroup>();

        private static int notify_Count;
        private static string[] notify_String = new string[10];

        public static string[] Notify_String
        {
            get { return MainForm.notify_String; }
            set { MainForm.notify_String = value; }
        }

        public static String TypedString;



        // UCSAPI
        public UCSAPICOMLib.UCSAPI ucsAPI;
        private IServerUserData serveruserData;
        private ITerminalUserData terminalUserData;
        private IServerAuthentication serverAuthentication;
        private IAccessLogData accessLogData;
        private ITerminalOption terminalOption;
        private ISmartCardLayout smartCardLayout;

        // UCBioBSP
        public UCBioBSPCOMLib.UCBioBSP ucBioBSP;
        public IFPData fpData;
        private ITemplateInfo templateInfo;
        public IDevice device;
        public IExtraction extraction;
        public IFastSearch fastSearch;
        public IMatching matching;

        // initialize valiables member
        public string szTextEnrolledFIR;
        public byte[] binaryEnrolledFIR;
        public string terminalID;
        public string userID;
        public readonly long nTemplateType400 = 400;
        public readonly long nTemplateType800 = 800;
        public readonly long nTemplateType320 = 320;
        public readonly long nTemplateType256 = 256;
        public string txtFilter;
        public string txtStartDate, txtEndDate, txtStartTime, txtEndTime;
        public string txtMessage;

        public string Connect_Server_IP;
        public string Connect_Server_PORT;
        public string SiwonServer_PORT;
        public byte[] fpMinutiae;
        public bool ServerStart = false;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {

            try
            {

                // create UCSAPI Instance
                ucsAPI = new UCSAPIClass();
                serveruserData = ucsAPI.ServerUserData as IServerUserData;
                terminalUserData = ucsAPI.TerminalUserData as ITerminalUserData;
                accessLogData = ucsAPI.AccessLogData as IAccessLogData;
                serverAuthentication = ucsAPI.ServerAuthentication as IServerAuthentication;
                terminalOption = ucsAPI.TerminalOption as ITerminalOption;
                smartCardLayout = ucsAPI.SmartCardLayout as ISmartCardLayout;
                // create UCBioBSP Instance
                ucBioBSP = new UCBioBSPClass();
                fpData = ucBioBSP.FPData as IFPData;
                device = this.ucBioBSP.Device as IDevice;
                extraction = this.ucBioBSP.Extraction as IExtraction;
                fastSearch = this.ucBioBSP.FastSearch as IFastSearch;
                matching = this.ucBioBSP.Matching as IMatching;
                terminalID = txtTerminalID.Text;

                // create event handle
                ucsAPI.EventTerminalConnected += new _DIUCSAPIEvents_EventTerminalConnectedEventHandler(UCSCOMObj_EventTerminalConnected);
                ucsAPI.EventTerminalDisconnected += new _DIUCSAPIEvents_EventTerminalDisconnectedEventHandler(UCSCOMObj_EventTerminalDisconnected);
                ucsAPI.EventAddUser += new _DIUCSAPIEvents_EventAddUserEventHandler(ucsAPI_EventAddUser);
                ucsAPI.EventAntipassback += new _DIUCSAPIEvents_EventAntipassbackEventHandler(ucsAPI_EventAntipassback);
                ucsAPI.EventAuthTypeWithUniqueID += new _DIUCSAPIEvents_EventAuthTypeWithUniqueIDEventHandler(ucsAPI_EventAuthTypeWithUniqueID);
                ucsAPI.EventAuthTypeWithUserID += new _DIUCSAPIEvents_EventAuthTypeWithUserIDEventHandler(ucsAPI_EventAuthTypeWithUserID);
                ucsAPI.EventControlPeripheralDevice += new _DIUCSAPIEvents_EventControlPeripheralDeviceEventHandler(ucsAPI_EventControlPeripheralDevice);
                ucsAPI.EventDeleteAllUser += new _DIUCSAPIEvents_EventDeleteAllUserEventHandler(ucsAPI_EventDeleteAllUser);
                ucsAPI.EventDeleteUser += new _DIUCSAPIEvents_EventDeleteUserEventHandler(ucsAPI_EventDeleteUser);
                ucsAPI.EventFingerImageData += new _DIUCSAPIEvents_EventFingerImageDataEventHandler(ucsAPI_EventFingerImageData);
                ucsAPI.EventFirmwareUpgraded += new _DIUCSAPIEvents_EventFirmwareUpgradedEventHandler(ucsAPI_EventFirmwareUpgraded);
                ucsAPI.EventFirmwareUpgrading += new _DIUCSAPIEvents_EventFirmwareUpgradingEventHandler(ucsAPI_EventFirmwareUpgrading);
                ucsAPI.EventFirmwareVersion += new _DIUCSAPIEvents_EventFirmwareVersionEventHandler(ucsAPI_EventFirmwareVersion);
                ucsAPI.EventGetAccessLog += new _DIUCSAPIEvents_EventGetAccessLogEventHandler(ucsAPI_EventGetAccessLog);
                ucsAPI.EventGetAccessLogCount += new _DIUCSAPIEvents_EventGetAccessLogCountEventHandler(ucsAPI_EventGetAccessLogCount);
                ucsAPI.EventGetTAFunction += new _DIUCSAPIEvents_EventGetTAFunctionEventHandler(ucsAPI_EventGetTAFunction);
                ucsAPI.EventGetUserCount += new _DIUCSAPIEvents_EventGetUserCountEventHandler(ucsAPI_EventGetUserCount);
                ucsAPI.EventGetUserData += new _DIUCSAPIEvents_EventGetUserDataEventHandler(ucsAPI_EventGetUserData);
                ucsAPI.EventGetUserInfoList += new _DIUCSAPIEvents_EventGetUserInfoListEventHandler(ucsAPI_EventGetUserInfoList);
                ucsAPI.EventOpenDoor += new _DIUCSAPIEvents_EventOpenDoorEventHandler(ucsAPI_EventOpenDoor);
                ucsAPI.EventPictureLog += new _DIUCSAPIEvents_EventPictureLogEventHandler(ucsAPI_EventPictureLog);
                ucsAPI.EventRealTimeAccessLog += new _DIUCSAPIEvents_EventRealTimeAccessLogEventHandler(ucsAPI_EventRealTimeAccessLog);
                ucsAPI.EventSetAccessControlData += new _DIUCSAPIEvents_EventSetAccessControlDataEventHandler(ucsAPI_EventSetAccessControlData);
                ucsAPI.EventSetTAFunction += new _DIUCSAPIEvents_EventSetTAFunctionEventHandler(ucsAPI_EventSetTAFunction);
                ucsAPI.EventSetTATime += new _DIUCSAPIEvents_EventSetTATimeEventHandler(ucsAPI_EventSetTATime);
                ucsAPI.EventTerminalStatus += new _DIUCSAPIEvents_EventTerminalStatusEventHandler(ucsAPI_EventTerminalStatus);
                ucsAPI.EventVerifyCard += new _DIUCSAPIEvents_EventVerifyCardEventHandler(ucsAPI_EventVerifyCard);
                ucsAPI.EventVerifyFinger1to1 += new _DIUCSAPIEvents_EventVerifyFinger1to1EventHandler(ucsAPI_EventVerifyFinger1to1);
                ucsAPI.EventVerifyFinger1toN += new _DIUCSAPIEvents_EventVerifyFinger1toNEventHandler(ucsAPI_EventVerifyFinger1toN);
                ucsAPI.EventVerifyPassword += new _DIUCSAPIEvents_EventVerifyPasswordEventHandler(ucsAPI_EventVerifyPassword);
                ucsAPI.EventPrivateMessage += new _DIUCSAPIEvents_EventPrivateMessageEventHandler(ucsAPI_EventPrivateMessage);
                ucsAPI.EventPublicMessage += new _DIUCSAPIEvents_EventPublicMessageEventHandler(ucsAPI_EventPublicMessage);
                ucsAPI.EventUserFileUpgrading += new _DIUCSAPIEvents_EventUserFileUpgradingEventHandler(ucsAPI_EventUserFileUpgrading);
                ucsAPI.EventUserFileUpgraded += new _DIUCSAPIEvents_EventUserFileUpgradedEventHandler(ucsAPI_EventUserFileUpgraded);

                ucsAPI.EventEmergency += new _DIUCSAPIEvents_EventEmergencyEventHandler(ucsAPI_EventEmergency);
                ucsAPI.EventSetEmergency += new _DIUCSAPIEvents_EventSetEmergencyEventHandler(ucsAPI_EventSetEmergency);



                ucsAPI.EventTerminalControl += new _DIUCSAPIEvents_EventTerminalControlEventHandler(ucsAPI_EventTerminalControl);
                ucsAPI.EventRegistFace += new _DIUCSAPIEvents_EventRegistFaceEventHandler(ucsAPI_EventRegistFace);
                ucsAPI.EventACUStatus += new _DIUCSAPIEvents_EventACUStatusEventHandler(ucsAPI_EventACUStatus);
                ucsAPI.EventGetOptionFromACU += new _DIUCSAPIEvents_EventGetOptionFromACUEventHandler(ucsAPI_EventGetOptionFromACU);
                ucsAPI.EventSetOptionToACU += new _DIUCSAPIEvents_EventSetOptionToACUEventHandler(ucsAPI_EventSetOptionToACU);
                ucsAPI.EventGetLockScheduleFromACU += new _DIUCSAPIEvents_EventGetLockScheduleFromACUEventHandler(ucsAPI_EventGetLockScheduleFromACU);
                ucsAPI.EventSetLockScheduleToACU += new _DIUCSAPIEvents_EventSetLockScheduleToACUEventHandler(ucsAPI_EventSetLockScheduleToACU);
                ucsAPI.EventAlarmFromACU += new _DIUCSAPIEvents_EventAlarmFromACUEventHandler(ucsAPI_EventAlarmFromACU);
                ucsAPI.EventSetSirenToTerminal += new _DIUCSAPIEvents_EventSetSirenToTerminalEventHandler(ucsAPI_EventSetSirenToTerminal);
                ucsAPI.EventGetSirenFromTerminal += new _DIUCSAPIEvents_EventGetSirenFromTerminalEventHandler(ucsAPI_EventGetSirenFromTerminal);
                ucsAPI.EventSetSmartCardLayout += new _DIUCSAPIEvents_EventSetSmartCardLayoutEventHandler(ucsAPI_EventSetSmartCardLayout);
                ucsAPI.EventGetFpMinutiaeFromTerminal += new _DIUCSAPIEvents_EventGetFpMinutiaeFromTerminalEventHandler(ucsAPI_EventGetFpMinutiaeFromTerminal);

                ucsAPI.EventGetVoipInfoFromTerminal += new _DIUCSAPIEvents_EventGetVoipInfoFromTerminalEventHandler(ucsAPI_EventGetVoipInfoFromTerminal);
                ucsAPI.EventSetVoipInfoToTerminal += new _DIUCSAPIEvents_EventSetVoipInfoToTerminalEventHandler(ucsAPI_EventSetVoipInfoToTerminal);

                ucBioBSP.OnCaptureEvent += new _IUCBioBSPEvents_OnCaptureEventEventHandler(ucBioBSP_OnCaptureEvent);
                ucBioBSP.OnEnrollEvent += new _IUCBioBSPEvents_OnEnrollEventEventHandler(ucBioBSP_OnEnrollEvent);

                InitListview();
                InitCommandList();

                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

                GetConfig();
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {

                log.Info("Server Start on port " + SiwonServer_PORT);
                ucsAPI.ServerStart(9999, Convert.ToInt32(SiwonServer_PORT));
                ServerStart = true;
                lbxMessage.Items.Add("-->ServerStart Port " + SiwonServer_PORT);
                lbxMessage.Items.Add("   +Server listening; Err=0x" + ucsAPI.ErrorCode.ToString("X4"));
                timer1.Start();
                //timer2.Start();
                
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }

        }

        private void SetConfig()
        {
            try
            {

                //현재 프로그램이 실행되고 있는정보 가져오기: 디버깅 모드라면 bin/debug/프로그램명.exe
                FileInfo exefileinfo = new FileInfo(Application.ExecutablePath);

                string path = exefileinfo.Directory.FullName.ToString();  //프로그램 실행되고 있는데 path 가져오기
                string fileName = @"\config.ini";  //파일명

                string filePath = path + fileName;   //ini 파일 경로 
                iniUtil ini = new iniUtil(filePath);   // 만들어 놓았던 iniUtil 객체 생성(생성자 인자로 파일경로 정보 넘겨줌)

                ini.SetIniValue("Config", "SERVER_IP", "192.168.1.10 ");
                ini.SetIniValue("Config", "SERVER_PORT", "28139");
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }


        private void GetConfig()
        {
            try
            {

                lbxMessage.Items.Add(get_NOW() + "<--Config Load Start");
                lbxMessage.Refresh();
                // config.ini 파일 읽기
                localdevices.Clear();

                FileInfo exefileinfo = new FileInfo(Application.ExecutablePath);

                string path = exefileinfo.Directory.FullName.ToString();  //프로그램 실행되고 있는데 path 가져오기
                string fileName = @"\config.ini";  //파일명

                string filePath = path + fileName;   //ini 파일 경로 
                iniUtil ini = new iniUtil(filePath);   // 만들어 놓았던 iniUtil 객체 생성(생성자 인자로 파일경로 정보 넘겨줌)

                Connect_Server_IP = ini.GetIniValue("Config", "SERVER_IP");
                Connect_Server_PORT = ini.GetIniValue("Config", "SERVER_PORT");
                SiwonServer_PORT = ini.GetIniValue("Config", "SiwonServer_PORT");
                int max_id = Convert.ToInt32(ini.GetIniValue("Config", "MAX_ID"));

                for (int i = 0; i <= max_id; i++)
                {
                    string id = i.ToString();
                    if (id.Length == 1)
                        id = "0000" + id;
                    else if (id.Length == 2)
                        id = "000" + id;
                    else if (id.Length == 3)
                        id = "00" + id;
                    else if (id.Length == 4)
                        id = "0" + id;
                    string idstr = id;
                    id = "ID" + idstr;
                    string idconfig = ini.GetIniValue("DEVICE", id);
                    if (idconfig != "")
                    {
                        localdevice locdevice = new localdevice();
                        string[] param = idconfig.Split(',');
                        locdevice.id = idstr;
                        locdevice.ipaddress = param[0];
                        locdevice.location = param[1];
                        locdevice.group = param[2];
                        locdevice.comment = param[3];
                        locdevice.empl_gubun = param[4];
                      
                        localdevices.Add(locdevice);
                    }
                }
                lbxMessage.Items.Add(get_NOW() + "<--Device Config Loaded : " + localdevices.Count.ToString() + " Devices");
                lbxMessage.Refresh();
                EmergencyGroups.Clear();
                for (int i = 1; i < 1000; i++)
                {
                    string group = i.ToString();
                    group = "GROUP" + group;
                    string groupconfig = ini.GetIniValue("EMERGENCY", group);
                    if (groupconfig != "")
                    {
                        EmergencyGroup egroup = new EmergencyGroup();
                        string[] param = groupconfig.Split(',');
                        egroup.groupname = group;
                        List<string> groups = new List<string>();
                        for (int j = 0; j < param.Length; j++)
                        {
                            groups.Add(param[j]);
                        }
                        egroup.groups = groups;
                        EmergencyGroups.Add(egroup);
                    }
                }
                lbxMessage.Items.Add(get_NOW() + "<--Group Config Loaded : " + EmergencyGroups.Count.ToString() + " Groups");
                lbxMessage.Refresh();
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        private void button_reload_config_Click(object sender, EventArgs e)
        {
            try
            {

                GetConfig();
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString());
        }

        #region initialize command list
        private void InitCommandList()
        {
            AddCommandList("Server initialize related API", new List<string>()
            {
                "Server Start", 
                "Server Stop" 
            });
            AddCommandList("User management related API", new List<string>() 
            {
                "Add user to terminal", 
                "Delete user from terminal",
                "Delete all user from terminal",
                "Get user count from terminal",
                "Get user info list from terminal",
                "Get user data from terminal"
            });
            AddCommandList("Terminal option related API", new List<string>() 
            {
                "Terminal Option Dialog"
            });
            AddCommandList("Access log related API", new List<string>() 
            {
                "Get access log count from terminal",
                "Get access log from terminal"
            });
            AddCommandList("Update firmware related API", new List<string>() 
            {
                "Get firmware version from terminal",
                "Upgrade firmware to Terminal"
            });
            //AddCommandList("Access control related API", new List<string>() 
            //{
            //    "Set access control data to terminal"                
            //});
            AddCommandList("Others Command", new List<string>() 
            {
                "Open door to terminal",
                "Set Skin Resource",
                "Set Door Status",
                "Send User File",
                "Send Public Message"

            });
        }
        #endregion

        #region add list
        private void InitListview()
        {
            lsvCommandList.Items.Clear();

            ColumnHeader columnHeader0 = new ColumnHeader();
            columnHeader0.Text = "Command";
            columnHeader0.Width = 250;

            // Add the column headers to lvCommandList.
            lsvCommandList.Columns.AddRange(new ColumnHeader[] { columnHeader0 });
        }

        private void AddCommandList(string title, List<string> addList)
        {
            ListViewGroup listViewGroup1 = new ListViewGroup(title, System.Windows.Forms.HorizontalAlignment.Left);
            List<ListViewItem> itemList = new List<ListViewItem>();
            foreach (string item in addList)
            {
                ListViewItem i = new ListViewItem(new string[] { item });
                i.Group = listViewGroup1;
                itemList.Add(i);
            }

            foreach (ListViewItem item in itemList)
            {
                this.lsvCommandList.Items.Add(item);
            }

            this.lsvCommandList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1 });
        }
        #endregion

        private void lsvCommandList_DoubleClick(object sender, EventArgs e)
        {
            SendCommand();

        }

        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbxMessage.Items.Clear();
        }

        private void SendCommand()
        {
            try
            {
                int userID = Convert.ToInt32(txtUserID.Text);
                int terminalID = Convert.ToInt32(txtTerminalID.Text);
                int logType = cmbLogType.SelectedIndex;//
                if (1 > lsvCommandList.SelectedItems.Count)
                    return;

                //short result=0;
                switch (lsvCommandList.SelectedItems[0].Text)
                {
                    case "Server Start":
                        ucsAPI.ServerStart(255, 9870);
                        lbxMessage.Items.Add("-->ServerStart");
                        lbxMessage.Items.Add("   +Server listening; Err=0x" + ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Server Stop":
                        ucsAPI.ServerStop();
                        lbxMessage.Items.Add("---ServerStop");
                        lbxMessage.Items.Add("   +Closed; Err=0x" + ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Add user to terminal":  //type structure   
                        //terminalID = AddUserToTerminal(terminalID);
                        break;
                    case "Delete user from terminal":
                        terminalUserData.DeleteUserFromTerminal(0, Convert.ToInt32(txtTerminalID.Text), Convert.ToInt32(txtUserID.Text));
                        lbxMessage.Items.Add("-->Delete user from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Delete all user from terminal":
                        terminalUserData.DeleteAllUserFromTerminal(0, Convert.ToInt32(txtTerminalID.Text));
                        lbxMessage.Items.Add("-->Delete all user from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Get user count from terminal":
                        terminalUserData.GetUserCountFromTerminal(0, Convert.ToInt32(txtTerminalID.Text));
                        lbxMessage.Items.Add("-->Get user count from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Get user info list from terminal":
                        terminalUserData.GetUserInfoListFromTerminal(0, Convert.ToInt32(txtTerminalID.Text));
                        lbxMessage.Items.Add("-->Get user info list from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Get user data from terminal":
                        terminalUserData.GetUserDataFromTerminal(0, Convert.ToInt32(txtTerminalID.Text), Convert.ToInt32(txtUserID.Text));
                        lbxMessage.Items.Add("--?Get user data from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Terminal Option Dialog":
                        ucsAPI.TerminalOptionDialog(0, Convert.ToInt32(txtTerminalID.Text));
                        lbxMessage.Items.Add("-->Get/Set option from Dialog");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Get access log count from terminal":
                        accessLogData.GetAccessLogCountFromTerminal(0, Convert.ToInt32(txtTerminalID.Text), cmbLogType.SelectedIndex);
                        lbxMessage.Items.Add("-->Get access log count from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Get access log from terminal":
                        accessLogData.GetAccessLogFromTerminal(0, Convert.ToInt32(txtTerminalID.Text), cmbLogType.SelectedIndex);
                        lbxMessage.Items.Add("-->Get access log from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Get firmware version from terminal":
                        ucsAPI.GetFirmwareVersionFromTerminal(0, Convert.ToInt32(txtTerminalID.Text));
                        lbxMessage.Items.Add("-->Get firmware version from terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Upgrade firmware to Terminal":
                        OpenFileDialog openfileDialog = new OpenFileDialog();
                        openfileDialog.Filter = "Bin files|*.bin|All Files(*.*)|*.*";
                        if (openfileDialog.ShowDialog() == DialogResult.OK)
                        {
                            ucsAPI.UpgradeFirmwareToTerminal(0, Convert.ToInt32(txtTerminalID.Text), openfileDialog.FileName);
                            lbxMessage.Items.Add("-->Upgrade firmware to Terminal");
                            lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        }
                        break;
                    case "Set access control data to terminal":
                        break;
                    case "Open door to terminal":
                        ucsAPI.OpenDoorToTerminal(0, Convert.ToInt32(txtTerminalID.Text));
                        lbxMessage.Items.Add("-->Open door to terminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Set Skin Resource":
                        {
                            openfileDialog = new OpenFileDialog();
                            openfileDialog.Filter = "dll file format|*.dll|All Files(*.*)|*.*";
                            if (openfileDialog.ShowDialog() == DialogResult.OK)
                            {
                                ucsAPI.SetSkinResource(openfileDialog.FileName);
                            }
                            break;
                        }
                    case "Set Door Status":
                        ucsAPI.SetDoorStatusToTerminal(0, Convert.ToInt32(txtTerminalID.Text), cmbDoorStatus.SelectedIndex);
                        lbxMessage.Items.Add("-->SetDoorStatusToTerminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    case "Send User File":
                        {
                            if (cmbUserFileType.SelectedIndex == 0)
                                txtFilter = "Text files|*.csv|Text Files(*.csv)|*.csv";
                            else if (cmbUserFileType.SelectedIndex == 1)
                                txtFilter = "Background files|*.jpg|Background Files(*.jpg)|*.jpg";
                            else if (cmbUserFileType.SelectedIndex == 2)
                                txtFilter = "Success Voice files|*.wav|Success Voice Files(*.wav)|*.wav";
                            else if (cmbUserFileType.SelectedIndex == 3)
                                txtFilter = "Fail Voice files|*.wav|Fail Voice Files(*.wav)|*.wav";
                            else if (cmbUserFileType.SelectedIndex == 4)
                                txtFilter = "Movie files|*.mp4|Movie Files(*.mp4)|*.mp4";

                            OpenFileDialog openfileDialog1 = new OpenFileDialog();
                            openfileDialog1.Filter = txtFilter;
                            if (openfileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                ucsAPI.SendUserFileToTerminal(0, Convert.ToInt32(txtTerminalID.Text), cmbUserFileType.SelectedIndex + 1, openfileDialog1.FileName);
                                lbxMessage.Items.Add("-->SendUserFileToTerminal");
                                lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                            }
                            break;
                        }
                    case "Send Public Message":
                        // Date Format:YYYY-MM-DD or YYYYMMDD, Time Format : HH:MM or HHMM
                        txtStartDate = txtEndDate = DateTime.Now.ToString("yyyy-MM-dd");
                        txtStartTime = "06:00";
                        txtEndTime = "23:00";
                        txtMessage = "Have a good time";
                        int ShowFlag = 1; // 0 = Clear, 1 = Show
                        ucsAPI.SendPublicMessageToTerminal(0, Convert.ToInt32(txtTerminalID.Text), ShowFlag, txtStartDate, txtEndDate, txtStartTime, txtEndTime, txtMessage);
                        lbxMessage.Items.Add("-->SendPublicMessageToTerminal");
                        lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                        break;
                    default:
                        break;
                }

                lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
            }
            catch (Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        //private int AddUserToTerminal(int terminalID)
        //{
        //    try
        //    {
        //        byte[] biFPData1 = null;
        //        byte[] biFPData2 = null;
        //        long nFPDataSize1;
        //        long nFPDataSize2;
        //        long nTemplateIndex;
        //        bool bInitialize;
        //        long nTemplateSize;
        //        long nAuthType;
        //        long nSecurityLevel;

        //        this.terminalID = txtTerminalID.Text;
        //        SetUserInfoForm userFrm = new SetUserInfoForm(this);
        //        if (userFrm.ShowDialog() == DialogResult.OK)
        //        {
        //            nTemplateIndex = 0;
        //            bInitialize = false;
        //            nTemplateSize = 400;
        //            nSecurityLevel = 0; //'If the level value is 0, the level value designated in the terminal is used.

        //            serveruserData.UserID = Convert.ToInt32(userFrm.userInfo.basicInfo.userID);
        //            serveruserData.UniqueID = userFrm.userInfo.basicInfo.uniqueID;
        //            serveruserData.UserName = userFrm.userInfo.basicInfo.name;
        //            serveruserData.IsAdmin = Convert.ToInt32(userFrm.userInfo.properties.isAdmin);
        //            serveruserData.IsIdentify = Convert.ToInt32(userFrm.userInfo.properties.isIdentify);

        //            if (null != userFrm.userInfo.accessAuthority)
        //            {
        //                serveruserData.AccessGroup = userFrm.userInfo.accessAuthority.groupCode;

        //                if (userFrm.userInfo.accessAuthority.startDate < userFrm.userInfo.accessAuthority.endtDate)
        //                {
        //                    serveruserData.SetAccessDate(1, userFrm.userInfo.accessAuthority.startDate.Year, userFrm.userInfo.accessAuthority.startDate.Month, userFrm.userInfo.accessAuthority.startDate.Day,
        //                        userFrm.userInfo.accessAuthority.endtDate.Year, userFrm.userInfo.accessAuthority.endtDate.Month, userFrm.userInfo.accessAuthority.endtDate.Day);
        //                }
        //            }
        //            serveruserData.SetAuthType(Convert.ToInt32(userFrm.userInfo.properties.isAndOperation), Convert.ToInt32(userFrm.userInfo.properties.isFingerprint),
        //                Convert.ToInt32(userFrm.userInfo.properties.isFPCard), Convert.ToInt32(userFrm.userInfo.properties.isPassword),
        //                Convert.ToInt32(userFrm.userInfo.properties.isCard), Convert.ToInt32(userFrm.userInfo.properties.isCardID));
        //            if (userFrm.userInfo.properties.isCard)
        //            {
        //                serveruserData.SetCardData(1, userFrm.userInfo.rfid.rfid);
        //            }
        //            if (userFrm.userInfo.properties.isPassword)
        //            {
        //                serveruserData.Password = userFrm.userInfo.password.password;
        //            }
        //            if (userFrm.userInfo.properties.isFingerprint)
        //            {
        //                serveruserData.IsCheckSimilarFinger = 0;
        //                fpData.Export(szTextEnrolledFIR, (int)nTemplateType400);
        //            }
        //            if (ucBioBSP.ErrorCode == 0)
        //            {
        //                for (int i = 0; i < fpData.TotalFingerCount; i++)
        //                {
        //                    int nFingerID = fpData.get_FingerID(i);
        //                    nFPDataSize1 = fpData.get_FPSampleDataLength(nFingerID, (int)nTemplateIndex);
        //                    biFPData1 = fpData.get_FPSampleData(nFingerID, (int)nTemplateIndex) as byte[];
        //                    nFPDataSize2 = fpData.get_FPSampleDataLength(nFingerID, (int)nTemplateIndex + 1);
        //                    biFPData2 = fpData.get_FPSampleData(nFingerID, (int)nTemplateIndex + 1) as byte[];
        //                    if (i == 0)
        //                        bInitialize = true;
        //                    else
        //                        bInitialize = false;

        //                    serveruserData.SetFPSampleData(Convert.ToInt32(bInitialize), (int)nTemplateType400, (int)nTemplateSize, biFPData1, biFPData2);
        //                }
                        
        //            }
        //            terminalID = 0;
        //            if (!string.IsNullOrEmpty(txtTerminalID.Text))
        //                terminalID = Convert.ToInt32(txtTerminalID.Text);

        //            serveruserData.AddUserToTerminal(1, Convert.ToInt32(txtTerminalID.Text), 1);
        //            lbxMessage.Items.Add("-->Add user to terminal");
        //            lbxMessage.Items.Add("   +Closed; Err=0x" + serveruserData.ErrorCode.ToString("X4"));
        //        }
        //        return terminalID;
        //    }
        //    catch (Exception ex)
        //    {
        //        lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
        //        exception_log(new StackTrace(ex, true), ex);
        //        throw;
        //    }
        //}


        private int AddUserToTerminal(int terminalID, int UserID, string UniqueID, string UserName, int IsAdmin, int IsIdentify, string RFID)
        {
            try
            {
                byte[] biFPData1 = null;
                byte[] biFPData2 = null;
                long nFPDataSize1;
                long nFPDataSize2;
                long nTemplateIndex;
                bool bInitialize;
                long nTemplateSize;
                long nAuthType;
                long nSecurityLevel;

                //this.terminalID = txtTerminalID.Text;
                //SetUserInfoForm userFrm = new SetUserInfoForm(this);
                //if (userFrm.ShowDialog() == DialogResult.OK)
                //{
                nTemplateIndex = 0;
                bInitialize = false;
                nTemplateSize = 400;
                nSecurityLevel = 0; //'If the level value is 0, the level value designated in the terminal is used.

                serveruserData.UserID = UserID;
                serveruserData.UniqueID = UniqueID;
                serveruserData.UserName = UserName;
                serveruserData.IsAdmin = IsAdmin;
                serveruserData.IsIdentify = IsIdentify;


                //serveruserData.IsBlacklist = 0;
                //serveruserData.AuthType = 9;

                serveruserData.SetAuthType(0, 1, 1, 1, 1, 1);


                // RFID 카드 번호 저장
                serveruserData.SetCardData(1, RFID);



                terminalID = 0;
                if (!string.IsNullOrEmpty(txtTerminalID.Text))
                    terminalID = Convert.ToInt32(txtTerminalID.Text);

                serveruserData.AddUserToTerminal(0, terminalID, 1);

                lbxMessage.Items.Add("-->Add user to terminal");
                lbxMessage.Items.Add("   +Closed; Err=0x" + serveruserData.ErrorCode.ToString("X4"));
                //}
                return terminalID;
            }
            catch (Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
                throw;
            }
        }

        //private int AddUserToTerminal(int terminalID, int UserID, string UniqueID, string UserName, int IsAdmin, int IsIdentify, string RFID)
        //{
        //    try
        //    {
        //        byte[] biFPData1 = null;
        //        byte[] biFPData2 = null;
        //        long nFPDataSize1;
        //        long nFPDataSize2;
        //        long nTemplateIndex;
        //        bool bInitialize;
        //        long nTemplateSize;
        //        long nAuthType;
        //        long nSecurityLevel;

        //        this.terminalID = terminalID.ToString();
        //        //SetUserInfoForm userFrm = new SetUserInfoForm(this);
        //        //if (userFrm.ShowDialog() == DialogResult.OK)
        //        //{
        //            //                    fpData.ClearFPData();
        //        log.Error("1");
                
        //            serveruserData.InitUserData();
        //            log.Error("11");
        //            serveruserData.IsBlacklist = 0;
        //            //                    serveruserData.IsBlacklist = 1;

        //            nTemplateIndex = 0;
        //            bInitialize = false;
        //            nTemplateSize = 400;
        //            nSecurityLevel = 0; //'If the level value is 0, the level value designated in the terminal is used.

        //            serveruserData.UserID = UserID;
        //            serveruserData.UniqueID = UniqueID;
        //            serveruserData.UserName = UserName;
        //            serveruserData.IsAdmin = IsAdmin;
        //            serveruserData.IsIdentify = IsIdentify;
        //            // Set Access Flag
        //            serveruserData.IsFace1toN = Convert.ToInt32(0);
        //            serveruserData.AuthType = 9;
        //            log.Error("111");
        //            //if (null != userFrm.userInfo.accessAuthority)
        //            //{
        //            //    serveruserData.AccessGroup = userFrm.userInfo.accessAuthority.groupCode;

        //            //    if (userFrm.userInfo.accessAuthority.startDate < userFrm.userInfo.accessAuthority.endtDate)
        //            //    {
        //            //        serveruserData.SetAccessDate(1, userFrm.userInfo.accessAuthority.startDate.Year, userFrm.userInfo.accessAuthority.startDate.Month, userFrm.userInfo.accessAuthority.startDate.Day,
        //            //            userFrm.userInfo.accessAuthority.endtDate.Year, userFrm.userInfo.accessAuthority.endtDate.Month, userFrm.userInfo.accessAuthority.endtDate.Day);
        //            //    }
        //            //}
        //            serveruserData.SetAuthType(0, 1,1,1,1,1);
        //            log.Error("1111");
        //            serveruserData.SetCardData(1, RFID);
        //            log.Error("2");

        //            //if (userFrm.userInfo.properties.isCard)
        //            //{
        //            //    serveruserData.SetCardData(1, userFrm.userInfo.rfid.rfid);
        //            //}
        //            //if (userFrm.userInfo.properties.isPassword)
        //            //{
        //            //    serveruserData.Password = userFrm.userInfo.password.password;
        //            //}

        //            //if (userFrm.userInfo.properties.isFingerprint)
        //            //{
        //            //    serveruserData.IsCheckSimilarFinger = 0;
        //            //    fpData.Export(szTextEnrolledFIR, (int)nTemplateType400);
        //            //}

        //            if (ucBioBSP.ErrorCode == 0)
        //            {
        //                for (int i = 0; i < fpData.TotalFingerCount; i++)
        //                {
        //                    int nFingerID = fpData.get_FingerID(i);
        //                    nFPDataSize1 = fpData.get_FPSampleDataLength(nFingerID, (int)nTemplateIndex);
        //                    biFPData1 = fpData.get_FPSampleData(nFingerID, (int)nTemplateIndex) as byte[];
        //                    nFPDataSize2 = fpData.get_FPSampleDataLength(nFingerID, (int)nTemplateIndex + 1);
        //                    biFPData2 = fpData.get_FPSampleData(nFingerID, (int)nTemplateIndex + 1) as byte[];
        //                    if (i == 0) bInitialize = true;
        //                    else bInitialize = false;

        //                    //                            serveruserData.SetFPSampleData(Convert.ToInt32(bInitialize), (int)nTemplateType400, (int)nTemplateSize, biFPData1, biFPData2);
        //                    serveruserData.AddFingerData((int)nFingerID, (int)nTemplateType400, biFPData1, biFPData2);

        //                }

        //            }
        //            log.Error("3");

        //            if (fpData.TotalFingerCount == 0 && fpMinutiae != null)
        //            {
        //                int nFingerID = 1;
        //                biFPData1 = new byte[400];
        //                biFPData2 = new byte[400];
        //                Buffer.BlockCopy(fpMinutiae, 0, biFPData1, 0, 400);
        //                Buffer.BlockCopy(fpMinutiae, 400, biFPData2, 0, 400);
        //                serveruserData.AddFingerData((int)nFingerID, (int)nTemplateType400, biFPData1, biFPData2);
        //            }

        //            //                    serveruserData.SetDuressFinger(1, 1);

        //            log.Error("4");

        //            // Face data
        //            int nFaceCount = 0;
        //            byte[] biFaceData;
        //            //// File Read ==> user for download UserData
        //            //if (File.Exists(fileFaceData))
        //            //{
        //            //    FileStream fileStream = new FileStream(fileFaceData, FileMode.Open, FileAccess.Read);

        //            //    biFaceData = new byte[fileStream.Length - 4];
        //            //    BinaryReader binaryReader = new BinaryReader(fileStream);
        //            //    nFaceCount = binaryReader.ReadInt32();
        //            //    binaryReader.Read(biFaceData, 0, (int)fileStream.Length - 4);
        //            //    fileStream.Close();
        //            //}
        //            //else
        //            //{
        //            //    nFaceCount = 0;
        //            //    biFaceData = null;
        //            //}

        //            nFaceCount = 0;
        //            biFaceData = null;

        //            serveruserData.FaceNumber = nFaceCount;
        //            serveruserData.FaceData = biFaceData;

        //            terminalID = 0;
        //            if (!string.IsNullOrEmpty(txtTerminalID.Text))
        //                terminalID = Convert.ToInt32(txtTerminalID.Text);
        //            log.Error("5");

        //            serveruserData.AddUserToTerminal(1, Convert.ToInt32(txtTerminalID.Text), 1);
        //            log.Error("6");

        //            lbxMessage.Items.Add("-->Add user to terminal");
        //            lbxMessage.Items.Add("   +Closed; Err=0x" + serveruserData.ErrorCode.ToString("X4"));
        //        //}
        //        return terminalID;
        //    }
        //    catch (Exception ex)
        //    {
        //        lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
        //        throw;
        //    }
        //}



        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string ConvertToHex(uint result)
        {
            string str = "";
            try
            {
                string hexValue = string.Format("{0:X}", result);
                if (6 > hexValue.Length)
                {
                    for (int i = result.ToString().Length; i < 6; i++)
                    {
                        str += "0";
                    }
                    str += result.ToString();
                }
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
            return str;
        }

        private void clearCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbxMessage.Items.Clear();
        }

        #region  envet handler process
        void UCSCOMObj_EventTerminalConnected(int TerminalID, string TerminalIP)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventTerminalConnected");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +TerminalIP:{0}", TerminalIP));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            txtTerminalID.Text = this.terminalID;
        }

        void UCSCOMObj_EventTerminalDisconnected(int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Complete TerminalDisconnected");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucBioBSP_OnEnrollEvent(int EventID)
        {
            lbxMessage.Items.Add(string.Format(get_NOW() + "<--Bio Enroll : EventID({0})", EventID));
            lbxMessage.Items.Add(string.Format("   +EventID:{0}", EventID));
        }

        void ucBioBSP_OnCaptureEvent(int Quality)
        {
            lbxMessage.Items.Add(string.Format(get_NOW() + "<--Bio Capture : Quality({0})", Quality));
            lbxMessage.Items.Add(string.Format("   +Quality:{0}", Quality));
        }

        void ucsAPI_EventVerifyPassword(int TerminalID, int UserID, int AuthMode, int AntipassbackLevel, string Password)
        {
            int IsAuthorized;
            string txtEventTime;
            if (chkPassword.Checked)
                IsAuthorized = 1;
            else
                IsAuthorized = 0;
            txtEventTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.serverAuthentication.SendAuthResultToTerminal(Convert.ToInt32(this.terminalID), 1, 1, 0, IsAuthorized, txtEventTime, 0);

            lbxMessage.Items.Add(get_NOW() + "<--EventVerifyPassword");
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", UserID));
            lbxMessage.Items.Add(string.Format("   +AuthMode:{0}", AuthMode));
            lbxMessage.Items.Add(string.Format("   +Antipassback Level:{0}", AntipassbackLevel));
            lbxMessage.Items.Add(string.Format("   +Password:{0}", Password));
        }

        void ucsAPI_EventVerifyFinger1toN(int TerminalID, int AuthMode, int InputIDLength, int SecurityLevel, int AntipassbackLevel, object FingerData)
        {
            int IsAuthorized;
            string txtEventTime;
            int IsFinger;
            int IsFPCard;
            int IsPassword;
            int IsCard;
            int IsCardID;
            int IsAndOperation;

            IsAndOperation = Convert.ToInt32(chkAndOperation.Checked);
            IsCardID = Convert.ToInt32(chkCardID.Checked);
            IsCard = Convert.ToInt32(chkCard.Checked);
            IsPassword = Convert.ToInt32(chkPassword.Checked);
            IsFPCard = Convert.ToInt32(chkFPCard.Checked);
            IsFinger = Convert.ToInt32(chkFingerprint.Checked);

            if (IsFinger == 1)
                IsAuthorized = 1;
            else
                IsAuthorized = 0;
            txtEventTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.serverAuthentication.SetAuthType(IsAndOperation, IsFinger, IsFPCard, IsPassword, IsCard, IsCardID);
            this.serverAuthentication.SendAuthResultToTerminal(Convert.ToInt32(this.terminalID), 1, 1, 0, IsAuthorized, txtEventTime, 0);

            lbxMessage.Items.Add(get_NOW() + "<--EventVerifyFinger1toN");
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +AuthMode:{0}", AuthMode));
            lbxMessage.Items.Add(string.Format("   +InputID Length:{0}", InputIDLength));
            lbxMessage.Items.Add(string.Format("   +Security Level:{0}", SecurityLevel));
            lbxMessage.Items.Add(string.Format("   +Antipassback Level:{0}", AntipassbackLevel));
            lbxMessage.Items.Add(string.Format("   +FingerData:{0}", FingerData));
        }

        void ucsAPI_EventVerifyFinger1to1(int TerminalID, int UserID, int AuthMode, int SecurityLevel, int AntipassbackLevel, object FingerData)
        {
            int IsAuthorized;
            string txtEventTime;
            if (chkFingerprint.Checked)
                IsAuthorized = 1;
            else
                IsAuthorized = 0;

            txtEventTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.serverAuthentication.SendAuthResultToTerminal(Convert.ToInt32(this.terminalID), 1, 1, 0, IsAuthorized, txtEventTime, 0);

            lbxMessage.Items.Add(get_NOW() + "<--EventVerifyFinger1to1");
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", UserID));
            lbxMessage.Items.Add(string.Format("   +AuthMode:{0}", AuthMode));
            lbxMessage.Items.Add(string.Format("   +Security Level:{0}", SecurityLevel));
            lbxMessage.Items.Add(string.Format("   +Antipassback Level:{0}", AntipassbackLevel));
            lbxMessage.Items.Add(string.Format("   +FingerData:{0}", FingerData));
        }

        void ucsAPI_EventVerifyCard(int TerminalID, int AuthMode, int AntipassbackLevel, string TextRFID)
        {
            try
            {
              
                lbxMessage.Items.Add(get_NOW() + "<--EventVerifyCard");
                lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
                lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
                lbxMessage.Items.Add(string.Format("   +AuthMode:{0}", AuthMode));
                lbxMessage.Items.Add(string.Format("   +Antipassback Level:{0}", AntipassbackLevel));
                lbxMessage.Items.Add(string.Format("   +TextRFID:{0}", TextRFID));
                lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;

                tag_event(TerminalID, AuthMode, AntipassbackLevel, TextRFID);
                

            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }

            
        }

        void ucsAPI_EventRealTimeAccessLog(int TerminalID)
        {
            try
            {

                lbxMessage.Items.Add(get_NOW() + "<--EventRealTimeAccessLog");
                lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
                lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
                lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", this.terminalID));
                lbxMessage.Items.Add(string.Format("   +UserID:{0}", this.accessLogData.UserID));
                lbxMessage.Items.Add(string.Format("   +DataTime:{0}", this.accessLogData.DateTime));
                lbxMessage.Items.Add(string.Format("   +AuthMode:{0}", this.accessLogData.AuthMode));
                lbxMessage.Items.Add(string.Format("   +AuthType:{0}", this.accessLogData.AuthType));
                lbxMessage.Items.Add(string.Format("   +IsAuthorized:{0}", this.accessLogData.IsAuthorized));
                //lbxMessage.Items.Add(string.Format("   +Reason:{0}", this.accessLogData.ErrorCode));
                lbxMessage.Items.Add(string.Format("   +RFID:{0}", this.accessLogData.RFID));
                lbxMessage.Items.Add(string.Format("   +PictureDataLength:{0}", this.accessLogData.PictureDataLength));
                lbxMessage.Items.Add(string.Format("   +Progress:{0}/{1}", this.accessLogData.CurrentIndex, this.accessLogData.TotalNumber));

                tag_event(TerminalID, this.accessLogData.AuthMode, 0, this.accessLogData.RFID);
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        void tag_event(int TerminalID, int AuthMode, int AntipassbackLevel, string TextRFID)
        {
            try
            {
                // 카드 인식 후 발생하는 이벤트
                int IsAuthorized;
                string txtEventTime;
                int IsFinger;
                int IsFPCard;
                int IsPassword;
                int IsCard;
                int IsCardID;
                int IsAndOperation;

                IsAndOperation = Convert.ToInt32(chkAndOperation.Checked);
                IsCardID = Convert.ToInt32(chkCardID.Checked);
                IsCard = Convert.ToInt32(chkCard.Checked);
                IsPassword = Convert.ToInt32(chkPassword.Checked);
                IsFPCard = Convert.ToInt32(chkFPCard.Checked);
                IsFinger = Convert.ToInt32(chkFingerprint.Checked);




                // Device ID를 이용하여 IP Address를 구함
                string ip_addr = "";
                localdevice device = new localdevice();
                for (int i = 0; i < localdevices.Count; i++)
                {
                    if (Convert.ToInt32(localdevices[i].id) == TerminalID)
                    {
                        device = localdevices[i];
                        ip_addr = device.ipaddress;
                        break;
                    }
                }
                if (ip_addr == "")
                {
                    // terminal id로 ip 생성
                    String third_ip = "";
                    String fourth_ip = "";
                    String terminal_id = TerminalID.ToString();
                    if (terminal_id.Length == 4)
                        terminal_id = "0" + terminal_id;

                    fourth_ip = terminal_id.Substring(2, 3);
                    third_ip = terminal_id.Substring(0, 2);

                    ip_addr = "192.168." + third_ip + "." + fourth_ip;
                    lbxMessage.Items.Add(get_NOW() + "<--" + TerminalID.ToString() + " ID not found in config!! Calcutated IP is " + ip_addr);
                }

                lbxMessage.Items.Add("TAG ==> " + TextRFID + "  구분 : " + device.empl_gubun);
                log.Info("TAG ==> " + TextRFID + "  구분 : " + device.empl_gubun);
                lbxMessage.Items.Add("IP Address : " + ip_addr + "==>" + device.location);
                log.Info("IP Address : " + ip_addr + "==>" + device.location);

                // 턱시도 처리
                // 서버에서 C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\NETFX 4.0 Tools>gacutil /i c:\tuxedo\bin\libwscdnet.dll 실행 필요
                //AddUserToTerminal(TerminalID, 0102, "0102", "0102", 0, 1, "1500010200");


                string recv_TranCode = "";
                string pass = "";
                string terminal = TerminalID.ToString();
                string[] pass_array;
                string pass_message;
                string pass_result;
                string pass_result_str;

                //턱시도 함수 호출
                try
                {
                    pass = Tuxedo_TP_CALL(ip_addr, TextRFID, recv_TranCode, Connect_Server_IP, Connect_Server_PORT, device.empl_gubun);
                }
                catch (System.Exception ex)
                {
                    exception_log(new StackTrace(ex, true), ex);
                }
                //pass = "0         gpb0277a        gpbemplm    조회 완료#                                                  @P	4	";
                lbxMessage.Items.Add("Result!! ==> " + pass);
                log.Info("Result!! ==> " + pass);
                if (pass == "Tuxedo ERROR")
                {
                    log.Error("Tuxedo Error!!");
                    lbxMessage.Items.Add("Tuxedo Error!!");

                    //terminalUserData.GetUserDataFromTerminal(0, Convert.ToInt16(terminalID), Convert.ToInt16(userID));
                    //if (this.ucsAPI.ErrorCode.ToString("X4") == UCSAPIERR_NONE)
                    //{
                    //    // 저장된 사용자가 없으니 문을 열지 말자
                    //}
                    //else
                    //{
                    //    // 저장된 사용자가 있으니 문을 열자
                    //}


                    // Tuxedo가 죽었으면 무조건 문을 연다?

                    ucsAPI.OpenDoorToTerminal(0, TerminalID);
                    lbxMessage.Items.Add("-->Open door to terminal(Tuxedo Down!!)");
                    lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                    lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;


                    //ucsAPI.ServerStop();

                    //while (true)
                    //{
                    //    Thread.Sleep(5000);
                    //    log.Info("Trying Server Start on port " + SiwonServer_PORT);
                    //    ucsAPI.ServerStart(9999, Convert.ToInt32(SiwonServer_PORT));
                    //    lbxMessage.Items.Add("-->Timer ServerStart Port " + SiwonServer_PORT);
                    //    lbxMessage.Items.Add("   +Server listening; Err=0x" + ucsAPI.ErrorCode.ToString("X4"));
                    //    if (ucsAPI.ErrorCode.ToString("X4") == "0000")
                    //    {
                    //        break;
                    //    }
                    //}
                }
                else
                {
                    pass_array = pass.Split('@');

                    pass_message = pass_array[0];
                    pass_result = pass_array[1].Substring(0, 1).ToUpper();

                    //pass_message = "FAIL";
                    //pass_result = "F";
                    if (pass_result == "P")
                    {
                        pass_result_str = "PASS";
                        IsAuthorized = 1;
                    }
                    else
                    {
                        pass_result_str = "FAIL";
                        IsAuthorized = 0;
                    }

                    lbxMessage.Items.Add("Tuxedo : " + pass_message + "    Result : " + pass_result_str);

                    int userid = Convert.ToInt16(TextRFID.Substring(4, 4));
                    txtEventTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    this.serverAuthentication.SetAuthType(IsAndOperation, IsFinger, IsFPCard, IsPassword, IsCard, IsCardID);

                    this.serverAuthentication.SendAuthResultToTerminal(TerminalID, userid, 1, 1, IsAuthorized, txtEventTime, 0);

                    try
                    {
                        if (IsAuthorized == 1)
                        {
                            // 단말기에 사용자 정보를 추가한다
                            AddUserToTerminal(TerminalID, userid, userid.ToString(), userid.ToString(), 0, 1, TextRFID);
                            // 문을 연다
                            ucsAPI.OpenDoorToTerminal(0, TerminalID);
                            lbxMessage.Items.Add("-->Open door to terminal");
                            lbxMessage.Items.Add("   +ErrorCode :" + this.ucsAPI.ErrorCode.ToString("X4"));
                            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
                            //log.Info("Door Open - IP : " + ip_addr + " RFID : " + TextRFID + " Terminal ID : " + TerminalID.ToString());
                            //AddUserToTerminal(TerminalID);

                        }
                        else
                        {
                            if (userid != 1)    // 관리자 아이디는 삭제하지 않는다
                            {
                                // 단말기에 사용자 정보를 삭제한다
                                terminalUserData.DeleteUserFromTerminal(0, TerminalID, userid);
                                lbxMessage.Items.Add("-->Delete user to terminal : " + userid.ToString());
                                lbxMessage.Items.Add("   +Closed; Err=0x" + terminalUserData.ErrorCode.ToString("X4"));
                            }

                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                       
                    }
                   
                    //log.Error("4");

                }
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        void ucsAPI_EventTerminalStatus(int ClientID, int TerminalID, int TerminalStatus, int LockStatus, int CoverStatus)
        {
            int kkk = Convert.ToInt32(chkHideTerminalStatus.Checked);
            if (kkk == 1) return;

            lbxMessage.Items.Add(get_NOW() + "<--EventTerminal Status");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +Terminal Status:{0}", TerminalStatus));
            lbxMessage.Items.Add(string.Format("   +Lock Status:{0}", LockStatus));
            lbxMessage.Items.Add(string.Format("   +Door Status:{0}", CoverStatus));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;

           
            
        }

        void ucsAPI_EventSetTATime(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventSetTATime");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventSetTAFunction(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventSetTAFunction");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventSetAccessControlData(int ClientID, int TerminalID, int DataType)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventSetAccessControlData");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +DataType:{0}", DataType));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }


        void ucsAPI_EventPictureLog(int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventPictureLog");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", this.terminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", this.accessLogData.UserID));
            lbxMessage.Items.Add(string.Format("   +DataTime:{0}", this.accessLogData.DateTime));
            lbxMessage.Items.Add(string.Format("   +AuthMode:{0}", this.accessLogData.AuthMode));
            lbxMessage.Items.Add(string.Format("   +AuthType:{0}", this.accessLogData.AuthType));
            lbxMessage.Items.Add(string.Format("   +IsAuthorized:{0}", this.accessLogData.IsAuthorized));
            //lbxMessage.Items.Add(string.Format("   +Reason:{0}", this.accessLogData.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +RFID:{0}", this.accessLogData.RFID));
            lbxMessage.Items.Add(string.Format("   +PictureDataLength:{0}", this.accessLogData.PictureDataLength));
            lbxMessage.Items.Add(string.Format("   +Progress:{0}/{1}", this.accessLogData.CurrentIndex, this.accessLogData.TotalNumber));
        }

        void ucsAPI_EventOpenDoor(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventOpenDoor");
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventGetUserInfoList(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventGetUserInfoList");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", this.terminalUserData.UserID));
            lbxMessage.Items.Add(string.Format("   +Admin:{0}", this.terminalUserData.IsAdmin));
            lbxMessage.Items.Add(string.Format("   +Progress:{0}/{1}", this.terminalUserData.CurrentIndex, this.terminalUserData.TotalNumber));
        }

        void ucsAPI_EventGetUserData(int ClientID, int TerminalID)
        {
            try
            {

                byte[] biFPData1 = null;
                byte[] biFPData2 = null;
                long nFPDataSize1;
                long nFPDataSize2;
                long nFPDataCount;
                byte[] biPictureData = null;
                long nPictureDataLength;
                long nCardNumber;

                nFPDataCount = this.terminalUserData.TotalFingerCount;
                for (int i = 0; i < nFPDataCount; i++)
                {
                    int nFingerID = this.terminalUserData.get_FingerID(i);
                    nFPDataSize1 = this.terminalUserData.get_FPSampleDataLength(nFingerID, 0);
                    biFPData1 = this.terminalUserData.get_FPSampleData(nFingerID, 0) as byte[];
                    nFPDataSize2 = this.terminalUserData.get_FPSampleDataLength(nFingerID, 1);
                    biFPData2 = this.terminalUserData.get_FPSampleData(nFingerID, 1) as byte[];
                }
                lbxMessage.Items.Add(get_NOW() + "<--EventGetUserData");
                lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
                lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
                lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
                lbxMessage.Items.Add(string.Format("   +UserID:{0}", this.terminalUserData.UserID));
                lbxMessage.Items.Add(string.Format("   +Admin:{0}", this.terminalUserData.IsAdmin));
                lbxMessage.Items.Add(string.Format("   +AccessGroup:{0}", this.terminalUserData.AccessGroup));
                lbxMessage.Items.Add(string.Format("   +AccessDateType:{0}", this.terminalUserData.AccessDateType));
                lbxMessage.Items.Add(string.Format("   +AccessDate:{0}~{1}", this.terminalUserData.StartAccessDate, this.terminalUserData.EndAccessDate));
                lbxMessage.Items.Add(string.Format("   +Password:{0}", this.terminalUserData.Password));
                for (int i = 0; i < this.terminalUserData.CardNumber; i++)
                {
                    lbxMessage.Items.Add(string.Format("   +RFID:{0}", this.terminalUserData.get_RFID(i)));
                }
                lbxMessage.Items.Add(string.Format("   +TotalFingerCount:{0}", nFPDataCount));
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        void ucsAPI_EventGetUserCount(int ClientID, int TerminalID, int AdminCount, int UserCount)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventGetUserCount");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +AdminCount:{0}", AdminCount));
            lbxMessage.Items.Add(string.Format("   +UserCount:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventGetTAFunction(int ClientID, int TerminalID, int TAMode)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventGetTAFunction");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +TAMode:{0}", TAMode));
        }

        void ucsAPI_EventGetAccessLogCount(int ClientID, int TerminalID, int LogCount)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventGetAccessLogCount");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +LogCount:{0}", LogCount));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventGetAccessLog(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventGetAccessLog");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", this.accessLogData.UserID));
            lbxMessage.Items.Add(string.Format("   +DateTime:{0}", this.accessLogData.DateTime));
            lbxMessage.Items.Add(string.Format("   +AuthMode:{0}", this.accessLogData.AuthMode));
            lbxMessage.Items.Add(string.Format("   +AuthType:{0}", this.accessLogData.AuthType));
            lbxMessage.Items.Add(string.Format("   +IsAuthorized:{0}", this.accessLogData.IsAuthorized));
            //lbxMessage.Items.Add(string.Format("   +Reason:{0}", this.accessLogData.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +RFID:{0}", this.accessLogData.RFID));
            lbxMessage.Items.Add(string.Format("   +PictureDataLength:{0}", this.accessLogData.PictureDataLength));
            lbxMessage.Items.Add(string.Format("   +Progress:{0}/{1}", this.accessLogData.CurrentIndex, this.accessLogData.TotalNumber));
        }

        void ucsAPI_EventFirmwareVersion(int ClientID, int TerminalID, string Version)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventFirmwareVersion");
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +Version:{0}", Version));
        }

        void ucsAPI_EventFirmwareUpgrading(int ClientID, int TerminalID, int CurrentIndex, int TotalNumber)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventFirmwareUpgrading");
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +CurrentIndex:{0}", CurrentIndex));
            lbxMessage.Items.Add(string.Format("   +TotalNumber:{0}", TotalNumber));
        }

        void ucsAPI_EventFirmwareUpgraded(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventFirmwareUpgraded");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventFingerImageData(int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventFingerImageData");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
        }

        void ucsAPI_EventDeleteUser(int ClientID, int TerminalID, int UserID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventDeleteUser");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", UserID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventDeleteAllUser(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventDeleteAllUser");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventControlPeripheralDevice(int Handle, int TerminalID, int PeripheralDeviceID, int ControlCommand)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventControlPeripheralDevice");
            lbxMessage.Items.Add(string.Format("   +Handle:{0}", Handle));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +PeripheralDeviceID:{0}", PeripheralDeviceID));
            lbxMessage.Items.Add(string.Format("   +ControlCommand:{0}", ControlCommand));
        }

        void ucsAPI_EventAuthTypeWithUserID(int TerminalID, int UserID)
        {
            CallSetAuthTypeAndSendAuthInfoToTerminal();

            lbxMessage.Items.Add(get_NOW() + "<--EventAuthTypeWithUserID");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", UserID));
        }


        void ucsAPI_EventAuthTypeWithUniqueID(int TerminalID, string UniqueID)
        {
            CallSetAuthTypeAndSendAuthInfoToTerminal();

            lbxMessage.Items.Add(get_NOW() + "<--EventAuthTypeWithUniqueID");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UniqueID:{0}", UniqueID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventAntipassback(int TerminalID, int UserID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventAntipassback");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", UserID));
            int Result = 1; // 0 = Faile, 1 = Success
            this.serverAuthentication.SendAntipassbackResultToTerminal(TerminalID, UserID, Result);
            lbxMessage.Items.Add("-->SendAntipassbackResultToTerminal");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", UserID));
            lbxMessage.Items.Add(string.Format("   +Result:{0}", Result));
        }


        void ucsAPI_EventAddUser(int ClientID, int TerminalID, int UserID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventAdduser");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +UserID:{0}", UserID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        void ucsAPI_EventUserFileUpgrading(int ClientID, int TerminalID, int CurrentIndex, int TotalNumber)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventUserFileUpgrading");
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +CurrentIndex:{0}", CurrentIndex));
            lbxMessage.Items.Add(string.Format("   +TotalNumber:{0}", TotalNumber));
        }

        void ucsAPI_EventUserFileUpgraded(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventUserFileUpgraded");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }
        void ucsAPI_EventPrivateMessage(int TerminalID, int Reserved)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventPrivateMessage");
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }
        void ucsAPI_EventPublicMessage(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventPublicMessage");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
        }

        private void CallSetAuthTypeAndSendAuthInfoToTerminal()
        {
            int IsFinger;
            int IsFPCard;
            int IsPassword;
            int IsCard;
            int IsCardID;
            int IsAndOperation;

            IsAndOperation = Convert.ToInt32(chkAndOperation.Checked);
            IsFPCard = Convert.ToInt32(chkFPCard.Checked);
            IsCard = Convert.ToInt32(chkCard.Checked);
            IsPassword = Convert.ToInt32(chkPassword.Checked);
            IsCardID = Convert.ToInt32(chkCard.Checked);
            IsFinger = Convert.ToInt32(chkFingerprint.Checked);

            this.serverAuthentication.SetAuthType(IsAndOperation, IsFinger, IsFPCard, IsPassword, IsCard, IsCardID);
            this.serverAuthentication.SendAuthInfoToTerminal(Convert.ToInt32(this.terminalID), 1, 1, 0);
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucsAPI.ServerStop();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lsvCommandList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbxMessage.Items.Clear();
        }



        internal static string Tuxedo_TP_CALL(string IP, string rfid_tag, string recv_TranCode,string server_ip,string server_port,string empl_gubun)
        {
            notify_Count = 0;

            string ip_addr = IP;
            //MessageBox.Show(rfid_tag);

            string cardgb = rfid_tag.Substring(0, 1);
            string emplno = "";
            string usedno = "";

            if (cardgb == "1" || cardgb == "2")
            {
                emplno = rfid_tag.Substring(1, 7);
                usedno = rfid_tag.Substring(8, 2);
            }
            else
            {
                emplno = rfid_tag.Substring(1, 8);
                usedno = "00";
            }



            string send_TranCode = "";

            if (empl_gubun == "환자")
            {
                send_TranCode = "";
                send_TranCode += "Q";
                send_TranCode += "ipaddr" + "\t" + ip_addr + "\t";
                send_TranCode += "cardgb" + "\t" + cardgb + "\t";
                send_TranCode += "idntno" + "\t" + emplno + "\t";
                send_TranCode += "usedno" + "\t" + usedno + "\t";
                send_TranCode += "\n";
            }
            else if (empl_gubun == "직원")
            {
                send_TranCode = "";
                send_TranCode += "Q";
                send_TranCode += "ipaddr" + "\t" + ip_addr + "\t";
                send_TranCode += "cardgb" + "\t" + cardgb + "\t";
                send_TranCode += "emplno" + "\t" + emplno + "\t";
                send_TranCode += "usedno" + "\t" + usedno + "\t";
                send_TranCode += "\n";
            }
            AppContext appContext = null;
            TypedTPINIT tpinit = null;
            try
            {
                
                //접속할 서버
                Utils.tuxputenv("WSNADDR=//" + server_ip + ":" + server_port);

                tpinit = new TypedTPINIT();


                appContext = AppContext.tpinit(tpinit);


                //송신내용
                TypedString send_String = new TypedString(70000);

                //수신내용
                TypedCArray recv_String = new TypedCArray(70000);


                long a = 2;
                appContext.tpsetunsol(new UnsolicitedMessageHandler(MessageHandeler));
                send_String.PutString(0, send_TranCode, send_TranCode.Length);
                TypedBuffer buffer = (TypedBuffer)recv_String;

                if (empl_gubun == "환자")
                {
                    appContext.tpcall("GPB0278P", (TypedBuffer)send_String, ref buffer, a);
                }
                else if (empl_gubun == "직원")
                {
                    appContext.tpcall("GPB0273P", (TypedBuffer)send_String, ref buffer, a);
                }

                recv_TranCode = ((TypedString)buffer).GetString(0, 1000);


                //IntPtr address = (IntPtr)recv_String.Buffer.ToInt64();
                //recv_TranCode = Marshal.PtrToStringAnsi(address);
                appContext.tpterm();
            }
            catch (Exception ex)
            {
                exception_log(new StackTrace(ex, true), ex);
                recv_TranCode = "Tuxedo ERROR";
                appContext.tpterm();
                tpinit.Dispose();
                
            }

            return recv_TranCode;
        }

        internal static void MessageHandeler(AppContext appContext, TypedBuffer typeBuffer, long flages)
        {
            IntPtr intPtr = (IntPtr)typeBuffer.Buffer.ToInt64();
            string recv_String = Marshal.PtrToStringAnsi(intPtr);
            notify_Count = notify_Count + 1;
            notify_String[notify_Count - 1] = recv_String;
        }

        string get_NOW()
        {
            string NOW = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            return NOW;
        }
        void ucsAPI_EventEmergency(int TerminalID, int SignalType, int SignalValue, int Reserved1, int Reserved2)
        {
            try
            {

                // Device ID를 이용하여 GROUP을 구함
                string group = "";
                localdevice device = new localdevice();
                for (int i = 0; i < localdevices.Count; i++)
                {
                    device = localdevices[i];
                    if (Convert.ToInt32(device.id) == TerminalID)
                    {
                        group = device.group;
                        break;
                    }
                }
                string status = "";
                if (SignalValue == 1)
                {
                    status = "화재발생경보!!";
                }
                else
                {
                    status = "경보해제!!";
                }
                lbxMessage.Items.Add(get_NOW() + "<--EventEmergency : " + status + " " + device.ipaddress + " 위치 : " + device.location);
                lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
                lbxMessage.Items.Add(string.Format("   +SignalType:{0}", SignalType));
                lbxMessage.Items.Add(string.Format("   +SignalValue:{0}", SignalValue));


                //GROUP을 이용하여 세팅할 대상 GROUP을 구한다
                EmergencyGroup Egroup = new EmergencyGroup();
                for (int i = 0; i < EmergencyGroups.Count; i++)
                {
                    Egroup = EmergencyGroups[i];
                    if (group == Egroup.groupname)
                    {
                        break;
                    }
                }
                // 대상 GROUP을 조회하여 비상신호 전달
                for (int i = 0; i < Egroup.groups.Count; i++)
                {
                    string targetgroup = Egroup.groups[i];
                    for (int j = 0; j < localdevices.Count; j++)
                    {
                        localdevice targetdevice = localdevices[j];
                        if (targetgroup == targetdevice.group)
                        {
                            int doorcontrol = SignalValue;
                            int alarmcontrol = SignalValue;
                            if (SignalValue == 1)
                            {
                                ucsAPI.SendPrivateMessageToTerminal(0, Convert.ToInt32(targetdevice.id), 0, "Fire Alert!!", 1000);
                            }
                            else
                            {
                                ucsAPI.SendPrivateMessageToTerminal(0, Convert.ToInt32(targetdevice.id), 0, "", 1);
                            }
                            // 비상 신호 전달!!
                            ucsAPI.SetEmergencyToTerminal(0, Convert.ToInt32(targetdevice.id), SignalType, SignalValue, doorcontrol, alarmcontrol, 0, 0);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        void ucsAPI_EventSetEmergency(int ClientID, int TerminalID)
        {
            try
            {

                // Device ID를 이용하여 GROUP을 구함
                string group = "";
                localdevice device = new localdevice();
                for (int i = 0; i < localdevices.Count; i++)
                {
                    device = localdevices[i];
                    if (Convert.ToInt32(device.id) == TerminalID)
                    {
                        group = device.group;
                        break;
                    }
                }

                lbxMessage.Items.Add(get_NOW() + "<--EventSetEmergency : " + device.ipaddress + " 위치 : " + device.location);
                lbxMessage.Items.Add(string.Format("   +CID, TID : {0}, {1}", ClientID, TerminalID));
            }
            catch (System.Exception ex)
            {
                lbxMessage.Items.Add(string.Format("Error! ErrorMessage:{0}", ex.Message));
                exception_log(new StackTrace(ex, true), ex);
            }
        }

        void ucsAPI_EventTerminalControl(int ClientID, int TerminalID, int lockStatus, int lockType)
        {
            lbxMessage.Items.Add(get_NOW() + "<--EventTerminalControl");
            lbxMessage.Items.Add(string.Format("   +CID, TID : {0}, {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +lockStatus , lockType : {0}, {1}", lockStatus, lockType));
        }

        void ucsAPI_EventRegistFace(int ClientID, int TerminalID, int CurrentIndex, int TotalNumber, object EventData)
        {
            byte[] RegFaceData = (byte[])EventData;

            if (CurrentIndex == 0 && TotalNumber == 0)
            {
                lbxMessage.Items.Add(get_NOW() + "<--EventRegistFace");
                lbxMessage.Items.Add(string.Format("   +CID, TID : {0}, {1}", ClientID, TerminalID));
                lbxMessage.Items.Add(string.Format("   Process Canceled.({0})", EventData.GetType()));
            }
            else
            {
                lbxMessage.Items.Add(get_NOW() + "<--EventRegistFace");
                lbxMessage.Items.Add(string.Format("   +CID, TID : {0}, {1}", ClientID, TerminalID));
                lbxMessage.Items.Add(string.Format("   +Process(Current, Total) : {0}, {1}", CurrentIndex, TotalNumber));
                lbxMessage.Items.Add(string.Format("   +RegFace Length : {0}", RegFaceData.Length));
            }
        }
        void ucsAPI_EventACUStatus(int ClientID, int TerminalID, int Notice, object binStatus, string strStatus)
        {
            //int kkk = Convert.ToInt32(chkHideTerminalStatus.Checked);
            //if (kkk == 1) return;

            lbxMessage.Items.Add(get_NOW() + "<--EventACU Status");
            lbxMessage.Items.Add(string.Format("   +ClientID:{0}", ClientID));
            lbxMessage.Items.Add(string.Format("   +TerminalID:{0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +Notice:{0}", Notice));
            lbxMessage.Items.Add(string.Format("   +strStatus:{0}", strStatus));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
            // Get Status
            {
                int a1 = this.terminalOption.get_ACUStatusValue(1, 4);
                int a2 = this.terminalOption.get_ACUStatusValue(2, 1);

                int b1, b2, b3, b4, b5, b6, b7, b8;
                b1 = b2 = b3 = b4 = b5 = b6 = b7 = b8 = 0;
                this.terminalOption.ACUGetReaderVersion(5, ref b1, ref b2, ref b3, ref b4, ref b5, ref b6, ref b7, ref b8);
            }
        }
        void ucsAPI_EventGetOptionFromACU(int ClientID, int TerminalID, int lenOption, object binOption, string strOption)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event Get ACU Option");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +lenOption = {0}", lenOption));
            lbxMessage.Items.Add(string.Format("   +strOption = {0}", strOption));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        void ucsAPI_EventSetOptionToACU(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event Set ACU Option");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        void ucsAPI_EventGetLockScheduleFromACU(int ClientID, int TerminalID, int LockIndex)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event Get Lock Schedule from ACU");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +LockIndex = {0}", LockIndex));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;

            int a, b;
            terminalOption.GetDaySchedule(1, 0, 1);
            a = terminalOption.StartHour;
            b = terminalOption.EndHour;
            terminalOption.GetDaySchedule(1, 0, 2);
            a = terminalOption.StartHour;
            b = terminalOption.EndHour;
            terminalOption.GetDaySchedule(1, 0, 3);
            a = terminalOption.StartHour;
            b = terminalOption.EndHour;

        }

        void ucsAPI_EventSetLockScheduleToACU(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event Set Lock Schedule to ACU");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        void ucsAPI_EventAlarmFromACU(int TerminalID, int Account, int Qualifier, int Event, int Partition, int TargetID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event Alarm From ACU");
            lbxMessage.Items.Add(string.Format("   +TerminalID = {0}", TerminalID));
            lbxMessage.Items.Add(string.Format("   +Account = {0}", Account));
            lbxMessage.Items.Add(string.Format("   +Event = {0}", Event));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        void ucsAPI_EventSetSirenToTerminal(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event Set Siren To Terminal");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        void ucsAPI_EventGetSirenFromTerminal(int ClientID, int TerminalID, byte cntSiren)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event Get Siren From Terminal");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +SientCount = {0}", cntSiren));

            for (int i = 0; i < cntSiren; i++)
            {
                byte hh = 0, mm = 0, dur = 0, sun = 0, mon = 0, tue = 0, wed = 0, thu = 0, fri = 0, sat = 0, off = 0;

                terminalOption.GetSirenConfig((byte)i, ref hh, ref mm, ref dur, ref sun, ref mon, ref tue, ref wed, ref thu, ref fri, ref sat, ref off);
                lbxMessage.Items.Add(string.Format("   *Siren Info ({0})", i));
                lbxMessage.Items.Add(string.Format("    Time={0}:{1}({2}), (S:{3},M:{4},T:{5},W:{6},T:{7},F:{8},S:{9},O:{10})", hh, mm, dur, sun, mon, tue, wed, thu, fri, sat, off));
            }
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        void ucsAPI_EventSetSmartCardLayout(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event SetSmartCardLayout");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

      

        void ucsAPI_EventGetFpMinutiaeFromTerminal(int ClientID, int TerminalID, byte minType, byte minCount, byte matching, int minSize, object binMin, string strMin)
        {
            if (minSize > 0) fpMinutiae = (byte[])binMin;
            else fpMinutiae = null;

            lbxMessage.Items.Add(get_NOW() + "<--Event EventGetFpMinutiaeFromTerminal");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +minType={0}, minCount={1}, matching={2}, minSize={3}", minType, minCount, matching, minSize));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        void ucsAPI_EventGetVoipInfoFromTerminal(int ClientID, int TerminalID, string ProxyAddr, string LogonID, string LogoinPwd)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event GetVoipInfoFromTerminal");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.Items.Add(string.Format("   +ProxyAddr={0}, LogonID={1}, LogonPwd={2}", ProxyAddr, LogonID, LogoinPwd));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }
        void ucsAPI_EventSetVoipInfoToTerminal(int ClientID, int TerminalID)
        {
            lbxMessage.Items.Add(get_NOW() + "<--Event SetVoipInfoToTerminal");
            lbxMessage.Items.Add(string.Format("   +ClientID / TerminalID = {0} / {1}", ClientID, TerminalID));
            lbxMessage.Items.Add(string.Format("   +ErrorCode:{0}", this.ucsAPI.ErrorCode));
            lbxMessage.SelectedIndex = lbxMessage.Items.Count - 1;
        }

        public static void exception_log(StackTrace st, Exception ex)
        {

            //Get the first stack frame
            StackFrame frame = st.GetFrame(0);

            //Get the file name
            string fileName = frame.GetFileName();

            //Get the method name
            string methodName = frame.GetMethod().Name;

            //Get the line number from the stack frame
            int line = frame.GetFileLineNumber();

            //Get the column number
            int col = frame.GetFileColumnNumber();

            Console.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " EXCEPTION! " + fileName + "(" + methodName + ")" + line.ToString() + ":" + col.ToString() + " ==> " + ex.Message);

            log.Fatal(" EXCEPTION! " + fileName + "(" + methodName + ")" + line.ToString() + ":" + col.ToString() + " ==> " + ex.Message + "\n" + ex.Source + "\n" + ex.TargetSite + "\n" + ex.StackTrace);
            if (ex.InnerException != null)
            {
                log.Fatal(" INNER EXCEPTION! " + fileName + "(" + methodName + ")" + line.ToString() + ":" + col.ToString() + " ==> " + ex.InnerException.Message + "\n" + ex.InnerException.Source + "\n" + ex.InnerException.TargetSite + "\n" + ex.InnerException.StackTrace);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!ServerStart)
            {
                
                while (true)
                {
                    log.Info("Timer Server Start on port " + SiwonServer_PORT);
                    ucsAPI.ServerStart(9999, Convert.ToInt32(SiwonServer_PORT));
                    lbxMessage.Items.Add("-->Timer ServerStart Port " + SiwonServer_PORT);
                    lbxMessage.Items.Add("   +Server listening; Err=0x" + ucsAPI.ErrorCode.ToString("X4"));
                    if (ucsAPI.ErrorCode.ToString("X4") == "0000")
                    {
                        ServerStart = true;
                        timer2.Stop();
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ucsAPI_EventVerifyCard(5234, 0, 0, "232887237848D");
        //}

        private void button1_Click_1(object sender, EventArgs e)
        {
            while (true)
            {
                ucsAPI.ServerStart(9999, Convert.ToInt32(SiwonServer_PORT));
                lbxMessage.Items.Add("-->ServerStart Port " + SiwonServer_PORT);
                lbxMessage.Items.Add("   +Server listening; Err=0x" + ucsAPI.ErrorCode.ToString("X4"));
                if (ucsAPI.ErrorCode.ToString("X4") == "0000")
                {
                    break;
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucsAPI.ServerStop();
            lbxMessage.Items.Add("---ServerStop");
            lbxMessage.Items.Add("   +Closed; Err=0x" + ucsAPI.ErrorCode.ToString("X4"));
        }
    }
}
