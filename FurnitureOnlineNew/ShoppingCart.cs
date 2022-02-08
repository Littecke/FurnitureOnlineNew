using FurnitureOnlineNew.Models;
using System.Collections.Generic;
using System.Linq;

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
        public static string ShowShoppingCart()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var cartList = from
                               cart in db.ShoppingCarts
                               join
                               product in db.Products on cart.ProductsId equals product.ArticleNr
                               select new ShoppingCartQuery { Id = cart.Id, ProductName = product.Name, UnitPrice = product.CurrentPrice, Quantity = cart.AmountOfItems, ArticleNumber = product.ArticleNr };

                string returnString = $"SAMMANSTÄLLNING\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-25}{"PRIS",-14}{"ANTAL",-17}{"TOTAL KOSTNAD PER ARTIKEL",-30}\n";

                double? totalAmountAllArticles = 0;
                foreach (var item in cartList)
                {
                    returnString += $"{item.ArticleNumber,-10}{item.ProductName,-25}{item.UnitPrice,-14:C2}{item.Quantity,-17}{item.TotalAmount,-10:C2}\n";
                    totalAmountAllArticles += item.TotalAmount;
                }
                returnString += $"\nTOTAL KOSTNAD FÖR ALLA ARTIKLAR: {totalAmountAllArticles:C2}";
                return returnString;
            }
        }
    }
}
