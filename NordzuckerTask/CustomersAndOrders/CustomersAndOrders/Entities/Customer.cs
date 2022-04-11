namespace CustomersAndOrders.Entities
{
    public class Customer
    {
        public int ID { get; set; }
        public string Profile_IMG { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string NameAndSurname => string.Format("{0} {1}", Name, Surname);
    }
}
