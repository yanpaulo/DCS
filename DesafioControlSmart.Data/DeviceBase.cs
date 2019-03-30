using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioControlSmart.Data
{
    public class DeviceBase
    {
        public int Id { get; set; }

        [Required]
        public string IP { get; set; }

        [Required]
        public string MAC { get; set; }

        public DeviceStatus Status { get; set; }
    }

    public enum DeviceStatus
    {
        Off,
        On
    }
}
