namespace Order.DataAccess.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string BookId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual OrderDetails Order { get; set; } = null!;
    }
}
