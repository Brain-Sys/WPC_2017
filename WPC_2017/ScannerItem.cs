using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

namespace WPC_2017
{
    public class ScannerItem
    {
        public string Description { get; set; }
        public DeviceInformation ScannerHardware { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}