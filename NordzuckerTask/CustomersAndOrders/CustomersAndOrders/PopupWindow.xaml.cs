using CustomersAndOrders.Entities;
using System.Windows;

namespace CustomersAndOrders
{
    /// <summary>
    /// Interaction logic for PopupWindow.xaml
    /// </summary>
    public partial class PopupWindow : Window
    {
        private Customer customer;

        public PopupWindow(Customer customer)
        {
            DataContext = this;
            InitializeComponent();
            this.customer = customer;
            lblCustomer.Content = "Customer: " + customer.NameAndSurname;
        }

        private void EditUserData_Click(object sender, RoutedEventArgs e)
        {
            UserData userData = new UserData(customer);
            userData.Show();
        }

        private async void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var decision = MessageBox.Show("Are you sure?", null, MessageBoxButton.YesNo);

            if(decision == MessageBoxResult.Yes)
            {
                var delete = await DatabaseConnection.DeleteCustomer(customer.ID.ToString());

                MessageBox.Show(delete, "", MessageBoxButton.OK);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}
