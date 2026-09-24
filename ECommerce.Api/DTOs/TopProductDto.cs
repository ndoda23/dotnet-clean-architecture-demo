namespace ECommerce.Api.DTOs
{
    public class TopProductDto
    {
        public int ProductId { get; set; }
        public int TotalQuantitySold { get; set; }

        public decimal TotalRevenue { get; set; }

    }
}
