using System;
using System.Collections.Generic;
using System.Text;
using DesafioControlSmart.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DesafioControlSmart.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }

        public DbSet<Gate> Gates { get; set; }

        public DbSet<DeviceBase> Devices { get; set; }

        public DbSet<DeviceEvent> DeviceEvents { get; set; }

    }
}
