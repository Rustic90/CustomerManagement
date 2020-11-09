using System;
using System.Drawing;

namespace CustomerManagement
{
    public class Customer 
    {
        // Code here
        public string FirstName {get;set;}
        public string LastName {get; set;}
        public string PhoneNumber {get;set;}
        public string Birthday {get; set;}

        public Customer()
        {
            
        }
        public Customer(string firstName, string lastName, string phoneNumber, string birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Birthday = birthday;
        }

        public void printInfo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("--------------------");
            Console.WriteLine(this.FirstName);
            Console.WriteLine(this.LastName);
            Console.WriteLine(this.PhoneNumber);
            Console.WriteLine(this.Birthday);
            Console.WriteLine("--------------------");
            Console.ResetColor();
        }
    }
}