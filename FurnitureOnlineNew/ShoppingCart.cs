using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class ShoppingCart
    {
        public static void AddProduct(Models.ShoppingCart cart)
        {
            using (var db = new FurnitureOnlineContext())
            {
                var cartTable = db.ShoppingCarts;
                var updateQuantityProduct = cartTable.SingleOrDefault(u => u.ProductsId == cart.ProductsId);

                if (updateQuantityProduct == null)
                {
                    cartTable.Add(cart);
                    db.SaveChanges();

                }

                else UpdateQuantityInCart(cart.ProductsId, updateQuantityProduct.AmountOfItems + cart.AmountOfItems);
            }
        }

        public static void UpdateQuantityInCart(int? articleNumber, int? numberOfItem)
        {
            using (var db = new FurnitureOnlineContext())
            {
                var articleToUpdate = db.ShoppingCarts.SingleOrDefault(c => c.ProductsId == articleNumber);
                articleToUpdate.AmountOfItems = numberOfItem;
                db.SaveChanges();
            }
        }
    }
}
