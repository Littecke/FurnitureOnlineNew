using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class Orderhistory
    {
        public void Checkout()
        {
            var orderCustomer = Customers.DetermineMember();
            var orderShippingMethod = Shipping.ChooseShipping();

            double? summa;

            Console.WriteLine(ShoppingCart.ShowShoppingCart(out summa));
            Console.WriteLine($"Frakt ({orderShippingMethod.Name} \t {orderShippingMethod.Price})");
            Console.WriteLine($"Totalt att betala: {summa}");


        }
    }
}
