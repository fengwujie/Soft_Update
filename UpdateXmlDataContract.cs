using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soft_Update
{
    public class UpdateXmlDataContract
    {
        public string ProductCode { get; set; }

        public int LocalVersion { get; set; }

        public string LocalVersionText { get; set; }

        public string VersionDate { get; set; }

        public int ServerVersion { get; set; }
        public string ServerVersionText { get; set; }

        public string ProcessName { get; set; }

        public string ExeFile { get; set; }
    }
}
