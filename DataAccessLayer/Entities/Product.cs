using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Product
    {
        [Key] public int ProductId { get; set; }

        public Category Category { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public string ProductName { get; set; }
        [Required] public string Description { get; set; }
        [Required] public float Price { get; set; }
        [Required] public string ProductImagePath { get; set; }
    }
}