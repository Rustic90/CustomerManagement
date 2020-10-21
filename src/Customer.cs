using System;

namespace CustomerManagement
{
    public class Customer 
    {
        // Code here
        public string FirstName {get;set;}
        public string LastName {get; set;}
        public string PhoneNumber {get;set;}
        public string Birthday {get; set;}

        public void CreateNew()
        {
            Console.WriteLine("Enter a first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter a last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter a phone number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter a birthdate: ");
            string birthday = Console.ReadLine();

            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
            this.Birthday = birthday;
        }
    }
}