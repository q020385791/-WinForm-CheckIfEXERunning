using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _WinForm_CheckIfEXERunning
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (ProgramIsRunning(Path.GetFullPath(Application.ExecutablePath)))
            {
                MessageBox.Show("程式執行中");
                Application.Exit();
            }
            else
            {
                Application.Run(new Form1());

            }
        }
        //啟動時確認有幾個與自己相同名稱的檔案在跑
        private static bool ProgramIsRunning(string FullPath)
        {
            string FilePath = Path.GetDirectoryName(FullPath);
            string FileName = Path.GetFileNameWithoutExtension(FullPath).ToLower();
            bool isRunning = false;
            Process[] pList = Process.GetProcessesByName(FileName);
            //包括自己目前啟動 為1  若是大於1則已經有同名exe檔案在執行
            if (pList.Count() > 1)
            {
                return true;
            }
            return isRunning;
        }
    }
}
