using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class Products
    {
        public static string ShowChosenItems()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var products = db.Products;
                var chosenProducts = products.Where(s => s.ChosenItem == true);
                string returnString = "\nNågra utvalda produkter: \n\n";

                foreach (var product in chosenProducts)
                {
                    returnString += $"{product.Name}, {product.CurrentPrice} kr \t";
                }
                return returnString;
            }
        }

        public static string ShowAllProducts()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var productList = from
                                  product in db.Products
                                  join
                                  Category in db.Categories on product.CategoryId equals Category.Id
                                  join Supplier in db.Suppliers on product.SupplierId equals Supplier.Id
                                  select new ProductListQuery { Id = product.Id, ProductName = product.Name, Price = product.CurrentPrice, CategoryName = Category.Name, SupplierName = Supplier.Name, 
                                      stockUnit = product.StockUnit, Description = product.Description, Color = product.Color, Material = product.Material, ArticleNumber = product.ArticleNr };

                string returnString = $"PRODUKTLISTA\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-25}{"PRIS",-14}{"KATEGORI",-17}{"LEVERANTÖR",-20}{"LAGERSALDO",-25}\n";

                foreach (var product in productList)
                {
                    returnString += $"{product.ArticleNumber,-10}{product.ProductName,-25}{string.Format("{0:0.00}", product.Price) + " kr",-14}{product.CategoryName,-17}{product.SupplierName,-20}{product.stockUnit,-17}\n";
                }
                return returnString;
            }
        }

        public static string ShowAProduct(int articleNr)
        {
            using (var db = new FurnitureOnlineContext())
            {
                var productList = from
                                    product in db.Products
                                  join
                                  Category in db.Categories on product.CategoryId equals Category.Id
                                  join Supplier in db.Suppliers on product.SupplierId equals Supplier.Id
                                  select new ProductListQuery { Id = product.Id, ProductName = product.Name, Price = product.CurrentPrice, CategoryName = Category.Name, SupplierName = Supplier.Name, stockUnit = product.StockUnit, Description = product.Description, Color = product.Color, Material = product.Material, ArticleNumber = product.ArticleNr };
                var specificArticle = productList.Where(a => a.ArticleNumber == articleNr).ToList();

                return $"{specificArticle[0].ProductName.ToUpper()}\n\nProduktbeskrivning: \n{specificArticle[0].Description}\n\nProduktfakta:\nArtikelnt: {specificArticle[0].Id}\nKategori: {specificArticle[0].CategoryName}\nLeverantör: {specificArticle[0].SupplierName}\nFärg: {specificArticle[0].Color}\nMaterial: {specificArticle[0].Material}";

            }
        }

        public static void UpdateStockUnit(int articleNr, int Quantity)
        {
            using (var db = new FurnitureOnlineContext())
            {
                var products = db.Products;
                var updateQuantityProduct = products.SingleOrDefault(p => p.ArticleNr == articleNr);

                if (updateQuantityProduct == null)
                {
                    Console.WriteLine("Finns ingen produkt med det artikelnumret och därför tas inget bort.");
                }
                else updateQuantityProduct.StockUnit -= Quantity;
                db.SaveChanges();
            }
        }

        public static void SearchProduct()
        {
            Console.WriteLine("Ange namnet på produkten du vill söka på");
            string inputName = Console.ReadLine();
            
        }
    }
}
/*
 Console.WriteLine("Vilken produkt vill du klicka in på? Ange artikelnumret");
            int input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Products.ShowAProduct(input));

            Console.WriteLine("Vill du lägga till den i varukorgen? Skriv isåfall 'Ja' ");
            string stringInput = Console.ReadLine();

            if (stringInput == "Ja")
            {
                Console.WriteLine("Hur många exemplar av denna artikel vill du ha?");
                int number = Convert.ToInt32(Console.ReadLine());

                var newProductInCart = new Models.ShoppingCart() { ProductsId = input, AmountOfItems = number };
                ShoppingCart.AddProduct(newProductInCart);

            }
*/