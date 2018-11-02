#region 기존 작업했던 코드
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//using UNIONCOMM.SDK.UCBioBSP;

//namespace UCSAPI_DemoCSharp
//{
//    public partial class SetUserInfoForm : Form
//    {
//        UCSAPI_DemoCSharp.WinAPI.ucsapi_user_data _userData;
//        UCSAPI_DemoCSharp.WinAPI.ucsapi_user_property _property;
//        UCSAPI_DemoCSharp.WinAPI.ucbioapi_export_data _exportData;
//        UCBioAPI.Type.HFIR m_hEnrolledFIR;
//        UCBioAPI m_UCBioAPI;

//        int _terminalID;
//        short m_OpenedDeviceID;

//        public SetUserInfoForm(int terminalID, UNIONCOMM.SDK.UCBioBSP.UCBioAPI m_UCBioAPI)
//        {
//            InitializeComponent();

//            m_OpenedDeviceID = UCBioAPI.Type.DEVICE_ID.NONE;
//            this._terminalID = terminalID;
//            this.m_UCBioAPI = m_UCBioAPI;
//        }

//        public UCSAPI_DemoCSharp.WinAPI.ucsapi_user_data UserData
//        {
//            get
//            {
//                //if (null != userData)
//                return _userData;
//            }
//        }

//        private void SetUserInfoForm_Load(object sender, EventArgs e)
//        {
//            ChangeAccessAuthorityGroupEnable();
//            _userData = new WinAPI.ucsapi_user_data();
//            _property = new WinAPI.ucsapi_user_property();
//        }

//        private void chkAccessAuthority_CheckedChanged(object sender, EventArgs e)
//        {
//            ChangeAccessAuthorityGroupEnable();
//        }

//        private void ChangeAccessAuthorityGroupEnable()
//        {
//            if (chkAccessAuthority.Checked)
//            {
//                label4.Enabled = true;
//                label5.Enabled = true;
//                label6.Enabled = true;
//                label7.Enabled = true;
//                txtGroupCode.Enabled = true;
//                cmbDateType.Enabled = true;
//                dtpStartDate.Enabled = true;
//                dtpEndDate.Enabled = true;
//            }
//            else
//            {
//                label4.Enabled = false;
//                label5.Enabled = false;
//                label6.Enabled = false;
//                label7.Enabled = false;
//                txtGroupCode.Enabled = false;
//                cmbDateType.Enabled = false;
//                dtpStartDate.Enabled = false;
//                dtpEndDate.Enabled = false;
//            }
//        }



//        private void btnOk_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtUserID.Text))
//            {
//                MessageBox.Show("Please input the UserID");
//                return;
//            }

//            _userData.UserInfo.UserID = Convert.ToUInt32(txtUserID.Text);

//            if (txtName.Text.Length > 0)
//            {
//                UCSAPI_DemoCSharp.WinAPI.ucsapi_data userName = new WinAPI.ucsapi_data();
//                userName.Length =(uint) txtName.Text.Length;
//                userName.Data = new char[txtName.Text.Length];
//                userName.Data = txtName.Text;
//                _userData.UserInfo.UserName = userName;
//            }
//            if (txtUniqueID.Text.Length > 0)
//            {
//                UCSAPI_DemoCSharp.WinAPI.ucsapi_data uniqueID = new WinAPI.ucsapi_data();
//                uniqueID.Length = (uint)txtUniqueID.Text.Length;
//                uniqueID.Data = new char[txtUniqueID.Text.Length];
//                uniqueID.Data = txtUniqueID.Text;
//                _userData.UserInfo.UniqueID = uniqueID;
//            }
//            _userData.UserInfo.Property = _property;
//            if (chkAccessAuthority.Checked)
//            {
//                UCSAPI_DemoCSharp.WinAPI.ucsapi_access_authority authority = new WinAPI.ucsapi_access_authority();
//                if (txtGroupCode.Text.Length > (int)UCSAPI_DemoCSharp.WinAPI.UCSAPI_DATA_SIZE.UCSAPI_DATA_SIZE_CODE4)
//                {
//                    UCSAPI_DemoCSharp.WinAPI.ucsapi_data accessGroup = new WinAPI.ucsapi_data();
//                    accessGroup.Length = (uint)txtGroupCode.Text.Length;
//                    accessGroup.Data = new char[accessGroup.Length];
//                    accessGroup.Data = txtGroupCode.Text;
//                    authority.AccessGroup = accessGroup;
//                }

