using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnlineNew
{
    class Customers
    {
        public static Models.Customer CreateCustomer()
        {
            {
                Console.Write("Personnummer (ÅÅÅÅMMDD-NNNN): ");
                string personalIdInput = Console.ReadLine();

                Console.Write("Användarnamn: ");
                string userNameInput = Console.ReadLine();

                Console.Write("Password: ");
                string passWordInput = Console.ReadLine();

                Console.Write("Förnamn: ");
                string firstNameInput = Console.ReadLine();

                Console.Write("Efternamn: ");
                string lastNameInput = Console.ReadLine();

                Console.Write("Adress: ");
                string adressInput = Console.ReadLine();

                Console.Write("Postnummer: ");
                string postalCodeInput = Console.ReadLine();

                Console.Write("Postort: ");
                string postalAreaInput = Console.ReadLine();

                Console.Write("Telefonnummer: ");
                string phoneNumberInput = Console.ReadLine();

                Console.WriteLine("E-mail: ");
                string emailAdressInput = Console.ReadLine();

                var newCustomer = new Models.Customer() {IdNumber = personalIdInput, UserName = userNameInput, Password = passWordInput, FirstName = firstNameInput, LastName = lastNameInput, Adress = adressInput, ZipCode = postalCodeInput, City = postalAreaInput, PhoneNumber = phoneNumberInput, Email = emailAdressInput};

                using (var db = new Models.FurnitureOnlineContext())
                {
                    var customerList = db.Customers;

                    customerList.Add(newCustomer);
                    db.SaveChanges();
                }

                return newCustomer;
            }

        }
    }
}
