namespace Order.Service.Dtos
{
    public class OrderItemsDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string BookId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
