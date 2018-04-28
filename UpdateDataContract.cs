using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soft_Update
{
    public class UpdateDataContract
    {
        public string ProductCode { get; set; }

        public string LocalVersion { get; set; }

        public string VersionDate { get; set; }

        public string ServerVersion { get; set; }

        public string ProcessName { get; set; }

        public string ExeFile { get; set; }
    }
}
