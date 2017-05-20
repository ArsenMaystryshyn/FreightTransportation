using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransportation
{
    public class CurrentCustomer
    {
        private static Customer currentCustomer;

        public static void Initialize(Customer user)
        {
            if (currentCustomer != null)
            {
                throw new InvalidOperationException("Current user has been already specified");
            }
            currentCustomer = user;
        }

        public static void Logout()
        {
            currentCustomer = null;
        }

        public static int Id
        {
            get
            {
                return currentCustomer.CustomerId;
            }
        }

        public static string FirstName
        {
            get
            {
                return currentCustomer.FirstName;
            }
        }

        public static string LastName
        {
            get
            {
                return currentCustomer.LastName;
            }
        }

        public static string Login
        {
            get
            {
                return currentCustomer.Login;
            }
        }

        
    }
}
