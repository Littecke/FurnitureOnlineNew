using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnlineNew.Models
{
    public partial class ShoppingCart
    {
        public int Id { get; set; }
        public int? AmountOfItems { get; set; }
        public int? ProductsId { get; set; }
    }
}
