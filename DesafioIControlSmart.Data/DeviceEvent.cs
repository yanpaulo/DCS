using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioIControlSmart.Data
{
    public class DeviceEvent
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public bool Success { get; set; }

        public DeviceBase Device { get; set; }
    }
}
