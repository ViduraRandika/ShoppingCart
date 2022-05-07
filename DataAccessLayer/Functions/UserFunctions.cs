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
    }
}