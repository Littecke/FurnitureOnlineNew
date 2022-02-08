using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class Shipping
    {
        public static void ShowShippingAlternatives()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var shippingList = db.Shippings;

                Console.WriteLine($"FRAKTBOLAG\n\n{"SPECIFIKATION",-20}{"PRIS",-13}\n");

                foreach (var shipping in shippingList)
                {
                    Console.WriteLine($"{shipping.Id,-3}{shipping.Name,-20}{shipping.Price,-13:C2}\n{shipping.Specification,-25}\n");           // kontrollera att Id börjar från 1
                }   
            }
        }

        public static string ChooseShipping()
        {
            Console.WriteLine("Välj fraktsätt från 1 till 3: ");
            int input = Convert.ToInt32(Console.ReadLine());

            using (var db = new FurnitureOnlineContext())
            {
                var shipping = db.Shippings;

                var chosenShipping = db.Shippings.SingleOrDefault(s => s.Id == input);
                string returnString = "\nValt fraktsätt: \n\n";

               returnString += $"{chosenShipping.Name,-10}{chosenShipping.Price} kr \t";
               return returnString;
            }
        }
    }
}
