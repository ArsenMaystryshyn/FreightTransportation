using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// remove unused usings

namespace FreightTransportation
{
    public class Customer
    {
        
        public int CustomerId { get; set; }

        
        public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
       
        public string Login { get; set; }

        
        public string Password { get; set; }


        public virtual List<Order> CustomerOrders { get; set; }

    }
}
