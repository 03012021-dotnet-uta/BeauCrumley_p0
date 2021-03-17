using System;
using Pizzabox.Client.Modules;
using Pizzabox.Domain.IO;
using Pizzabox.Domain.Libraries;
using Pizzabox.Domain.Libraries.Models;
using Pizzabox.Domain.Libraries.Models.Menus;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger.WelcomeMessage();

            var newCustomer = Login.GetCustomer();
            DataAccessor.PersistCustomer(ObjSaver.SendCustomerToMapper(newCustomer));

            MenuController.GoToMainMenu(newCustomer);
        }
    }   
}