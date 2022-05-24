using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.DataContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Functions
{
    public class AdminFunctions:IAdmin
    {
        public async Task<int> CreateCategory(string categoryName)
        {
            try
            {
                var newCategory = new Category
                {
                    CategoryName = categoryName
                };

                var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

                await context.Categories.AddAsync(newCategory);
                await context.SaveChangesAsync();

                return 200;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 400;
            }
        }

        public async Task<int> AddNewProduct(string productName, string description, float price, string productImagePath, int categoryId)
        {
            try
            {
                var newProduct = new Product
                {
                    ProductName = productName,
                    Description = description,
                    Price = price,
                    ProductImagePath = productImagePath,
                    CategoryId = categoryId
                };

                var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

                await context.Products.AddAsync(newProduct);
                await context.SaveChangesAsync();

                return 200;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return 400;
            }
        }
    }
}