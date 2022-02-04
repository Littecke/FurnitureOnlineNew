using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnlineNew.Models
{
    class ProductListQuery
    {
        public int Id { get; set; }
        public int? ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }
        public int? stockUnit { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
    }
}
