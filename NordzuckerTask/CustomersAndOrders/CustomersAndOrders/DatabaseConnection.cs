using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CustomersAndOrders
{
    public class DatabaseConnection
    {
        public static async Task<string> Login(string login,string password)
        {
            WebClient webClient = new WebClient();
            Uri uri = new Uri(URLAdresses.LOGIN);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Login", login);
            parameters.Add("Password", password);

            byte[] response = await webClient.UploadValuesTaskAsync(uri, parameters);
            string data = Encoding.UTF8.GetString(response);

            return data;
        }

        public static async Task<string> GetCustomers()
        {
            HttpClient httpClient = new HttpClient();
            var data = await httpClient.GetStringAsync(URLAdresses.GET_CUSTOMERS);

            return data;
        }

        public static async Task<string> GetCustomersOrders(string customerID)
        {
            WebClient webClient = new WebClient();
            Uri uri = new Uri(URLAdresses.GET_CUSTOMERS_ORDERS);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Customer_ID", customerID);

            byte[] response = await webClient.UploadValuesTaskAsync(uri, parameters);
            string data = Encoding.UTF8.GetString(response);

            return data;
        }

        public static async Task<string> DeleteCustomer(string customerID)
        {
            WebClient webClient = new WebClient();
            Uri uri = new Uri(URLAdresses.DELETE_CUSTOMER);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Customer_ID", customerID);

            byte[] response = await webClient.UploadValuesTaskAsync(uri, parameters);
            string data = Encoding.UTF8.GetString(response);

            return data;
        }

        public static async Task<string> UpdateCustomer(string customerID,string customerName,
            string customerSurname, string customerLogin, string customerPassword)
        {
            WebClient webClient = new WebClient();
            Uri uri = new Uri(URLAdresses.UPDATE_CUSTOMER);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Customer_ID", customerID);
            parameters.Add("Customer_Name", customerName);
            parameters.Add("Customer_Surname", customerSurname);
            parameters.Add("Customer_Login", customerLogin);
            parameters.Add("Customer_Password", customerPassword);

            byte[] response = await webClient.UploadValuesTaskAsync(uri, parameters);
            string data = Encoding.UTF8.GetString(response);

            return data;
        }

        public static async Task<string> AddNewCustomer(string customerName,
            string customerSurname, string customerLogin, string customerPassword)
        {
            WebClient webClient = new WebClient();
            Uri uri = new Uri(URLAdresses.ADD_NEW__CUSTOMER);
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("Customer_Name", customerName);
            parameters.Add("Customer_Surname", customerSurname);
            parameters.Add("Customer_Login", customerLogin);
            parameters.Add("Customer_Password", customerPassword);

            byte[] response = await webClient.UploadValuesTaskAsync(uri, parameters);
            string data = Encoding.UTF8.GetString(response);

            return data;
        }
    }
}
