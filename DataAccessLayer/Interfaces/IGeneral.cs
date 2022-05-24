using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IGeneral
    {
        Task<List<Category>> ViewCategories();
        
        //AL PRODUCTS
        Task<List<Product>> ViewProducts();

        //SELECTED CATEGORY PRODUCT
        Task<List<Product>> ViewProducts(int id);


        //SELECTED PRODUCT DETAILS
        Product ProductDetails(int id);
    }
}