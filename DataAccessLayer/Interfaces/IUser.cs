using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
