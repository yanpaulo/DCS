﻿using DesafioControlSmart.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DesafioControlSmart.ClientWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            App.Instance.StartAsync().Wait();
        }

        protected override void OnStop()
        {
            App.Instance.StopAsync().Wait(); ;
        }
    }
}
