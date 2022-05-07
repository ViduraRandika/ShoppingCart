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
        

        public async Task<List<CategoryViewModel>> ViewCategories()
        {
            var categories = await _admin.ViewCategories();
            List<CategoryViewModel> categoryList = new List<CategoryViewModel>();
            if (categories.Count > 0)
            {
                foreach (var category in categories)
                {
                    CategoryViewModel currentCatefory = new CategoryViewModel
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName
                    };

                    categoryList.Add(currentCatefory);
                }
                return categoryList;
            }

            return null;
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