using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAdmin
    {
        Task<int> CreateCategory(string categoryName);

        Task<int> AddNewProduct(string productName, string description, float price, string productImagePath,
            int categoryId);

    }
}