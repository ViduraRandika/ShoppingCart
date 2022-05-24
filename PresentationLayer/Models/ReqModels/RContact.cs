using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ReqModels
{
    public class RContact
    {
        [Required]
        public string email { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string body { get; set; }
    }
}