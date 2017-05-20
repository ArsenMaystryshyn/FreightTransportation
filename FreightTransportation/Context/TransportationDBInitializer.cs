using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransportation.Context
{
   // class TransportationDBInitializer:DropCreateDatabaseIfModelChanges<TransportationContext>
    //{
   
    class TransportationDBInitializer : DropCreateDatabaseIfModelChanges<TransportationContext>
    {
        
        /// <summary>
        /// Seed method will run when the database is re-created and will re-create your test data
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(TransportationContext context)
        {
            string customerPassword = Encrypt.GetHash("12345");
            var customer = new Customer()
            {
                FirstName = "Ivan",
                LastName = "Petrenko",
                Login = "vanya",
                //pass = 12345
                Password = customerPassword,
            };

            string driverPassword = Encrypt.GetHash("qwerty");
            var driver = new Driver()
            {
                FirstName = "Jevhen",
                LastName = "Diduh",
                Login = "jenya",
                //pass = qwerty
                Password = driverPassword,
                CarModel = "Renault Trafic",
                PhoneNumber = "+380 21 25 412"

            };

            context.Customers.Add(customer);
            context.Drivers.Add(driver);
            context.SaveChanges();
        }
    }
}