//                switch (cmbDateType.SelectedIndex)
//                {
//                    case 1:
//                        authority.AccessDateType =UCSAPI_DemoCSharp.WinAPI.UCSAPI_ACCESS_DATE_TYPE.UCSAPI_DATE_TYPE_NOT_USE;
//                        break;
//                    case 2:
//                        authority.AccessDateType = UCSAPI_DemoCSharp.WinAPI.UCSAPI_ACCESS_DATE_TYPE.UCSAPI_DATE_TYPE_ALLOWED;
//                        break;
//                    case 3:
//                        authority.AccessDateType =UCSAPI_DemoCSharp.WinAPI.UCSAPI_ACCESS_DATE_TYPE.UCSAPI_DATE_TYPE_RESTRICTION;
//                        break;
//                }

//                if (authority.AccessDateType != UCSAPI_DemoCSharp.WinAPI.UCSAPI_ACCESS_DATE_TYPE.UCSAPI_DATE_TYPE_NOT_USE)
//                {
//                    UCSAPI_DemoCSharp.WinAPI.ucsapi_access_date accessDate = new WinAPI.ucsapi_access_date();
//                    accessDate.StartDate.Year = Convert.ToSByte(dtpStartDate.Value.Year);
//                    accessDate.StartDate.Month = Convert.ToByte(dtpStartDate.Value.Month);
//                    accessDate.StartDate.Day = Convert.ToByte(dtpStartDate.Value.Day);
//                    accessDate.EndDate.Year = Convert.ToSByte(dtpStartDate.Value.Year);
//                    accessDate.EndDate.Month = Convert.ToByte(dtpStartDate.Value.Month);
//                    accessDate.EndDate.Day = Convert.ToByte(dtpStartDate.Value.Day);

//                    authority.AccessDate = accessDate;
//                }

//                _userData.UserInfo.AccessAuthority = authority;
//            }

//            UCSAPI_DemoCSharp.WinAPI.ucsapi_auth_data authData = new WinAPI.ucsapi_auth_data();
//            if (_property.Password == 1)
//            {
//                if (txtPassword.Text.Length > 0)
//                {
//                    UCSAPI_DemoCSharp.WinAPI.ucsapi_data password = new WinAPI.ucsapi_data();
//                    password.Length = (uint)txtPassword.Text.Length;
//                    password.Data = new char[password.Length];
//                    authData.Password = password;
//                }
//            }
//            if (_property.Card == 1)
//            {
//                if (txtRFID.Text.Length > 0)
//                {
//                    UCSAPI_DemoCSharp.WinAPI.ucsapi_card_data cardData = new WinAPI.ucsapi_card_data();
//                    cardData.CardNum = 1; // just test code
//                    UCSAPI_DemoCSharp.WinAPI.ucsapi_data rfid = new WinAPI.ucsapi_data();
//                    rfid.Length = (uint)txtRFID.Text.Length;
//                    rfid.Data = new char[rfid.Length];
//                    rfid.Data = txtRFID.Text;
//                    cardData.RFID = rfid;
//                }
//            }
//            if (_property.Finger == 1)
//            {
//                if (this._exportData.FingerNum > 0)
//                {
//                    UCSAPI_DemoCSharp.WinAPI.ucsapi_finger_data fingerData = new WinAPI.ucsapi_finger_data();
//                    fingerData.SecurityLevel = Convert.ToInt32(cmbSecuLevel.Text);
//                    fingerData.IsCheckSimilarFinger = false;
//                    fingerData.ExportData = this._exportData;
//                    authData.Finger = fingerData;
//                }
//            }
//            this._userData.AuthData = authData;
//        }

