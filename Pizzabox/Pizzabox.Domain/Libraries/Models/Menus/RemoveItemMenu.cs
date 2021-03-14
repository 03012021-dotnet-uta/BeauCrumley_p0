using System;
using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class RemoveItemMenu
    {
        public RemoveItemMenu()
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
            MenuOptions.Add("1. Go Back");
            for (var i = 0; i < currentOrder.PizzasOnOrder.Count; i++)
            {
                MenuOptions.Add($"{i + 2}. {currentOrder.PizzasOnOrder[i].Name}");
            }
        }

        public void ExecuteOption(int option)
        {
            if (option == 1)
            {
                MenuController.GoToPreviewOrderMenu();
            }
            else
            {
                //remove pizza
                currentOrder.PizzasOnOrder.Remove(currentOrder.PizzasOnOrder[option - 1]);
                MenuController.GoToPreviewOrderMenu();
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