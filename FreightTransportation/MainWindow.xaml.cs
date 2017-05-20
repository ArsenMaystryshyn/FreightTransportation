using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Validation;
namespace FreightTransportation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UnitOfWork _unitOfWork;
        public MainWindow()
        {
            _unitOfWork = new UnitOfWork();
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Customer()
            {
                FirstName = "Ivan",
                LastName = "Petrenko",
                Login = "vanya",
                //pass = 12345
                Password = "827ccb0eea8a706c4c34a16891f84e7b",

              };
            _unitOfWork.CustomerRepository.Insert(customer);
            _unitOfWork.Save();
            //string password = Encrypt.GetHash("qwerty");
            //var driver = new Driver()
            //{
            //    FirstName = "Vasyl2",
            //    LastName = "Diduh",
            //    Login = "vasya",
            //    //pass = 12345

            //    Password = password,
            //    CarModel = "Renault Trafic",
            //    PhoneNumber = "+380 21 25 412"

            //};
            // _unitOfWork.DriverRepository.Delete(2);
            //_unitOfWork.DriverRepository.Insert(driver);
            //_unitOfWork.Save();

            //var order = new Order()
            //{
            //    //CustomerUser = customer,
            //    OrderId = 1,
            //    SendingCity = "Lviv",
            //    SendingDepartment = "2",
            //    ReceivingCity = "Dnipro",
            //    ReceivingDepartment = "1",
            //    Price = 100,
            //    Status="Waiting"


            //};

            //var customer = _unitOfWork.CustomerRepository.GetByID(1); 
            //order.CustomerUser = customer;
            //  order.DriverUser = driver;
            //try
            //{
            //    _unitOfWork.OrderRepository.Insert(order);
            //    _unitOfWork.Save();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //   MessageBox.Show (ex.Message);
            //}


            //var order = _unitOfWork.OrderRepository.GetByID(1);
            //var driver = _unitOfWork.DriverRepository.GetByID(1);
          //  order.DriverUser = driver;
               
        //    _unitOfWork.OrderRepository.Insert(order);
           // _unitOfWork.Save();

        }
    }
}
