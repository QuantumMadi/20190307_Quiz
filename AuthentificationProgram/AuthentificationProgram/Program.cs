using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthentificationProgram
{
    class Program
    {
        static void Main(string[] args)
        {
           
            UserAutorizAuthen currentSession = new UserAutorizAuthen();           
            while (true)
            {
                int choice = 0;
                Console.WriteLine("1. Create new accaunt");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                int.TryParse(Console.ReadLine(),out choice);

                if (choice == 1)
                {

                    Console.WriteLine("Insert Email:");
                    string email = Console.ReadLine();

                    Console.WriteLine("Insert password:");
                    string password = Console.ReadLine();

                    Console.WriteLine("Insert age:");
                    string age = Console.ReadLine();

                    Console.WriteLine("Insert city:");
                    string city = Console.ReadLine();

                    Console.WriteLine("Insert your phone");
                    string phone = Console.ReadLine();

                    User user = new User(email, password, age, city,phone);
                    if (user.SuccessAuth == true) currentSession.UserAuthentification(user);
                    else Console.WriteLine("You have inserted invalid data, please try again");

                }
                else if (choice == 2)
                {
                    Console.WriteLine("Insert your Email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Insert your Password:");
                    string password = Console.ReadLine();

                    if (currentSession.UserAuthorization(email, password)) Console.WriteLine("Your authorization has been successful");
                    else Console.WriteLine("Not such user, try again");
                }
                else if (choice == 3) break;
            }


        }
    }
}
