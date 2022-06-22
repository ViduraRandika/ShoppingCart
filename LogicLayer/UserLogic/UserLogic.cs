using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using LogicLayer.AuthLogic;
using LogicLayer.ViewModels;

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

        public async Task<bool> UpdateCarteItemQty(long id, int qty)
        {
            return await _user.UpdateCartItemQty(id, qty);
        }

        public async Task<List<CartItemsViewModel>> GetCartItems(long userID, string status)
        {
            var cart = await _user.GetCartDetails(userID, status);
            if (cart != null)
            {
                var cartId = cart.CartId;
                var cartItems = await _user.GetCartItems(userID, cartId);

                List<CartItemsViewModel> cartItemsList = new List<CartItemsViewModel>();

                if (cartItems.Count > 0)
                {
                    foreach (var items in cartItems)
                    {
                        CartItemsViewModel currentItem = new CartItemsViewModel
                        {
                            Id = items.Id,
                            CartId = items.CartId,
                            ProductName = items.Product.ProductName,
                            Price = items.Product.Price,
                            ProductId = items.Product.ProductId,
                            Qty = items.Qty
                        };

                        cartItemsList.Add(currentItem);
                    }

                    return cartItemsList;
                }
                return null;
            }

            return null;
        }

        public async Task<List<CartItemsViewModel>> GetCartItemsByCartId(long userID, long cartId)
        {
            var cartItems = await _user.GetCartItems(userID, cartId);

            List<CartItemsViewModel> cartItemsList = new List<CartItemsViewModel>();

            if (cartItems.Count > 0)
            {
                foreach (var items in cartItems)
                {
                    CartItemsViewModel currentItem = new CartItemsViewModel
                    {
                        Id = items.Id,
                        CartId = items.CartId,
                        ProductName = items.Product.ProductName,
                        Price = items.Product.Price,
                        ProductId = items.Product.ProductId,
                        Qty = items.Qty
                    };

                    cartItemsList.Add(currentItem);
                }

                return cartItemsList;
            }
            return null;
        }

        public async Task<bool> RemoveProductFromCart(int productId, long userID)
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

            var result = await _user.RemoveProductFromCart(productId, cartId);

            if (result)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> PlaceOrder(int userID, long total)
        {
            var cart = await _user.GetCartDetails(userID, "open");

            if (cart == null)
            {
                return false;
            }

            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            long cartId = cart.CartId;
            var result = await _user.PlaceOrder(userID, cartId, total, foo);

            if (result)
            {
                return true;
            }

            return false;
        }

        public async Task<List<OrderListViewModel>> GetOrderList(long userID)
        {

            var orders = await _user.GetOrders(userID);
            List<OrderListViewModel> ordersList = new List<OrderListViewModel>();

            if (orders.Count > 0)
            {
                foreach (var items in orders)
                {
                    OrderListViewModel currentItem = new OrderListViewModel()
                    {
                        OrderId = items.OrderId,
                        CustomerId = items.CustomerId,
                        GrandTotal = items.GrandTotal,
                        CartId = items.CartId,
                        Status = items.Status,
                        OrdereDateAndTime = items.OrdereDateAndTime
                    };

                    ordersList.Add(currentItem);
                }

                return ordersList;
            }

            return null;
        }

        public async Task<ViewBillModel> GetBill(long orderId, long userId)
        {
            var billDetails = await _user.GetBill(orderId, userId);

            if (billDetails != null)
            {
                ViewBillModel viewBill = new ViewBillModel
                {
                    OrderId = billDetails.OrderId,
                    GrandTotal = billDetails.GrandTotal,
                    OrdereDateAndTime = billDetails.OrdereDateAndTime,
                    CartId = billDetails.CartId
                };

                return viewBill;
            }

            return null;
        }
    }
}
