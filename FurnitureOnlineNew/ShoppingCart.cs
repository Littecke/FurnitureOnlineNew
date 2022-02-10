using FurnitureOnlineNew.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
                var articleToUpdate2 = db.Products.SingleOrDefault(c => c.ArticleNr == articleNumber);
                articleToUpdate.AmountOfItems = numberOfItem;

                if (articleToUpdate2.StockUnit > numberOfItem) 
                {
                    db.SaveChanges();
                }
               else Console.WriteLine("Du kan inte ta bort fler produkter än vad lagersaldot har");
            }
        }
        public static string ShowShoppingCart(out double? summa)
        {
            summa = 0;

            using (var db = new FurnitureOnlineContext())
            {
                var cartList = from
                               cart in db.ShoppingCarts
                               join
                               product in db.Products on cart.ProductsId equals product.ArticleNr
                               select new ShoppingCartQuery { Id = cart.Id, ProductName = product.Name, UnitPrice = product.CurrentPrice, Quantity = cart.AmountOfItems, ArticleNumber = product.ArticleNr };

                string returnString = $"SAMMANSTÄLLNING\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-25}{"PRIS",-14}{"ANTAL",-17}{"TOTAL KOSTNAD PER ARTIKEL",-30}\n";
                summa = 0;

                foreach (var item in cartList)
                {
                    returnString += $"{item.ArticleNumber,-10}{item.ProductName,-25}{item.UnitPrice,-14:C2}{item.Quantity,-17}{item.TotalAmount,-10:C2}\n";
                    summa += item.TotalAmount;
                }
                returnString += $"\nTOTAL KOSTNAD FÖR ALLA ARTIKLAR: {summa:C2}";
                return returnString;
            }
        }

        public static void ClearShoppingCart()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var cartTable = db.ShoppingCarts;

                foreach (var item in cartTable)
                {
                    cartTable.Remove(item);
                }
                    db.SaveChanges();
            }
        }

        public static void ChangeOrRemoveProductsInCart(int articleNr)
        {
            Console.WriteLine($"Vill du ändra antalet produkter med artikelnummer: {articleNr} i kundvagnen eller ta bort en produkt? Välj mellan 1 och 2");
            int input = Convert.ToInt32(Console.ReadLine());

            using (var db = new FurnitureOnlineContext())
            {
                var cartTable = db.ShoppingCarts;

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Ange det antalet du vill ha");
                        int input2 = Convert.ToInt32(Console.ReadLine());

                                ShoppingCart.UpdateQuantityInCart(articleNr,input2);
                        break;
                    default:
                        

                    case 2:

                        Console.WriteLine("Ange artikelnr. på den produkt du vill ta bort?");
                        int articleToRemove = Convert.ToInt32(Console.ReadLine());

                        foreach (var item in cartTable)
                        {
                            if (item.ProductsId == articleToRemove)
                            {
                                cartTable.Remove(item);
                            }
                           
                            db.SaveChanges();

                        }
                        Console.WriteLine("Produkten finns inte i din kundvagn");

                        break;
                    default:
                        break;
                }
            }

        }
    }
}
