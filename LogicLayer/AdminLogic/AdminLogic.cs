using System;
using System.Threading.Tasks;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;

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

        public async Task<int> CreateNewProduct(string productName, string description, float price,
            byte[] productImage, int categoryId)
        {
            try
            {
                return await _admin.AddNewProduct(productName, description, price, productImage, categoryId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}