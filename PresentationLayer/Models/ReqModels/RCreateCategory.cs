using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ReqModels
{
    public class RCreateCategory
    {
        [Required]
        public string CategoryName { get; set; }
    }
}