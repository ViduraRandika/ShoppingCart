using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Functions;
using DataAccessLayer.Interfaces;
using LogicLayer.ViewModels;

namespace LogicLayer.GenaralLogics
{
    public class GeneralLogic
    {
        private readonly IGeneral _general = new GeneralFunctions();
        public async Task<List<CategoryViewModel>> ViewCategories()
        {
            

            var categories = await _general.ViewCategories();
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

        // GET ALL PRODUCTS
        public async Task<List<ProductViewModel>> ViewProducts()
        {
            var products = await _general.ViewProducts();
            List<ProductViewModel> productList = new List<ProductViewModel>();
            if (products.Count > 0)
            {
                // return products;
                foreach (var product in products)
                {
                    ProductViewModel currentProduct = new ProductViewModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductImagePath = product.ProductImagePath,
                        Price = product.Price,
                        Description = product.Description,
                        CategoryName = product.Category.CategoryName
                    };

                    productList.Add(currentProduct);
                }
                return productList;
            }

            return null;
        }

        // GET PRODUCTS IN SELECTED CATEGORY
        public async Task<List<ProductViewModel>> ViewProducts(int id)
        {
            var products = await _general.ViewProducts(id);
            List<ProductViewModel> productList = new List<ProductViewModel>();
            if (products.Count > 0)
            {
                // return products;
                foreach (var product in products)
                {
                    ProductViewModel currentProduct = new ProductViewModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductImagePath = product.ProductImagePath,
                        Price = product.Price,
                        Description = product.Description,
                        CategoryName = product.Category.CategoryName
                    };

                    productList.Add(currentProduct);
                }
                return productList;
            }

            return null;
        }

        public Product ProductDetails(int id)
        {
            var product = _general.ProductDetails(id);
            if (product==null)
            {
                return null;
            }

            return product;
        }
    }
}