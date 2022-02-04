using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnlineNew.Models
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }

        public virtual OrderHistory Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
