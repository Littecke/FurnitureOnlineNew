using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnlineNew.Models
{
    class ShoppingCartQuery
    {
        public int Id { get; set; }
        public int? ArticleNumber { get; set; }
        public int? Quantity { get; set; }
        public string ProductName { get; set; }
        public double? UnitPrice { get; set; }
        public double? TotalAmount => Quantity * UnitPrice;
    }
}
