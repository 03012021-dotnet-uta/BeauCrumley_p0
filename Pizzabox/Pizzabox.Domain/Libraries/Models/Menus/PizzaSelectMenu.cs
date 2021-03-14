using System;
using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class PizzaSelectMenu
    {
        public PizzaSelectMenu()
        {
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Select Store";
        public int[] OptionRange { get; set; } = {1, 0};

        public void SetOptions()
        {
            // Get list of pizzas from db context
            MenuOptions.Add("1. Cancel");
            MenuOptions.Add("2. Build Your Own");
            MenuOptions.Add("3. Preview Order");
            MenuOptions.Add("4. Pizza 1");
            MenuOptions.Add("5. Pizza 2");
            MenuOptions.Add("6. Pizza 3");
        }

        public void ExecuteOption(int option)
        {
            if (option == 1)
            {
                MenuController.GoToMainMenu();
            }
            else if (option == 2)
            {
                MenuController.GoToBYOPizzaMenu();
            }
            else if (option == 3)
            {
                MenuController.GoToPreviewOrderMenu();
            }
            else
            {
                //select pizza
                Console.WriteLine($"Selecting pizza number {option - 2}.");
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