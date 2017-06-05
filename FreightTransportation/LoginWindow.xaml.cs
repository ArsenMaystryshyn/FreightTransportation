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
using System.Windows.Shapes;
using System.Data.Entity;
using FreightTransportation.Context;

namespace FreightTransportation
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UnitOfWork _unitOfWork;
        public LoginWindow()
        {
            InitializeComponent();
            Database.SetInitializer(new TransportationDBInitializer());
            _unitOfWork = new UnitOfWork();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // green code?
            //var customer = new Customer()
            //{
            //    FirstName = "Ivan",
            //    LastName = "Petrenko",
            //    Login = "vanya",
            //    //pass = 12345
            //    Password = "827ccb0eea8a706c4c34a16891f84e7b",

            //};

            //_unitOfWork.CustomerRepository.Insert(customer);
            //_unitOfWork.Save();






            var login = textBoxLogin.Text;
            var password = Encrypt.GetHash(passwordBox.Password);
            var userCustomer = _unitOfWork.CustomerRepository
                .Get(x => x.Login == login && x.Password == password)
                .FirstOrDefault();

            if (userCustomer == null)
            {
                var userDriver = _unitOfWork.DriverRepository
                 .Get(x => x.Login == login && x.Password == password)
                 .FirstOrDefault();


                if (userDriver == null)
                {
                    MessageBox.Show(this, "Invalid user name or password", "Authentication Error");

                }
                else
                {
                    //CurrentUser.Initialize(user);
                    //this.DialogResult = true;
                    DriverWindow m = new DriverWindow();
                    CurrentDriver.Initialize(userDriver);
                   // MessageBox.Show("Driver!!");
                    this.Close();
                    //m.fullName = name;
                    //m.Owner = this;
                    m.ShowDialog();



                }
            }
            else
            {
                CustomerWindow m = new CustomerWindow();
                //MessageBox.Show("User!!");
                CurrentCustomer.Initialize(userCustomer);
                this.Close();
                m.ShowDialog();
            }

        }
    }
}
