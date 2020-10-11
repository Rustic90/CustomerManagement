using System;

namespace CustomerManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("| Welcome to the Customer Management system. |");
            Console.WriteLine("----------------------------------------------");
            Console.ResetColor();
            Menu mainMenu = new Menu();
            int selection = mainMenu.BeginMenu();            
        }
    }
}
