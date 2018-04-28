using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Soft_Update
{
    public class PublicFunction
    {
        /// <summary>
        /// 进程是否在运行
        /// </summary>
        /// <param name="AppName"></param>
        /// <returns></returns>
        public static bool IsAppOnRunning(string AppName)
        {
            System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcesses();
            if (System.Diagnostics.Process.GetProcessesByName(AppName).Length > 0)
            { return true; }
            else
            { return false; }
        }

        /// <summary>
        /// 当前程序是否重复运行
        /// </summary>
        /// <returns></returns>
        public static bool IsAppOnRunning()
        {
            string strProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            if (System.Diagnostics.Process.GetProcessesByName(strProcessName).Length > 1)            
                return true;            
            else
                return false;
        }

        /// <summary>
        /// 结束进程
        /// </summary>
        /// <param name="ProcessName"></param>
        public static void KillProcess(string ProcessName)
        {
            try
            {
                Process[] ps = Process.GetProcesses();
                foreach (Process item in ps)
                {
                    if (item.ProcessName.ToUpper() == ProcessName.ToUpper())
                    {
                        item.Kill();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
    }
}
