using System;
using System.Collections.Generic;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class RemoveItemMenu
    {
        public RemoveItemMenu(AOrder order)
        {
            currentOrder = order;
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Select Item To Remove";
        public int[] OptionRange { get; set; } = {1, 0};
        public AOrder currentOrder { get; set; }

        public void SetOptions()
        {
            MenuOptions.Add("1. Go Back");
            Console.Write("\n");
            for (var i = 0; i < currentOrder.PizzasOnOrder.Count; i++)
            {
                currentOrder.PizzasOnOrder[i].CalculatePrice();
                MenuOptions.Add($"{i + 1}. {currentOrder.PizzasOnOrder[i].Name} - {currentOrder.PizzasOnOrder[i].Price}");
            }
        }

        public void ExecuteOption(int option)
        {
            if (option == 1)
            {
                MenuController.GoToPreviewOrderMenu(currentOrder);
            }
            else
            {
                //remove pizza
                currentOrder.PizzasOnOrder.Remove(currentOrder.PizzasOnOrder[option - 2]);
                MenuController.GoToPreviewOrderMenu(currentOrder);
            }
        }

        public void DisplayMenuOptions()
        {
            Console.WriteLine($"{Name}\n");
            Console.WriteLine(MenuOptions[0]);
            var i = 2;
            foreach (var pizza in currentOrder.PizzasOnOrder)
            {
                pizza.CalculatePrice();
                Console.Write($"{i}. {pizza.Name} - Price: ${pizza.Price} \n\tToppings: |");
                foreach (var topping in pizza.Toppings)
                {
                    Console.Write($" {DataAccessor.GetItemInfo(4, topping)[0]} |");
                }
                Console.Write($"\n\tCrust:    | {DataAccessor.GetItemInfo(1, pizza.Crust)[0]}");
                Console.Write($"\n\tSauce:    | {DataAccessor.GetItemInfo(2, pizza.Sauce)[0]}");
                Console.Write($"\n\tSize:     | {DataAccessor.GetItemInfo(3, pizza.Size)[0]}");
                Console.Write("\n\n");
                i++;
            }
        }
    }
}