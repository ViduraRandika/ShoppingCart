using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using LogicLayer.AuthLogic;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
    }
}
