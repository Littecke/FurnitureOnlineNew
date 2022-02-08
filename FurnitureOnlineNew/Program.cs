using System;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Products.ShowChosenItems());
            Console.WriteLine("----------------------------------");

            Console.WriteLine("Välkommen till Furniture Online!");
            Console.WriteLine(Products.ShowAllProducts());
            Console.WriteLine("----------------------------------");

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
                Console.WriteLine(ShoppingCart.ShowShoppingCart());
            }
            Console.WriteLine("----------------------------------");

            Shipping.ShowShippingAlternatives();
            Console.WriteLine(Shipping.ChooseShipping());

            Console.WriteLine("----------------------------------");

            Payment.ShowPaymentAlternatives();
            Console.WriteLine(Payment.ChoosePayment());

            Console.WriteLine("----------------------------------");

            Customers.DetermineMember();
        }
    }
}

    // Uppdatera artikelnr
    // sätta 0 på chosenitem
    // Ändra supplierId till Möbelvaruhuset AB 