using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioIControlSmart.Data
{
    public class DeviceEvent
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Success { get; set; }

        [Required]
        public DeviceBase Device { get; set; }

        public DateTimeOffset Timestamp { get; set; }
    }
}
