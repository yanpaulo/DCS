using DesafioControlSmart.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioControlSmart.Client
{
    public static class DeviceExtensions
    {
        private static Random rng = new Random();

        public static async Task Liga(this DeviceBase device) => await Task.Delay(rng.Next(5000, 10000));

        public static async Task Desliga(this DeviceBase device) => await Task.Delay(rng.Next(5000, 10000));

        
    }
}
