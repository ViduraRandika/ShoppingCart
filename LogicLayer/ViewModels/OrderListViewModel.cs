using System;

namespace LogicLayer.ViewModels
{
    public class OrderListViewModel
    {
        public long OrderId { get; set; }

        public int CustomerId { get; set; }

        public float GrandTotal { get; set; }

        public long CartId { get; set; }

        public string Status { get; set; }

        public DateTime OrdereDateAndTime { get; set; }
    }
}