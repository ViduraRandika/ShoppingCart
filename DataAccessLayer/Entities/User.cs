using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class User
    {
        [Key] public long UserId { get; set; }

        [Required] 
        public string Email { get; set; }

        [Required] public string Password { get; set; }

        [Required] public string UserFullName { get; set; }

        [Required] public string UserAddress { get; set; }

        [Required] public string UserPhoneNumber { get; set; }

        public AuthLevel AuthLevel { get; set; }
        [Required] public int AuthLevelId { get; set; }


        //------------- AUTH LEVELS ------------

        // #1 -------> ADMIN
        // #2 -------> REGISTERED CUSTOMER
        // #3 -------> GUEST
    }
}