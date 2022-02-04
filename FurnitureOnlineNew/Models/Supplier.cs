using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnlineNew.Models
{
    public partial class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public bool? InStock { get; set; }
    }
}
