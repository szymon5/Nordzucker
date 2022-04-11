namespace CustomersAndOrders.Entities
{
    public class Orders
    {
        public int Article_ID { get; set; }
        public string Article_IMG { get; set; }
        public string Article_Name { get; set; }
        public float Article_Price_PLN { get; set; }
        public int Article_Quantity { get; set; }

        public string Price
        {
            get => string.Format("{0:0.00} PLN", Article_Price_PLN);
            set { }
        }
        public string Summary => string.Format("{0}x{1}", Article_Quantity, Price);
    }
}
