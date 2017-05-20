using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransportation
{
    public class CurrentDriver
    {
        private static Driver currentDriver;

        public static void Initialize(Driver user)
        {
            if (currentDriver != null)
            {
                throw new InvalidOperationException("Current user has been already specified");
            }
            currentDriver = user;
        }

        public static int Id
        {
            get
            {
                return currentDriver.DriverId;
            }
        }

        public static void Logout()
        {
            currentDriver = null;
        }
        public static string FirstName
        {
            get
            {
                return currentDriver.FirstName;
            }
        }

        public static string LastName
        {
            get
            {
                return currentDriver.LastName;
            }
        }

        public static string Login
        {
            get
            {
                return currentDriver.Login;
            }
        }
    }
}
