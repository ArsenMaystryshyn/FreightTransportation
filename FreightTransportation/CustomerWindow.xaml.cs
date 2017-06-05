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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        private double _price;
        public CustomerWindow()
        {
            InitializeComponent();
            SetComboBoxes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            labelWelcome.Content = "Hi, " + CurrentCustomer.Login;
        }
        private void SetComboBoxes()
        {
            // should be got from database
            comboBoxSendingCity.Items.Add("Lviv");
            comboBoxSendingCity.Items.Add("Kyiv");
            comboBoxSendingCity.Items.Add("Dnipro");

            comboBoxRecievingCity.Items.Add("Lviv");
            comboBoxRecievingCity.Items.Add("Kyiv");
            comboBoxRecievingCity.Items.Add("Dnipro");

            comboBoxPostDepartment.Items.Add("1");
            comboBoxPostDepartment.Items.Add("2");
            comboBoxPostDepartment.Items.Add("3");


            comboBox1RecievingPost.Items.Add("1");
            comboBox1RecievingPost.Items.Add("2");
            comboBox1RecievingPost.Items.Add("3");
        }

        private void buttonCalculatePrice_Click(object sender, RoutedEventArgs e)
        {
            // extract some logic to separate methods
            _price = 0;
            if(comboBoxSendingCity.SelectedItem != null && comboBoxPostDepartment.SelectedItem != null && comboBoxRecievingCity.SelectedItem != null && comboBox1RecievingPost.SelectedItem != null)
            {
                string sendingCity = comboBoxSendingCity.SelectedItem.ToString();
                string sendingDep = comboBoxPostDepartment.SelectedItem.ToString();
                string recievingCity = comboBoxRecievingCity.SelectedItem.ToString();
                string recievingDep = comboBox1RecievingPost.SelectedItem.ToString();
                if (comboBoxSendingCity.SelectedItem == comboBoxRecievingCity.SelectedItem)
                {
                    _price += 100;
                }
                else
                {
                    _price += 200;
                }
                if (checkBox.IsChecked==true)
                {
                    _price += 50;
                }

                OrderWindow o = new OrderWindow();
                o.price = _price;
                o.Owner = this;
                o.ShowDialog();

                if (o.confirm)
                {
                    var customer = _unitOfWork.CustomerRepository.GetByID(CurrentCustomer.Id);
                    var order = new Order()
                    {
                        CustomerUser = customer,
                        SendingCity = sendingCity,
                        SendingDepartment = sendingDep,
                        ReceivingCity = recievingCity,
                        ReceivingDepartment = recievingDep,
                        Price = _price

                    };

                    _unitOfWork.OrderRepository.Insert(order);
                    _unitOfWork.Save();
                    MessageBox.Show("Order is created successfully and added to your orders list");
                }
            }
            else
            {
                MessageBox.Show("Please select all positions");
            }
        }
        
        private void buttonLogOut_Click(object sender, RoutedEventArgs e)
        {
            // lg - bad name
            LoginWindow lg = new LoginWindow();
            CurrentCustomer.Logout();
            // why this?
            this.Close();
            lg.ShowDialog();
        }
        
        private void buttonShowOrders_Click(object sender, RoutedEventArgs e)
        {
            int orderCount = _unitOfWork.OrderRepository.Get().Count();
            if (orderCount == 0)
            {
                MessageBox.Show("There are no orders yet");
            }
            else
            {
                OrdersWindow ow = new OrdersWindow();
                ow.ShowDialog();
            }
        }
    }
}
