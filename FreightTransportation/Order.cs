using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransportation
{
   public class Order
    {
        public int OrderId { get; set; }
        public string SendingCity { get; set; }
        public string SendingDepartment { get; set; }
        public string ReceivingCity { get; set; }
        public string ReceivingDepartment { get; set; }
        public string Status { get; set; }

        public double Price { get; set; }

        public virtual Driver DriverUser { get; set; }
        public virtual Customer CustomerUser { get; set; }
    }
}
