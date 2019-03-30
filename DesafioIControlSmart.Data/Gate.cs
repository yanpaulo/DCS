using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioIControlSmart.Data
{
    public class Gate : DeviceBase
    {
        public GateState State { get; set; }
    }

    public enum GateState
    {
        Closed,
        Open
    }
}