//        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
//        {
//            // true:1 false:0
//            _property.Admin = Convert.ToByte(chkAdmin.Checked);
//        }

//        private void chkIdentify_CheckedChanged(object sender, EventArgs e)
//        {
//            _property.Identify = Convert.ToByte(chkIdentify.Checked);
//        }

//        private void chkAndOperation_CheckedChanged(object sender, EventArgs e)
//        {
//            _property.Operation = Convert.ToByte(chkAndOperation.Checked);
//        }

//        private void chkCardID_CheckedChanged(object sender, EventArgs e)
//        {
//            _property.CardID = Convert.ToByte(chkCardID.Checked);
//        }

//        private void chkCard_CheckedChanged(object sender, EventArgs e)
//        {
//            _property.Card = Convert.ToByte(chkCard.Checked);
//            if (chkCard.Checked)
//                groupRFID.Enabled = true;
//            else
//                groupRFID.Enabled = false;
//        }

//        private void chkPassword_CheckedChanged(object sender, EventArgs e)
//        {
//            _property.Password = Convert.ToByte(chkPassword.Checked);
//            if (chkPassword.Checked)
//                groupPassword.Enabled = true;
//            else
//                groupPassword.Enabled = false;
//        }

//        private void chkFPCard_CheckedChanged(object sender, EventArgs e)
//        {
//            if (chkFPCard.Checked)
//                groupFingerPrint.Enabled = true;
//            else
//                groupFingerPrint.Enabled = false;
//        }

//        private void chkFingerprint_CheckedChanged(object sender, EventArgs e)
//        {
//            if (chkFingerprint.Checked)
//                groupFingerPrint.Enabled = true;
//            else
//                groupFingerPrint.Enabled = false;

//        }

//        private void btnEnroll_Click(object sender, EventArgs e)
//        {
//            short iDeviceID = UCBioAPI.Type.DEVICE_ID.AUTO;
//            UNIONCOMM.SDK.UCBioBSP.UCBioAPI.Export.EXPORT_DATA m_pExportData;
//            uint ret = m_UCBioAPI.OpenDevice(iDeviceID);
//            if (ret == UCBioAPI.Error.NONE)
//            {
//                UCBioAPI.Type.HFIR hNewFIR;
//                ret = m_UCBioAPI.Enroll(ref m_hEnrolledFIR, out hNewFIR, null, UCBioAPI.Type.TIMEOUT.DEFAULT, null, null);
//                if (ret == UCBioAPI.Error.NONE)
//                {

//                    UCBioAPI.Export export = new UCBioAPI.Export(m_UCBioAPI);
//                    ret = export.FIRToTemplate(m_hEnrolledFIR, out m_pExportData, UNIONCOMM.SDK.UCBioBSP.UCBioAPI.Type.TEMPLATE_TYPE.SIZE400);

//                    if (ret == UCBioAPI.Error.NONE)
//                    {
//                        m_hEnrolledFIR = hNewFIR;
//                    }
//                }
//            }
//            ret = m_UCBioAPI.CloseDevice(m_OpenedDeviceID);
//        }

