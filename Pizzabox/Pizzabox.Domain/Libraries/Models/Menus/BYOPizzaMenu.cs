using System;
using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class BYOPizzaMenu
    {
        public BYOPizzaMenu()
        {
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Select Store";
        public int[] OptionRange { get; set; } = {1, 0};

        public void SetOptions()
        {
            // Add what is currently selected for the pizza object to the respective string

            MenuOptions.Add("1. Cancel");
            MenuOptions.Add("2. Add To Order");
            MenuOptions.Add("3. Select Crust");
            MenuOptions.Add("4. Select Sauce");
            MenuOptions.Add("5. Select Size");
            MenuOptions.Add("5. Select Toppings");
        }

        public void ExecuteOption(int option)
        {
            switch (option)
            {
                case 1:
                    MenuController.GoToMainMenu();
                    break;
                case 2:
                    //add to order
                    break;
                case 3:
                    MenuController.GoToAddPizzaItemMenu(1);
                    break;
                case 4:
                    MenuController.GoToAddPizzaItemMenu(2);
                    break;
                case 5:
                    MenuController.GoToAddPizzaItemMenu(3);
                    break;
                case 6:
                    MenuController.GoToAddPizzaItemMenu(4);
                    break;
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