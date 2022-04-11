using CustomersAndOrders.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CustomersAndOrders
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        //UserPanelViewModel UserPanelViewModel
        //{
        //    get => DataContext as UserPanelViewModel;
        //    set => DataContext = this;
        //}

        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>();
        public ObservableCollection<Orders> Orders { get; set; } = new ObservableCollection<Orders>();

        public UserPanel()
        {
            DataContext = this;
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(await DatabaseConnection.GetCustomers());

            for (int i = 0;i< customers.Count; i++) Customers.Add(customers[i]);
        }

        private void ShowCustomerOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var customer = (Customer)item.SelectedItem;

            PopupWindow popupWindow = new PopupWindow(customer);
            popupWindow.Show();
            this.IsEnabled = false;

            popupWindow.Closed += PopupWindow_Closed;
        }

        private void PopupWindow_Closed(object sender, EventArgs e) => this.IsEnabled = true;

        private async void AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrWhiteSpace(tbLogin.Text) && tbLogin.Text.Length > 3 &&
               !string.IsNullOrEmpty(tbPassword.Text) && !string.IsNullOrWhiteSpace(tbPassword.Text) && tbPassword.Text.Length > 3 &&
               !string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbSurname.Text))
            {
                var result = await DatabaseConnection.AddNewCustomer(tbName.Text, tbSurname.Text, tbLogin.Text, tbPassword.Text);

                MessageBox.Show(result, null, MessageBoxButton.OK);
            }
            else MessageBox.Show("Login and password have to be longer than 3. Name and surname cannot be empty");
        }

        private async void CustomersOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var customer = (Customer)item.SelectedItem;

            var orders = JsonConvert.DeserializeObject<List<Orders>>
                (await DatabaseConnection.GetCustomersOrders(customer.ID.ToString()));

            float totalPrice = 0.0f;

            Orders.Clear();

            for (int i = 0; i < orders.Count; i++)
            {
                Orders.Add(orders[i]);
                totalPrice += orders[i].Article_Price_PLN * orders[i].Article_Quantity;
            }

            lblTotalPrice.Content = string.Format("{0:0.00} PLN", totalPrice);
        }

        private void TotalPriceForSpecificProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ListBox)sender;
            var order = (Orders)item.SelectedItem;

            var total = string.Format("{0}x {1}, each for {2}. Total price: {3}",
                order.Article_Quantity, order.Article_Name, order.Price,
                string.Format("{0:0.00} PLN", order.Article_Price_PLN * order.Article_Quantity));

            MessageBox.Show(total, "Price summary", MessageBoxButton.OK);
        }
    }
}
