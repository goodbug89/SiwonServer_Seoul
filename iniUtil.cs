using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace UCSAPI_SiwonSRI
{
    internal class iniUtil
    {
        private string iniPath;

        public iniUtil(string path)
        {
            this.iniPath = path;
        }

        public string GetIniValue(string Section, string Key)
        {
            StringBuilder retVal = new StringBuilder(0xff);
            GetPrivateProfileString(Section, Key, "", retVal, 0xff, this.iniPath);
            return retVal.ToString();
        }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public void SetIniValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.iniPath);
        }

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}
