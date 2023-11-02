namespace Discount.GRPC.Model
{
    public class BookDiscount
    {
        public int Id { get; set; }
        public string BookId { get; set; } = null!;
        public int Discount { get; set; }
    }
}