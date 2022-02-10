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
        public static void Checkout()
        {
            var orderCustomer = Customers.DetermineMember();
            var OrderShippingMethod = Shipping.ChooseShipping();

            double? summa;
            string orderSummary = ShoppingCart.ShowShoppingCart(out summa) + $"Frakt ({OrderShippingMethod.Name}) \t{OrderShippingMethod.Price:C}\nTotal att betala: {summa + OrderShippingMethod.Price:C}";
            Console.WriteLine(orderSummary);

            var payment = Payment.ChoosePayment();

            var newOrderHistory = new Models.OrderHistory() { CustomerId = orderCustomer.Id, OrderDate = DateTime.Now, ShippingId = OrderShippingMethod.Id, PaymentId = payment.Id, ShippingAdress = orderCustomer.Adress, ShippingZipCode = orderCustomer.ZipCode, ShippingCity = orderCustomer.City, TotalAmount = summa + OrderShippingMethod.Price };

            using (var dbOrderHistory = new Models.FurnitureOnlineContext())
            {
                var orderList = dbOrderHistory.OrderHistories;
                orderList.Add(newOrderHistory);
                dbOrderHistory.SaveChanges();

                var cartlist = from
                                  cart in dbOrderHistory.ShoppingCarts
                               join
                               product in dbOrderHistory.Products on cart.ProductsId equals product.ArticleNr
                               select new ShoppingCartQuery { ArticleNumber = cart.ProductsId, ProductName = product.Name, Quantity = cart.AmountOfItems, UnitPrice = product.CurrentPrice };

                foreach (var item in cartlist)
                {
                    using (var dbOrderDetail = new Models.FurnitureOnlineContext())
                    {
                        var OrderDetailList = dbOrderDetail.OrderDetails;
                        var newOrderDetail = new Models.OrderDetail() { OrderId = newOrderHistory.Id, ProductId = 5, Price = item.UnitPrice, Quantity = item.Quantity };

                        OrderDetailList.Add(newOrderDetail);
                        Products.UpdateStockUnit((int)item.ArticleNumber, (int)item.Quantity);
                        dbOrderDetail.SaveChanges();
                    }
                }

                Console.WriteLine("Orderbekräftelse:\n" + orderSummary);

            }
            ShoppingCart.ClearShoppingCart();
        }
    }
}
