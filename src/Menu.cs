using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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
        public void SearchCustomers()
        {
            using (StreamReader reader = new StreamReader("src/CustomerInfo.json"))
            {
                string rawCustomerList = reader.ReadToEnd();
                List<Customer> Customers = new List<Customer>();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(rawCustomerList);
                foreach (var customer in Customers)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine(customer.FirstName + " - " + customer.LastName );
                    Console.WriteLine("Phone: " + customer.PhoneNumber);
                    Console.WriteLine("Birthday: " + customer.Birthday);
                }
                
            }
        }
        public void SearchSingleCustomer()
        {
            using (StreamReader reader = new StreamReader("src/CustomerInfo.json"))
            {
                string rawCustomerList = reader.ReadToEnd();
                List<Customer> Customers = new List<Customer>();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(rawCustomerList);
                Console.WriteLine("Enter the first name of the customer you want to search: ");
                string customerToSearch = Console.ReadLine();
                Customer customerSearched = new Customer();
                foreach(var customer in Customers)
                {
                    if (customer.FirstName == customerToSearch)
                    {
                        customerSearched = customer;
                    }
                }
                customerSearched.printInfo();
            }
        }
        public void AddCustomer()
        {
            List<Customer> Customers;
            string rawCustomerList;
            using (StreamReader reader = new StreamReader("src/CustomerInfo.json"))
            {
                rawCustomerList = reader.ReadToEnd();
                Customers = new List<Customer>();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(rawCustomerList);
      
                Customer customerToAdd = new Customer();
                customerToAdd.createNew();
                Customers.Add(customerToAdd);
            }
            using (StreamWriter writer = new StreamWriter("src/CustomerInfo.json"))
            {
                rawCustomerList = JsonConvert.SerializeObject(Customers);
                writer.Write(rawCustomerList);
            }
        }
        public void RemoveCustomer()
        {
            Console.WriteLine("remove customer coming soon");
        }
    }
}