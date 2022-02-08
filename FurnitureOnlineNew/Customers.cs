using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureOnlineNew
{
    class Customers
    {
        public static Models.Customer DetermineMember()
        {
            Console.WriteLine("Är du medlem?");
            string input = Console.ReadLine();

            var member = new Models.Customer();

            if (input == "Ja")
            {
              member = MemberLogin();
            }
            else if (input == "Nej")
            {
                Console.WriteLine("Vill du bli medlem?");
                string input2 = Console.ReadLine();

                if (input2 == "Ja")
                {
                   member = CreateMember();
                }
                else
                {
                   member = GuestShopping();
                }
            }
            return member;
        }

        public static Models.Customer CreateMember()
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

                var newCustomer = new Models.Customer() {IdNumber = personalIdInput, UserName = userNameInput, Password = passWordInput, FirstName = firstNameInput, LastName = lastNameInput, Adress = adressInput, ZipCode = postalCodeInput, City = postalAreaInput, PhoneNumber = phoneNumberInput, Email = emailAdressInput, Membership = true};

                using (var db = new Models.FurnitureOnlineContext())
                {
                    var customerList = db.Customers;

                    customerList.Add(newCustomer);
                    db.SaveChanges();
                }
                return newCustomer;
            }
        }
        public static Models.Customer GuestShopping()
        {
                Console.Write("Personnummer (ÅÅÅÅMMDD-NNNN): ");
                string personalIdInput = Console.ReadLine();

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

                var guestShopper = new Models.Customer() { IdNumber = personalIdInput, FirstName = firstNameInput, LastName = lastNameInput, Adress = adressInput, ZipCode = postalCodeInput, City = postalAreaInput, PhoneNumber = phoneNumberInput, Email = emailAdressInput};

                using (var db = new Models.FurnitureOnlineContext())
                {
                    var customerList = db.Customers;
                    
                    customerList.Add(guestShopper);
                     db.SaveChanges();
                }
            return guestShopper;
        }

        public static Models.Customer MemberLogin()
        {
            Console.WriteLine("Ange ditt användarnamn, personnummer(ÅÅÅÅMMDD-NNNN) eller email: ");
            string input = Console.ReadLine();
            string password = Console.ReadLine();

            var customer = new Models.Customer();

            using(var db = new Models.FurnitureOnlineContext())
            {
                var customerList = db.Customers;

                foreach (var customers in customerList)
                {
                    if ((customer.UserName == input || customer.IdNumber == input || customer.Email == input) && customer.Password == password)
                    {
                        customer = customers;
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning, ange enligt exemplet");
                    }
                }
                return customer;
            }
        }
    }
}
