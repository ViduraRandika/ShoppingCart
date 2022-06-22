using System;

namespace LogicLayer.ViewModels
{
    public class ViewBillModel
    {
        public long CartId { get; set; }
        public long OrderId { get; set; }
        public float GrandTotal { get; set; }
        public DateTime OrdereDateAndTime { get; set; }
    }
}