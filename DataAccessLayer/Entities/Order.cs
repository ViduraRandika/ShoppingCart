using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Order
    {
        [Key] public long OrderId { get; set; }
        
        [Required] public int CustomerId { get; set; }

        [Required] public float GrandTotal { get; set; }
        
        [Required] public long CartId { get; set; }

        [Required] public string Status { get; set; }

        [Required] public DateTime OrdereDateAndTime { get; set; }
    }
}