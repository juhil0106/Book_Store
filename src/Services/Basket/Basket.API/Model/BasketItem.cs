namespace Basket.API.Model
{
    public class BasketItem
    {
        public string BookId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
