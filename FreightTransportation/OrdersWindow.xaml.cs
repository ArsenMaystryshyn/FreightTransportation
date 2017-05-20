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
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        public OrdersWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomerOrders.SelectedItem == null)
            {
                MessageBox.Show("Please choose the order");
            }
            else
            {
                var orderIdToDelete = ((Order)dgCustomerOrders.SelectedItem).OrderId;
               
               _unitOfWork.OrderRepository.Delete(orderIdToDelete);
                _unitOfWork.Save();
               
                Refresh();
            }

        }


        private void Refresh()
        {
            var orders = _unitOfWork.OrderRepository.Get().Where(x=>x.CustomerUser.Login==CurrentCustomer.Login).ToList();
            dgCustomerOrders.ItemsSource = orders; 
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
