using System;
using System.Collections.Generic;

#nullable disable

namespace FurnitureOnlineNew.Models
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? Membership { get; set; }

        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
