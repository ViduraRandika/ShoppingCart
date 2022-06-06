using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Functions
{
    public class UserFunctions : IUser
    {
      //Create a new customer

      public async Task<int> CreateCustomer(string customerName, string customerAddress, string customerPhoneNumber, string email, string password, int authLevelId)
      {
          try
          {
              var newUser = new User
              {
                  Email = email,
                  Password = password,
                  AuthLevelId = authLevelId,
                  UserAddress = customerAddress,
                  UserFullName = customerName,
                  UserPhoneNumber = customerPhoneNumber
              };

              var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

              await context.Users.AddAsync(newUser);
              await context.SaveChangesAsync();

              return 200;
          }
          catch (Exception exception)
          {
              Console.WriteLine(exception);
              return 409;
          }
      }

      //Get All users

      public async Task<List<User>> GetAllUsers()
      {
          List<User> users = new List<User>();
          using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
          {
              users = await context.Users.ToListAsync();
          }

          return users;
      }

      public async Task<Cart> GetCartDetails(long userID, string status)
      {
          var cart = new Cart();
          var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
          try
          {
              cart = context.Carts.Single(c => c.UserId == userID && c.Status == status);
              return cart;
          }
          catch (Exception)
          {
              return null;
          }
      }

      public async Task<Cart> OpenNewCart(long userId)
      {
          try
          {
              var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

              var newCart = new Cart
              {
                  UserId = userId,
                  Status = "open"
              };

              await context.Carts.AddAsync(newCart);
              await context.SaveChangesAsync();

              return newCart;
          }
          catch (Exception)
          {
              return null;
          }
      }

      public async Task<bool> AddProductToCart(int productId, long cartId, int qty)
      {
          var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

          var cartItem = new CartItem();
          try
          {
              cartItem = context.CartItems.Single(c => c.CartId == cartId && c.ProductId == productId);
          }
          catch (Exception)
          {
              cartItem = null;
          }


          try
          {
              if (cartItem == null)
              {
                  var newCartItem = new CartItem
                  {
                      CartId = cartId,
                      ProductId = productId,
                      Qty = qty
                  };

                  await context.CartItems.AddAsync(newCartItem);
                  await context.SaveChangesAsync();

                  return true;
              }

              var newQty = cartItem.Qty + qty;
              cartItem.Qty = newQty;
              context.SaveChangesAsync();

              return true;
          }
          catch (Exception)
          {
              return false;
          }

      }

      public async Task<bool> UpdateCartItemQty(long id, int qty)
      {
          var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

          var cartItem = new CartItem();
          try
          {
              cartItem = context.CartItems.Single(c => c.Id == id);
          }
          catch (Exception)
          {
              cartItem = null;
          }

          try
          {
              if (cartItem == null)
              {
                  return false;
              }
              cartItem.Qty = qty;
              context.SaveChangesAsync();

              return true;
          }
          catch (Exception)
          {
              return false;
          }
      }

      public async Task<List<CartItem>> GetCartItems(long userId, long cartId)
      {
          var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

          List<CartItem> cartItems = new List<CartItem>();


          cartItems = await context.CartItems.Where(c => c.CartId == cartId).Include(i => i.Product).ToListAsync();
          return cartItems;
      }
    }
}