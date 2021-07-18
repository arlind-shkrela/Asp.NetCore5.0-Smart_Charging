using Microsoft.EntityFrameworkCore;
using Smart_ChargingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart_ChargingApi.Data
{
    public class Smart_Charging_Context : DbContext
    {
        public Smart_Charging_Context(DbContextOptions  options) : base(options)
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Connector> Connectors { get; set; }
        public DbSet<ChargeStation> ChargeStations { get; set; }


    }
}
