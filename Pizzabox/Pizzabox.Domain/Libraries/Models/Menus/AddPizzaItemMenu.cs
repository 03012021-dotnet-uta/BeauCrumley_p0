using System;
using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class AddPizzaItemMenu
    {
        public AddPizzaItemMenu(int menu)
        {
            SubMenuType = menu;
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string[] Name { get; set; } = {"Select Crust", "Select Sauce", "Select Size", "Select Topping"};
        public int[] OptionRange { get; set; } = {1, 0};

        public int SubMenuType { get; set; }

        public void SetOptions()
        {
            // Add what is currently selected for the pizza object to the respective string
            //SubMenuType controls which pizza options to lookup from db context
            MenuOptions.Add("1. Cancel");
            MenuOptions.Add("2. Pizza Option 1");
            MenuOptions.Add("3. Pizza Option 2");
            MenuOptions.Add("4. Pizza Option 3");
            MenuOptions.Add("5. Pizza Option 4");
        }

        public void ExecuteOption(int option)
        {
            if (option == 1)
            {
                MenuController.GoToMainMenu();
            }
            else
            {
                //add item to pizza
                MenuController.GoToBYOPizzaMenu();
            }
        }

        public void DisplayMenuOptions()
        {
            Console.WriteLine($"{Name[SubMenuType - 1]}\n");
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }
        }
    }
}