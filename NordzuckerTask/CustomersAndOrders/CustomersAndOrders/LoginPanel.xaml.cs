using System.Windows;

namespace CustomersAndOrders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginPanel : Window
    {
        public LoginPanel()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var response = await DatabaseConnection.Login(tbLogin.Text, tbPassword.Text);
            if (!response.Equals("Login failed"))
            {
                UserPanel userPanel = new UserPanel();
                userPanel.Show();
                this.Close();
            }
            else MessageBox.Show("Error", "Error", MessageBoxButton.OK);
        }
    }
}
