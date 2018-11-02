using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace UCSAPI_SiwonSRI
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] processlist = Process.GetProcessesByName("SiwonServer");
            Process current_process = Process.GetCurrentProcess();
            //MessageBox.Show(processlist.Length.ToString() + " : " + current_process.Id);
            if (processlist.Length > 0)
            {
                for (int i = 0; i < processlist.Length; i++)
                {
                    if (processlist[i].Id != current_process.Id)
                    {
                        processlist[i].Kill();
                        System.Threading.Thread.Sleep(1000);
                        
                    }
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //bool createdNew;
            //Mutex mutex = new Mutex(true, Application.ProductName, out createdNew);

            //// check if given exe alread running or not
            //if (!createdNew)
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new MainForm());
            //}
            //else
            //{
            //    Application.EnableVisualStyles();
            //    Application.SetCompatibleTextRenderingDefault(false);
            //    Application.Run(new MainForm());
            //    //MessageBox.Show("This is already running.");
            //}
        }
    }
}
