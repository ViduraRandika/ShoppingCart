using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models.ReqModels
{
    public class RCreateCustomer
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        // [Phone]
        public int CustomerPhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Password length must be between 8 and 20.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Confirm Password length must be between 8 and 20.", MinimumLength = 8)]
        [Compare("Password",ErrorMessage = "Password and Confirm Password must match")]
        public string ConfirmPassword { get; set; }
    }
}