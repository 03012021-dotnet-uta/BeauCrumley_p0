using System;
using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class PreviewOrderMenu
    {
        public PreviewOrderMenu()
        {
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Select Store";
        public int[] OptionRange { get; set; } = {1, 0};
        public Order currentOrder { get; set; }

        public void SetOptions()
        {
            // Get list of stores from db context
            MenuOptions.Add("1. Cancel");
            MenuOptions.Add("2. Checkout");
            MenuOptions.Add("3. Remove Item");
        }

        public void ExecuteOption(int option)
        {
            switch (option)
            {
                case 1:
                    MenuController.GoToMainMenu();
                    break;
                case 2:
                    //check order valid
                    //add order to db
                    break;
                case 3:
                    MenuController.GoToRemoveItemMenu();
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

        public void DisplayItemsOnMenu()
        {
            Console.WriteLine("Shopping Cart");
            int newLineCheck = 0;
            foreach (var pizza in currentOrder.PizzasOnOrder)
            {
                newLineCheck += 1;
                Console.Write($"{pizza.Name}, ");
                if (newLineCheck >= 3)
                {
                    Console.Write("\n");
                }
            }
        }
    }
}