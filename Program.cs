using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the warehouse asset management program!");
            AdminMenu.DisplayAllUsers();

            Console.WriteLine("Please Select your id:");

            
            int myid = Convert.ToInt32(Console.ReadLine());


            if (myid == 0)
            {
                AdminMenu.ShowAdminMenu();
            }
            else
            {
                UserMenu.ShowUserMenu(myid);
            }

            Console.WriteLine("Thank you for using the warehouse asset management program. Press any key to exit.");
            Console.ReadKey();
        }
    }
    }

