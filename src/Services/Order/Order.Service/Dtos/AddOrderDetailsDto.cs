namespace Order.Service.Dtos
{
    public class AddOrderDetailsDto
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Addess { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string State { get; set; } = null!;
        public string City { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string? PaymentMode { get; set; }
        public string? CardName { get; set; }
        public string? CardNumber { get; set; }
        public string? Expiration { get; set; }
        public string? Cvv { get; set; }
        public string? Upi { get; set; }
        public List<AddOrderItemsDto>? addOrderItems { get; set; }
    }
}
