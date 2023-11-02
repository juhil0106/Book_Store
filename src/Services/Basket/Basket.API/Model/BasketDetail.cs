namespace Basket.API.Model
{
    public class BasketDetail
    {
        public int UserId { get; set; }
        public List<BasketItem> Items { get; set; }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                if (Items is not null && Items.Count > 0)
                {
                    foreach (var item in Items)
                    {
                        totalPrice += item.Quantity * item.Price;
                    }
                }
                return totalPrice;
            }
        }

        public BasketDetail(int userId)
        {
            UserId = userId;
        }
    }
}
