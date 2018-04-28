using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Soft_Update
{
    public class VersionFileDataContract
    {
        public string GuidNo { get; set; }

        public string ProductCode { get; set; }

        public string Version { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}
