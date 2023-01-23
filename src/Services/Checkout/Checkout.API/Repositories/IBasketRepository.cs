using Checkout.API.Entities;

namespace Checkout.API.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasket(string userName);
        Task<Basket> UpdateBasket(Basket basket);
        Task DeleteBasket(string userName);
    }
}
