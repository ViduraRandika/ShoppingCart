using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DataAccessLayer.Interfaces
{
    public interface IUser
    {
        Task<int> CreateCustomer(string customerName, string customerAddress,
            int customerPhoneNumber, string email, string password, int authLevelId);

        Task<List<User>> GetAllUsers();
    }
}
