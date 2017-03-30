using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZIF_data_recovery
{
    public class FileBinary
    {
        public byte[] binary { get; set; }

        public FileBinary(byte[] bytes)
        {
            binary = bytes;
        }
    }
}
