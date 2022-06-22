using System;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IUser
    {
        Task<int> CreateCustomer(string customerName, string customerAddress,
            string customerPhoneNumber, string email, string password, int authLevelId);

        Task<List<User>> GetAllUsers();

        Task<Cart> GetCartDetails(long userId, string status);

        Task<Cart> OpenNewCart(long userId);

        Task<bool> AddProductToCart(int productId, long cartId, int qty);

        Task<bool> RemoveProductFromCart(int productId, long cartId);

        Task<bool> PlaceOrder(int userId, long cartId, float total, DateTime dateTime);

        Task<List<CartItem>> GetCartItems(long userId, long cartId);

        public Task<bool> UpdateCartItemQty(long id, int qty);
    }
}
