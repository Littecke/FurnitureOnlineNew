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

        public static Models.Payment ChoosePayment()
        {
            using (var db = new FurnitureOnlineContext())
            {
                var paymentList = db.Payments;

                foreach (var payment in paymentList)
                {
                    Console.WriteLine($"{payment.Id}\t{payment.Method}\n-----------------------\n{payment.Specification}\n\n");
                }

                Console.WriteLine("Vilket betalningssätt vill du använda? (Ange ID-nr.) \n");
                int selectPayment = Convert.ToInt32(Console.ReadLine());

                return db.Payments.SingleOrDefault(s => s.Id == selectPayment);
            }
        }
    }
}