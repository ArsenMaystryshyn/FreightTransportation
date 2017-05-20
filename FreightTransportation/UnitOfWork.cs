using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightTransportation.Context;
using FreightTransportation.Repositories.Abstract;
namespace FreightTransportation
{
    public class UnitOfWork : IDisposable
    {
        private TransportationContext context = new TransportationContext();
        private GenericRepository<Customer> customerRepository;
        private GenericRepository<Driver> driverRepository;
        private GenericRepository<Order> orderRepository;

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (this.customerRepository == null)
                {
                    this.customerRepository = new GenericRepository<Customer>(context);
                }
                return customerRepository;
            }
        }

        public GenericRepository<Driver> DriverRepository
        {
            get
            {

                if (this.driverRepository == null)
                {
                    this.driverRepository = new GenericRepository<Driver>(context);
                }
                return driverRepository;
            }
        }


        public GenericRepository<Order> OrderRepository
        {
            get
            {

                if (this.orderRepository == null)
                {
                    this.orderRepository = new GenericRepository<Order>(context);
                }
                return orderRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }

}
