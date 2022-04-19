using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ReqModels
{
    public class RCredentials
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Password length must be between 8 and 20.", MinimumLength = 8)]
        public string Password { get; set; }
    }
}