//        private void btnEnrollFromTerminal_Click(object sender, EventArgs e)
//        {
//            UNIONCOMM.SDK.UCBioBSP.UCBioAPI.Export.EXPORT_DATA m_pExportData;
//            uint ret = WinAPI.UCSAPI_EnrollFromTerminal(0, this._terminalID, out m_pExportData);
//            if (ret == UCBioAPI.Error.NONE)
//            {
//                UCBioAPI.Type.HFIR hNewFIR;
//                UNIONCOMM.SDK.UCBioBSP.UCBioAPI.Export export = new UCBioAPI.Export(m_UCBioAPI);
//               ret= export.ImportDataToFIR(m_pExportData, UCBioAPI.Type.FIR_PURPOSE.ENROLL,out hNewFIR);
//               if (ret == UCBioAPI.Error.NONE)
//               {
//                   m_pExportData = new UCBioAPI.Export.EXPORT_DATA();
//                   ret = export.FIRToTemplate(m_hEnrolledFIR, out m_pExportData, UNIONCOMM.SDK.UCBioBSP.UCBioAPI.Type.TEMPLATE_TYPE.SIZE400);
//                   if (ret != UCBioAPI.Error.NONE)
//                   {
//                       MessageBox.Show("FIRTOTemplete is failed!");
//                   }
//               }
//            }
//        }
//    }
//}
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using UCSAPICOMLib;
using UCBioBSPCOMLib;

namespace UCSAPI_SiwonSRI
{
    public partial class SetUserInfoForm : Form
    {
        MainForm _mainFrm;
        UserInfo Info;


        public SetUserInfoForm(MainForm frm)
        {
            InitializeComponent();
            _mainFrm = frm;
        }

        public UserInfo userInfo { get { return Info; } }

        private void SetUserInfoForm_Load(object sender, EventArgs e)
        {
            Info = new UserInfo();

            chkAccessAuthority.Checked = false;
            ChangeAccessAuthorityGroupEnable();
        }

        private void chkAccessAuthority_CheckedChanged(object sender, EventArgs e)
        {
            ChangeAccessAuthorityGroupEnable();
        }

        private void ChangeAccessAuthorityGroupEnable()
        {
            if (chkAccessAuthority.Checked)
            {
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                txtGroupCode.Enabled = true;
                cmbDateType.Enabled = true;
                dtpStartDate.Enabled = true;
                dtpEndDate.Enabled = true;
            }
            else
            {
                label4.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                label7.Enabled = false;
                txtGroupCode.Enabled = false;
                cmbDateType.Enabled = false;
                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
            }
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserID.Text))
            {
                _mainFrm.userID = txtUserID.Text;
            }
            userInfo.basicInfo = new UserInfo.BasicInfo();
            userInfo.basicInfo.userID = txtUserID.Text;
            userInfo.basicInfo.uniqueID = txtUniqueID.Text;
            userInfo.basicInfo.name = txtName.Text;

            userInfo.properties = new UserInfo.Properties();
            userInfo.properties.isAdmin = chkAdmin.Checked;
            userInfo.properties.isIdentify = chkIdentify.Checked;
            userInfo.properties.isAndOperation = chkAndOperation.Checked;
            userInfo.properties.isCardID = chkCardID.Checked;
            userInfo.properties.isCard = chkCard.Checked;
            userInfo.properties.isPassword = chkPassword.Checked;
            userInfo.properties.isFPCard = chkFPCard.Checked;
            userInfo.properties.isFingerprint = chkFingerprint.Checked;

            if (chkAccessAuthority.Checked)
            {
                userInfo.accessAuthority = new UserInfo.AccessAuthority();
                userInfo.accessAuthority.groupCode = txtGroupCode.Text;
                userInfo.accessAuthority.startDate = dtpStartDate.Value;
                userInfo.accessAuthority.endtDate = dtpEndDate.Value;
            }

