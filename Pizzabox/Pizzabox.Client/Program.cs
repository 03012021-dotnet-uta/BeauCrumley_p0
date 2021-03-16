using System;
using Pizzabox.Client.Modules;
using Pizzabox.Domain.IO;
using Pizzabox.Domain.Libraries;
using Pizzabox.Domain.Libraries.Models.Menus;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger.WelcomeMessage();
            
            var dataAccessor = new DataAccessor();

            var newCustomer = Login.GetCustomer();
            dataAccessor.PersistCustomer(newCustomer);

            MenuController.GoToMainMenu();

            Console.Read();//stop program from closing for testing purposes.

        }
    }   
}