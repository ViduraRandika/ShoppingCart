using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Cart
    {
        [Key] public long CartId { get; set; }

        public User User{ get; set; }
        [Required] public long UserId { get; set; }

        [Required] public string Status { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}