using System;
using System.Reflection.Metadata;

namespace CustomerManagement
{
    class Program
    {
        static bool keepGoing = true;
        static void Main(string[] args)
        {
            while(keepGoing == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("| Welcome to the Customer Management system. |");
                Console.WriteLine("----------------------------------------------");
                Console.ResetColor();
                Menu mainMenu = new Menu();
                int selection = mainMenu.BeginMenu();    
                switch(selection)
                {
                        case 1: mainMenu.SearchCustomers();
                                break;
                        case 2: mainMenu.SearchSingleCustomer();
                                break;
                        case 3: mainMenu.AddCustomer();
                                break;
                        case 4: mainMenu.RemoveCustomer();
                                break;
                        case 5: Console.WriteLine("See you next time!");
                                keepGoing = false;
                                break;
                }     
            }   
        }
    }
}
