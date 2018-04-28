using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Soft_Update
{
    public class PublicSetting
    {
        public static string ProductCodeExt = "";
        public static string ProcessNameExt = "";

        public const string Pa = "Mi9l/+7Zujhy12se6Yjy111B";
        public const string Pb = "jp2015SD/9i=";
        public static String GetParameterA()
        {
            string result = "";
            try
            {
                Soft_Update.Encrypt ecy = new Soft_Update.Encrypt(Pa, Pb);
                result = ecy.DecryptString(ConfigurationManager.AppSettings["License"].ToString());
            }
            catch (Exception ex)
            { }
            return result;
        }
    }
}
