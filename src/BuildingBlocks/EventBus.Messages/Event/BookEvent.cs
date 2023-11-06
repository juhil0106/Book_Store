namespace EventBus.Messages.Event
{
    public class BookEvent : IntegrationBaseEvent
    {
        public List<BookQuantityEvent> BookQuantities { get; set; } = null!;
    }
}
