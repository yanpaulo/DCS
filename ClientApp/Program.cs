using DesafioIControlSmart.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIControlSmart.ClientApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var app = App.Instance;
            await app.StartAsync();
            Console.ReadKey();
        }
    }
}
