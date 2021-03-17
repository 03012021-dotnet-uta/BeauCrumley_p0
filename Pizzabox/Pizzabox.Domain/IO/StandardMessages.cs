using System;

namespace Pizzabox.Domain.IO
{
    public static class Messenger
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("\nWelcome to the Mark's Mighty Pizza!\n");
            StandardLineBreak();
        }

        public static void StandardLineBreak()
        {
            Console.WriteLine("____________________________________");
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
        public static void ToppingError()
        {
            Console.WriteLine("Too many toppings. . . Please consider starting another pizza!");
        }
        public static void CustomPizzaError()
        {
            Console.WriteLine("Oops! Please make sure the pizza is complete.");
        }
        public static void OrderError()
        {
            Console.WriteLine("Oops! Please make sure your order is less than $250.00 and that there are fewer than 50 pizzas on the order.");
        }
        public static void OrderPlacedMessage()
        {
            Console.WriteLine("Your order has been sent to our store. Expect delivery never.");
        }
    }
}