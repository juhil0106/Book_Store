namespace EventBus.Messages.Event
{
    public class CheckoutOrderItem
    {
        public string BookId { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
