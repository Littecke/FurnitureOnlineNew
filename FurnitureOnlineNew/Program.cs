using System;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till Furniture Online!");
            Console.WriteLine("----------------------------------");
            Console.WriteLine(Products.ShowChosenItems());

            MenuSelection();
            
            Orderhistory.Checkout();
        }
        public static void MenuSelection()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Välj enligt menyn:");
                Console.WriteLine("[1] Sök på produkt\n[2] Se produktlista\n[3] Välj enligt kategori\n[4] Se kundvagn\n[5] Exit");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                    // metod för att söka på produkt
                        break;

                    case 2:

                        Console.WriteLine(Products.ShowAllProducts());
                        break;

                    case 3:
                        // metod för att välja enligt kategori
                        break;

                    case 4:
                        Console.WriteLine(ShoppingCart.ShowShoppingCart(out _));

                        break;

                    case 5:
                        Console.WriteLine("Tack för besöket, tipsa gärna dina vänner och familj!");
                        break;

                    default:
                        Console.WriteLine("Felaktig inmatning, måste vara enligt menyn");
                        break;
                }
            }
        }
    }
}

    // Uppdatera artikelnr
    // sätta 0 på några chosenitem
    // sätta inlagda members till 1 
    // Ändra supplierId till Möbelvaruhuset AB 
    // Shipping ID börja från 0