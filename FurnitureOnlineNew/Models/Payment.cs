using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnlineNew.Models
{
    public partial class Payment
    {
        public Payment()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public string Method { get; set; }
        public string Specification { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
