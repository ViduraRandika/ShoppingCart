using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Functions
{
    public class UserFunctions : IUser
    {
      //Create a new customer

      public async Task<int> CreateCustomer(string customerName, string customerAddress, int customerPhoneNumber, string email, string password, int authLevelId)
      {
          try
          {
              var newUser = new User
              {
                  Email = email,
                  Password = password,
                  AuthLevelId = authLevelId
              };

              var newCustomer = new Customer
              {
                  CustomerAddress = customerAddress,
                  CustomerName = customerName,
                  CustomerPhoneNumber = customerPhoneNumber,
                  User = newUser
              };

              var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

              await context.Customers.AddAsync(newCustomer);
              await context.SaveChangesAsync();

              return 200;
          }
          catch (Exception )
          {
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