namespace EventBus.Messages.Event
{
    public class BookQuantityEvent 
    {
        public string BookId { get; set; } = null!; 
        public int Quantity { get; set; }
    }
}
