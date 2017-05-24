using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
namespace FreightTransportation.Context
{
    public class TransportationContext:DbContext
    {
        public TransportationContext() : base("name=FreightTransportationDB")
        {
        }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
