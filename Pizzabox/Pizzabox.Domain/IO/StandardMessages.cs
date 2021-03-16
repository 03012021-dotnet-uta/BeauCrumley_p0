using System;

namespace Pizzabox.Domain.IO
{
    public static class Messenger
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to the Pizza Box Application\n____________________________________");
        }
        public static void InvalidInputMessage()
        {
            Console.WriteLine("Invalid input, please try again. . .");
        }
        public static void FirstNamePropmt()
        {
            Console.WriteLine("Please enter your first name.");
        }
        public static void LastNamePropmt()
        {
            Console.WriteLine("Please enter your last name.");
        }
        public static void ExitMessage()
        {
            Console.WriteLine("Thank you for using the Pizza Box Application");
            Console.Read();
        }
    }
}