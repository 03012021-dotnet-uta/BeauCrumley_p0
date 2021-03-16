using System;
using System.Collections.Generic;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class NewOrderMenu
    {
        public NewOrderMenu()
        {
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
            currentOrder = Factory.CreateOrder();
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Select Store";
        public int[] OptionRange { get; set; } = {1, 0};
        public Order currentOrder { get; set; }

        public void SetOptions()
        {
            List<AStore> storeList = new List<AStore>();
            storeList = DataAccessor.GetStores();
            MenuOptions.Add("1. Cancel");
            MenuOptions.Add("2. Store 1");
            MenuOptions.Add("3. Store 2");
            MenuOptions.Add("4. Store 3");
            MenuOptions.Add("5. Store 4");
        }

        public void ExecuteOption(int option)
        {
            if (option == 1)
            {
                MenuController.GoToMainMenu();
            }
            else
            {
                MenuController.GoToPizzaSelectMenu();
            }
        }

        public void DisplayMenuOptions()
        {
            Console.WriteLine($"{Name}\n");
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }
        }
    }
}