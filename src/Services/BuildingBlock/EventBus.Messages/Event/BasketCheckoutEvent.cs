namespace EventBus.Messages.Event
{
    public class BasketCheckoutEvent : IntegrationBaseEvent
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string PaymentMode { get; set; } = null!;
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? Expiration { get; set; }
        public int CVV { get; set; }
        public string? UPI { get; set; }
        public List<CheckoutOrderItem> Items { get; set; }
    }
}