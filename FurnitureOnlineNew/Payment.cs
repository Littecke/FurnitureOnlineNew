using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureOnlineNew.Models;

namespace FurnitureOnlineNew
{
    class Payment
    {
        public static void ShowPaymentAlternatives()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var paymentList = db.Payments;

                Console.WriteLine($"{"BETALSÄTT",-15}{"SPECIFIKATION",-20}\n");

                foreach (var payment in paymentList)
                {
                    Console.WriteLine($"{payment.Id,-3}{payment.Method,-10}{payment.Specification,-20}\n");          
                }
            }
        }

        public static string ChoosePayment()
        {
            Console.WriteLine("Välj betalsätt från 1 till 3: ");
            int input = Convert.ToInt32(Console.ReadLine());

            using (var db = new FurnitureOnlineContext())
            {
                var payment = db.Payments;

                var chosenPayment = db.Payments.SingleOrDefault(s => s.Id == input);
                string returnString = "\nValt fraktsätt: \n\n";

                returnString += $"{chosenPayment.Method,-10}{chosenPayment.Specification}\t";
                return returnString;
            }
        }
    }
}
