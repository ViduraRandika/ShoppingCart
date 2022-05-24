using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using LogicLayer.ViewModels;

namespace LogicLayer.AdminLogic
{
    public class AdminLogic
    {
        private readonly IAdmin _admin = new AdminFunctions();

        public async Task<int> CreateNewCategory(string categoryName)
        {
            try
            {
                return await _admin.CreateCategory(categoryName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        

        

        public async Task<int> CreateNewProduct(string productName, string description, float price,string productImagePath, int categoryId)
        {
            try
            {
                return await _admin.AddNewProduct(productName, description, price, productImagePath, categoryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}