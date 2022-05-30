using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using LogicLayer.AuthLogic;

namespace LogicLayer.UserLogic
{
    public class UserLogic
    {
        private readonly IUser _user = new UserFunctions();

        // add a new user
        public async Task<int> CreateNewUser(string customerName, string customerAddress, string customerPhoneNumber, string email, string password)
        {
            try
            {
                var passwordHash = new PasswordHash();
                var hashedPassword = passwordHash.HashPassword(password, null, false);

                const int authLevelId = 2;
                var result = await _user.CreateCustomer(customerName, customerAddress, customerPhoneNumber, email,hashedPassword, authLevelId);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Get all users
        public async Task<List<User>> GetAllUsers()
        {
            var logins = await _user.GetAllUsers();
            Console.Write(logins);
            return logins;
        }
        public async Task<bool> AddProductToCart(int productId, long userID, int qty)
        {
            var cart = await _user.GetCartDetails(userID, "open");
            long cartId;
            if (cart == null)
            {
                var res = await _user.OpenNewCart(userID);
                if (res == null)
                {
                    return false;
                }

                cartId = res.CartId;
            }
            else
            {
                cartId = cart.CartId;
            }

            

            var result = await _user.AddProductToCart(productId, cartId, qty);

            if (result)
            {
                return true;
            }


            return false;
        }
        
    }
}
