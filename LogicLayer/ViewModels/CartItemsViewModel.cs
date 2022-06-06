namespace LogicLayer.ViewModels
{
    public class CartItemsViewModel
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int ProductId { get; set; }
        public int  Qty { get; set; }
    }
}