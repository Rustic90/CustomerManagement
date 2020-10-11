using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomerManagement
{
    public class Menu
    {
        bool keepGoing = true;
        int selection;
        public Menu()
        {

        }
        public int BeginMenu()
        {
            while (keepGoing == true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("Please enter a number to select one of the options below.");
                Console.WriteLine("1) Search all current customers");
                Console.WriteLine("2) Search for a specific customer");
                Console.WriteLine("3) Add a customer");
                Console.WriteLine("4) Remove a customer");
                Console.WriteLine("5) Quit");
                
                string input = Console.ReadLine();
                if (int.TryParse(input, out selection))
                {
                    if (selection > 0 && selection < 6)
                    {
                        keepGoing = false;
                        return selection;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("--- You entered a number, but it is not a valid option --- ");
                        Console.ResetColor();
                    }
                    
                }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("--- Please enter a valid selection ---");
                    Console.ResetColor();
                }
            }
            return 0;
        }
        public void SearchCustomer()
        {
            Console.WriteLine("search all customers coming soon");
        }
        public void SearchSingleCustomer()
        {
            Console.WriteLine("search single customer coming soon");
        }
        public void AddCustomer()
        {
            Console.WriteLine("add customer coming soon");
        }
        public void RemoveCustomer()
        {
            Console.WriteLine("remove customer coming soon");
        }
    }
}