            userInfo.rfid = new UserInfo.RFID();
            userInfo.rfid.rfid = txtRFID.Text;
            userInfo.password = new UserInfo.Password();
            userInfo.password.password = txtPassword.Text;
            userInfo.fingerPrint = new UserInfo.FingerPrint();
            userInfo.fingerPrint.securityLevel = cmbSecuLevel.SelectedIndex;
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            // true:1 false:0
        }

        private void chkIdentify_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkAndOperation_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkCardID_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkCard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCard.Checked)
                groupRFID.Enabled = true;
            else
                groupRFID.Enabled = false;

        }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPassword.Checked)
                groupPassword.Enabled = true;
            else
                groupPassword.Enabled = false;

        }

        private void chkFPCard_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFPCard.Checked)
                groupFingerPrint.Enabled = true;
            else
                if (!chkFingerprint.Checked)
                    groupFingerPrint.Enabled = false;
        }

        private void chkFingerprint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFingerprint.Checked)
                groupFingerPrint.Enabled = true;
            else
                if (!chkFPCard.Checked)
                    groupFingerPrint.Enabled = false;

        }

        private void btnEnroll_Click(object sender, EventArgs e)
        {
            _mainFrm.device.Open(0xff);
            if (_mainFrm.ucBioBSP.ErrorCode == 0)
            {
                _mainFrm.extraction.Enroll("1004", _mainFrm.szTextEnrolledFIR);
                if (_mainFrm.ucBioBSP.ErrorCode == 0)
                    _mainFrm.szTextEnrolledFIR = _mainFrm.extraction.TextFIR;
            }
            _mainFrm.device.Close(0xff);
        }

        private void btnEnrollFromTerminal_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] biFPData1;
                byte[] biFPData2;
                long nFPDataSize1;
                long nFPDataSize2;
                long nFPDataCount;
                long nTemplateIndex;
                bool bInitialize;
                long nTemplateSize;
                long nPurpose;

                nTemplateIndex = 0;
                bInitialize = false;
                nTemplateSize = 400;
                nPurpose = 3;

                _mainFrm.ucsAPI.EnrollFromTerminal(0, Convert.ToInt32(_mainFrm.terminalID));
                if (_mainFrm.ucsAPI.ErrorCode == 0)
                {
                    nFPDataCount = _mainFrm.ucsAPI.TotalFingerCount;

                    for (int i = 0; i < nFPDataCount - 1; i++)
                    {
                        int nFingerID = _mainFrm.ucsAPI.get_FingerID(i);
                        nFPDataSize1 = _mainFrm.ucsAPI.get_FPSampleDataLength(nFingerID, (int)nTemplateIndex);
                        biFPData1 = _mainFrm.ucsAPI.get_FPSampleData(nFingerID, (int)nTemplateIndex) as byte[];
                        nFPDataSize2 = _mainFrm.ucsAPI.get_FPSampleDataLength(nFingerID, (int)nTemplateIndex + 1);
                        biFPData2 = _mainFrm.ucsAPI.get_FPSampleData(nFingerID, (int)nTemplateIndex + 1) as byte[];
                        if (i == 0)
                            bInitialize = true;
                        else
                            bInitialize = false;
                        _mainFrm.fpData.Import(Convert.ToInt32(bInitialize), nFingerID, (int)nPurpose, (int)_mainFrm.nTemplateType400, (int)nTemplateSize, biFPData1, biFPData2);
                    }

                    _mainFrm.binaryEnrolledFIR = this._mainFrm.fpData.FIR as byte[];
                    _mainFrm.szTextEnrolledFIR = _mainFrm.fpData.TextFIR;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public class UserInfo
    {
        public BasicInfo basicInfo { get; set; }
        public Properties properties { get; set; }
        public AccessAuthority accessAuthority { get; set; }
        public RFID rfid { get; set; }
        public Password password { get; set; }
        public FingerPrint fingerPrint { get; set; }

        public class BasicInfo
        {
            public string userID { get; set; }
            public string uniqueID { get; set; }
            public string name { get; set; }
        }
        public class Properties
        {
            public bool isAdmin { get; set; }
            public bool isIdentify { get; set; }
            public bool isAndOperation { get; set; }
            public bool isCard { get; set; }
            public bool isCardID { get; set; }
            public bool isPassword { get; set; }
            public bool isFPCard { get; set; }
            public bool isFingerprint { get; set; }
        }
        public class AccessAuthority
        {
            public string groupCode { get; set; }
            public string dateType { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endtDate { get; set; }
        }
        public class RFID
        {
            public string rfid { get; set; }
        }
        public class Password
        {
            public string password { get; set; }
        }
        public class FingerPrint
        {
            public int securityLevel { get; set; }
        }
    }
}
