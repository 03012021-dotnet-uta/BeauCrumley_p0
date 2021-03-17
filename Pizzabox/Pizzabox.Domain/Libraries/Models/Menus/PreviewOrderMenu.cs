using System;
using System.Collections.Generic;
using Pizzabox.Domain.IO;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class PreviewOrderMenu
    {
        public PreviewOrderMenu(AOrder order)
        {
            currentOrder = order;
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Shopping Cart";
        public int[] OptionRange { get; set; } = {1, 0};
        public AOrder currentOrder { get; set; }

        public void SetOptions()
        {
            MenuOptions.Add("1. Go Back");
            MenuOptions.Add("2. Checkout");
            MenuOptions.Add("3. Remove Item");
        }

        public void ExecuteOption(int option)
        {
            switch (option)
            {
                case 1:
                    MenuController.GoToPizzaSelectMenu(currentOrder);
                    break;
                case 2:
                    currentOrder.CalculateOrderTotal();
                    if (currentOrder.OrderTotal > 250 || currentOrder.PizzasOnOrder.Count > 50)
                    {
                        Messenger.OrderError();
                    }
                    else
                    {
                        ObjSaver.SaveOrder(currentOrder);
                        Messenger.OrderPlacedMessage();
                        MenuController.GoToMainMenu(currentOrder.customer);
                    }
                    break;
                case 3:
                    MenuController.GoToRemoveItemMenu(currentOrder);
                    break;
            }
        }

        public void DisplayMenuOptions()
        {
            Messenger.StandardLineBreak();
            Console.WriteLine($"{Name}\n");
            DisplayOrder();
            Console.Write("\n");
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order from {currentOrder.FulfillingStore.Name} located at {currentOrder.FulfillingStore.Address}");
            currentOrder.CalculateOrderTotal();
            foreach (var pizza in currentOrder.PizzasOnOrder)
            {
                pizza.CalculatePrice();
                Console.Write($"{pizza.Name} - Price: ${pizza.Price} \n\tToppings: |");
                foreach (var topping in pizza.Toppings)
                {
                    Console.Write($" {DataAccessor.GetItemInfo(4, topping)[0]} |");
                }
                Console.Write($"\n\tCrust:    | {DataAccessor.GetItemInfo(1, pizza.Crust)[0]}");
                Console.Write($"\n\tSauce:    | {DataAccessor.GetItemInfo(2, pizza.Sauce)[0]}");
                Console.Write($"\n\tSize:     | {DataAccessor.GetItemInfo(3, pizza.Size)[0]}");
                Console.Write("\n\n");
            }
            Console.Write($"\n\tTotal:    | ${currentOrder.OrderTotal}");
            Console.Write("\n\n");
        }
    }
}