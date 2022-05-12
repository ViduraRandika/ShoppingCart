using DataAccessLayer.Entities;

namespace LogicLayer.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string CategoryName{ get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string ProductImagePath { get; set; }
    }
}