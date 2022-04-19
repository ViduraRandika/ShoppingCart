using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccessLayer.Entities
{
    public class Customer
    {
        [Key] 
        public int Id { get; set; }
        
        [Required] public string CustomerName { get; set; }
        [Required] public string CustomerAddress { get; set; }
        [Required] public int CustomerPhoneNumber { get; set; }

        public User User { get; set; }
        [Required] public long UserId { get; set; }
        

    }
}