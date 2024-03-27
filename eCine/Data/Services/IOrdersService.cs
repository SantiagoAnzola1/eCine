using eCine.Models;

namespace eCine.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItems> items, string userId, string userEmailAdress);

        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
