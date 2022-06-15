using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CartItem
    {
        [Key] public long Id { get; set; }

        public Product Product { get; set; }
        [Required] public int ProductId { get; set; }

        public Cart Cart { get; set; }
        [Required] public long CartId { get; set; }
        
        [Required] public int Qty { get; set; }
    }
}