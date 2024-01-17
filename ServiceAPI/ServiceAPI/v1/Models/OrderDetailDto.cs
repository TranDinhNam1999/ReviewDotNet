namespace ServiceAPI.v1.Models
{
    public class OrderDetailDto
    {
        public string customerName { get; set; }
        public string customerEmail { get; set; }
        public string shopName { get; set; }
        public string shopLocation { get; set; }
        public string productName { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ShopId { get; set; }
        public Guid ProductId { get; set; }
        public Guid Id { get; set; }
    }
}
