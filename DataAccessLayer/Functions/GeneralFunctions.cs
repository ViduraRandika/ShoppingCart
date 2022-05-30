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
    public class GeneralFunctions:IGeneral
    {
        public async Task<List<Category>> ViewCategories()
        {
            List<Category> categories = new List<Category>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                categories = await context.Categories.ToListAsync();
            }

            return categories;
        }

        public async Task<List<Product>> ViewProducts()
        {
            List<Product> products = new List<Product>();
            using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
            {
                products = await context.Products.Include(c => c.Category).ToListAsync();
            }

            return products;
        }

        public async Task<List<Product>> ViewProducts(int id)
        {
            using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
            List<Product> products = new List<Product>();

            products = await context.Products.Where(p => p.CategoryId == id).Include(c => c.Category).ToListAsync();
            return products;
        }

        public Product ProductDetails(int id)
        {
            using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

            try
            {
                var product = context.Products.Single(p => p.ProductId == id);
                return product;
            }
            catch (Exception e)
            {
                return null;
            }
            
            
        }
    }
}