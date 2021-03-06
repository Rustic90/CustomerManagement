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
        public List<Customer> SearchCustomers()
        {
            using (StreamReader reader = new StreamReader("CustomerInfo.json"))
            {
                string rawCustomerList = reader.ReadToEnd();
                List<Customer> Customers = new List<Customer>();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(rawCustomerList);
                return Customers;
            }
        }
        public Customer SearchSingleCustomer(string customerToSearch)
        {
            using (StreamReader reader = new StreamReader("CustomerInfo.json"))
            {
                string rawCustomerList = reader.ReadToEnd();
                List<Customer> Customers = new List<Customer>();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(rawCustomerList);
                Customer customerSearched = new Customer();
                foreach(var customer in Customers)
                {
                    if (customer.FirstName == customerToSearch)
                    {
                        //customerSearched = customer;
                        return customer;
                    }
                }
                //customerSearched.printInfo();
                return null;
            }
        }
        public void AddCustomer()
        {
            List<Customer> Customers;
            string rawCustomerList;
            using (StreamReader reader = new StreamReader("CustomerInfo.json"))
            {
                rawCustomerList = reader.ReadToEnd();
                Customers = new List<Customer>();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(rawCustomerList);
                
                Console.WriteLine("Enter a first name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter a last name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter a phone number: ");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter a birthdate: ");
                string birthday = Console.ReadLine();

                Customer customerToAdd = new Customer(firstName, lastName, phoneNumber, birthday);
                Customers.Add(customerToAdd);
            }
            using (StreamWriter writer = new StreamWriter("CustomerInfo.json"))
            {
                rawCustomerList = JsonConvert.SerializeObject(Customers);
                writer.Write(rawCustomerList);
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Customer Created Successfully");
            Console.ResetColor();
        }
        public void RemoveCustomer()
        {
            List<Customer> Customers;
            string rawCustomerList;
            using (StreamReader reader = new StreamReader("CustomerInfo.json"))
            {
                rawCustomerList = reader.ReadToEnd();
                Customers = new List<Customer>();
                Customers = JsonConvert.DeserializeObject<List<Customer>>(rawCustomerList);
                int indexToRemove = 100;

                Console.WriteLine("Enter a customer first name to remove: ");
                string customerFirstNameToRemove = Console.ReadLine();
                Console.WriteLine("Enter a customer last name to remove: ");
                string customerLastNameToRemove = Console.ReadLine();
                foreach (Customer customer in Customers)
                {
                    if (customer.FirstName.Equals(customerFirstNameToRemove) && customer.LastName.Equals(customerLastNameToRemove))
                    {
                        indexToRemove = Customers.IndexOf(customer);
                    }
                }
                try {
                    Customers.RemoveAt(indexToRemove);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Customer Removed Successfully");
                    Console.ResetColor();
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("No customer found with that name");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
            using (StreamWriter writer = new StreamWriter("CustomerInfo.json"))
            {
                rawCustomerList = JsonConvert.SerializeObject(Customers);
                writer.Write(rawCustomerList);
            }
        }
    }
}