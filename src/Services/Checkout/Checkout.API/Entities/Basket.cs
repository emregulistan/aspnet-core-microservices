namespace Checkout.API.Entities
{
    public class Basket
    {
        public string UserName { get; set; }
        public string Seller { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
        public Basket()
        {

        }

        public Basket(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price;
                }
                return totalprice;
            }
        }
    }
}
