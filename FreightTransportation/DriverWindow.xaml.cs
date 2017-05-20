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

namespace FreightTransportation
{
    /// <summary>
    /// Interaction logic for DriverWindow.xaml
    /// </summary>
    public partial class DriverWindow : Window
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public DriverWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            labelWelcome.Content = "Hi, " + CurrentDriver.Login;
        }

        private void buttonSelect_Click(object sender, RoutedEventArgs e)
        {
            if (dgDriverOrders.SelectedItem == null)
            {
                MessageBox.Show("Please choose the order");
            }
            else
            {
                var orderToTake = ((Order)dgDriverOrders.SelectedItem);

                if (orderToTake.Status != null)
                {
                    MessageBox.Show("Please choose another order");
                }
                else
                {
                    var driver = _unitOfWork.DriverRepository.GetByID(CurrentDriver.Id);
                    var order = _unitOfWork.OrderRepository.GetByID(orderToTake.OrderId);
                    order.DriverUser = driver;
                    order.Status = "In progress";
                    _unitOfWork.Save();
                    Refresh();
                }
            }    
        }

        private void Refresh()
        { 
            var orders = _unitOfWork.OrderRepository.Get().ToList();
            dgDriverOrders.ItemsSource = orders; 
        }

        private void buttonDelivered_Click(object sender, RoutedEventArgs e)
        {
            var orderToTake = ((Order)dgDriverOrders.SelectedItem);

            if (orderToTake.Status != "In progress")
            {
                MessageBox.Show("You can not deliver this order!");
            }
            else
            {
                var order = _unitOfWork.OrderRepository.GetByID(orderToTake.OrderId);
                order.Status = "Delivered";
                _unitOfWork.Save();
                Refresh();
            }
        }

        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow lg = new LoginWindow();
            CurrentDriver.Logout();
            this.Close();
            lg.ShowDialog();
        }
    }
}
