using System;
using Pizzabox.Domain.IO;
using Pizzabox.Domain.Libraries;
using Pizzabox.Domain.Libraries.Models.Menus;

namespace Pizzabox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger.WelcomeMessage();

            MenuController.GoToMainMenu();

            Console.Read();//stop program from closing for testing purposes.

        }
    }
}
