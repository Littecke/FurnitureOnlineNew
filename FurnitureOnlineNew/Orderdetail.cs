using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class Orderdetail
    {
       
        public static void AddToOrder()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var cartlList = from
                                  product in db.Products
                                  join
                                  cart in db.ShoppingCarts on product.ArticleNr equals cart.Id
                                  select new ShoppingCartQuery
                                  {
                                      Id = product.Id,
                                      ArticleNumber = product.ArticleNr,
                                      Quantity = product.StockUnit,
                                      ProductName = product.Name,
                                      UnitPrice = product.CurrentPrice
                                  };

                string returnString = $"ORDERDETALJER\n\n{"ART.NR.",-10}{"PRODUKTNAMN",-25}{"PRIS",-14}{"KATEGORI",-17}{"LEVERANTÖR",-20}{"LAGERSALDO",-25}\n";

                foreach (var order in cartlList)
                {
                    returnString += $"{order.Id,-10}{order.ArticleNumber,-10}{order.ProductName,-25}{order.UnitPrice,-14:C2}{order.TotalAmount,-17}\n";
                }
              //  return returnString;
            }
        }

    }
}
