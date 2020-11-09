using System;
using System.Reflection.Metadata;
using System.Collections;
using System.Collections.Generic;

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
                        case 1: List<Customer> Customers = mainMenu.SearchCustomers();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                foreach (var customer in Customers)
                                {
                                Console.WriteLine("--------------------------");
                                Console.WriteLine(customer.FirstName + " - " + customer.LastName );
                                Console.WriteLine("Phone: " + customer.PhoneNumber);
                                Console.WriteLine("Birthday: " + customer.Birthday);
                                }
                                Console.ResetColor();
                                break;
                        case 2: Console.WriteLine("Enter the first name of the customer you want to search: ");
                                string customerToSearch = Console.ReadLine();
                                Customer searchedCustomer = mainMenu.SearchSingleCustomer(customerToSearch);
                                searchedCustomer.printInfo();
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
