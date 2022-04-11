using CustomersAndOrders.Entities;
using System;
using System.Windows;
using System.Windows.Input;

namespace CustomersAndOrders
{
    /// <summary>
    /// Interaction logic for UserData.xaml
    /// </summary>
    public partial class UserData : Window
    {
        private Customer customer;

        public UserData(Customer customer)
        {
            DataContext = this;
            InitializeComponent();
            this.customer = customer;
            windowUserData.Title = customer.NameAndSurname;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            tbName.Text = customer.Name;
            tbSurname.Text = customer.Surname;

            for (int i = 0; i < customer.Login.Length; i++) tbLogin.Text += "*";
            for (int i = 0; i < customer.Password.Length; i++) tbPassword.Text += "*";
        }

        private async void UpdateUserData_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbLogin.Text) && !string.IsNullOrWhiteSpace(tbLogin.Text) && tbLogin.Text.Length > 3 &&
               !string.IsNullOrEmpty(tbPassword.Text) && !string.IsNullOrWhiteSpace(tbPassword.Text) && tbPassword.Text.Length > 3 &&
               !string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbSurname.Text))
            {
                var result = await DatabaseConnection.UpdateCustomer(
                    customer.ID.ToString(), tbName.Text, tbSurname.Text, tbLogin.Text, tbPassword.Text);

                MessageBox.Show(result, null, MessageBoxButton.OK);
            }
            else MessageBox.Show("Login and password have to be longer than 3. Name and surname cannot be empty");
        }

        private void ImageShowLogin_MouseDown(object sender, MouseButtonEventArgs e) =>
            MessageBox.Show("Login: " + customer.Login, customer.NameAndSurname, MessageBoxButton.OK);

        private void ImageShowPassword_MouseDown(object sender, MouseButtonEventArgs e) =>
            MessageBox.Show("Password: " + customer.Password, customer.NameAndSurname, MessageBoxButton.OK);
    }
}
