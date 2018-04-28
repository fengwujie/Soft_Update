using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Soft_Update
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                string[] values = args[0].Split('#');
                PublicSetting.ProductCodeExt = values[0];
                if (values.Length > 1)
                {
                    PublicSetting.ProcessNameExt = values[1];
                    if (!PublicSetting.ProcessNameExt.ToUpper().Contains(".EXE"))
                        PublicSetting.ProcessNameExt = PublicSetting.ProcessNameExt.ToUpper() + ".EXE";
                }
            }
            //Application.Run(new frmDownload());
            //Application.Run(new FormUpLoad());
            
            string strnamespace = "Soft_Update";//根据你自己的命名空间来修改
            string strfrm = ConfigurationManager.AppSettings["MainForm"].ToString();
            Form frm = (Form)Assembly.Load(strnamespace).CreateInstance(strnamespace + "." + strfrm);
            Application.Run(frm);
        }
    }
}
