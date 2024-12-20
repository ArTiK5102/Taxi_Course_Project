using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taxi.Logging;

namespace Taxi.Models
{
    class SoccerContext: DbContext
    {
        public SoccerContext() : base("DefaultConnection")
        {
            this.Database.Log = Logger.Log;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        
    }
}
