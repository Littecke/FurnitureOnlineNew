using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnlineNew.Models
{
    public partial class OrderHistory
    {
        public OrderHistory()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public double? TotalAmount { get; set; }
        public int? PaymentId { get; set; }
        public int? ShippingId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShippingAdress { get; set; }
        public string ShippingZipCode { get; set; }
        public string ShippingCity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
