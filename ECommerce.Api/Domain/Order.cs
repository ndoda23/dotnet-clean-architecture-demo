namespace ECommerce.Api.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CustomerEmail { get; set; } = string.Empty;

        public List<OrderItem> Items { get; set; } = new();
        public DateTime OrderDate { get; internal set; }
    }
}
