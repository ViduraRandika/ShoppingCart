using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccessLayer.Entities
{
    public class User
    {
        [Key] public long UserId { get; set; }

        [Required] 
        public string Email { get; set; }

        [Required] public string Password { get; set; } 

        public AuthLevel AuthLevel { get; set; }
        [Required] public int AuthLevelId{ get; set; }

        public List<Customer> Customers { get; set; }

        //------------- AUTH LEVELS ------------

        // #1 -------> ADMIN
        // #2 -------> REGISTERED CUSTOMER
        // #3 -------> GUEST
    }
}