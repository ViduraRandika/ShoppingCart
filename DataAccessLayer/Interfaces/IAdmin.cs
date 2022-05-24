using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IAdmin
    {
        Task<int> CreateCategory(string categoryName);

        Task<int> AddNewProduct(string productName, string description, float price, string productImagePath,
            int categoryId);

    }
}