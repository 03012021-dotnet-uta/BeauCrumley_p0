using System;
using System.Collections.Generic;
using Pizzabox.Domain.IO;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class NewOrderMenu
    {
        public NewOrderMenu(ACustomer cust)
        {
            currentOrder = Factory.CreateOrder();
            currentOrder.customer = cust;
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public List<AStore> StoreList  { get; set; }
        public string Name { get; set; } = "Select Store";
        public int[] OptionRange { get; set; } = {1, 0};
        public AOrder currentOrder { get; set; }

        public void SetOptions()
        {
            MenuOptions.Add("1. Cancel");

            StoreList = new List<AStore>();
            StoreList = ObjBuilder.BuildStores(DataAccessor.GetStores());
            var i = 1;
            foreach (var store in StoreList)
            {
                i += 1;
                MenuOptions.Add($"{i}. {store.Name}");
            }
        }

        public void ExecuteOption(int option)
        {
            if (option == 1)
            {
                MenuController.GoToMainMenu(currentOrder.customer);
            }
            else
            {
                currentOrder.FulfillingStore = StoreList[option - 2];
                MenuController.GoToPizzaSelectMenu(currentOrder);
            }
        }

        public void DisplayMenuOptions()
        {
            Messenger.StandardLineBreak();
            Console.WriteLine($"{Name}\n");
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }
        }
    }
}