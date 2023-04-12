namespace ProductAPI.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public double Cost { get; set; }
        public DateTime Placed { get; set; }
        public int CustomerId { get; set; }
        public string Status { get; set; }
    }
}
