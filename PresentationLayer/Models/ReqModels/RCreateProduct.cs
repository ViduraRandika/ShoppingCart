using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ReqModels
{
    public class RCreateProduct
    {
        [Required] public int CategoryId { get; set; }
        [Required] public string ProductName { get; set; }
        [Required] public string Description { get; set; }
        [Required] public float Price { get; set; }
        [Required] public byte[] ProductImage { get; set; }
    }
}