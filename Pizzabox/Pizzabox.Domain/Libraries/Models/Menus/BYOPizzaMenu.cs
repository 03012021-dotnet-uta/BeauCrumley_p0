using System;
using System.Collections.Generic;
using Pizzabox.Domain.IO;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class BYOPizzaMenu
    {
        public BYOPizzaMenu(AOrder order)
        {
            currentOrder = order;
            customPizza = Factory.CreateAPizza();
            customPizza.Name = "Custom Pizza";
            customPizza.Toppings.Add(1);
            customPizza.Toppings.Add(5);
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }
        public BYOPizzaMenu(AOrder order, APizza pizza)
        {
            currentOrder = order;
            customPizza = pizza;
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Customize your pizza!";
        public int[] OptionRange { get; set; } = {1, 0};
        public AOrder currentOrder { get; set; }
        public APizza customPizza { get; set; }

        public void SetOptions()
        {
                        
            MenuOptions.Add("1. Cancel");
            MenuOptions.Add("2. Add To Order");
            MenuOptions.Add($"3. Select Crust - {DataAccessor.GetItemInfo(1, customPizza.Crust)[0]}");
            MenuOptions.Add($"4. Select Sauce - {DataAccessor.GetItemInfo(2, customPizza.Sauce)[0]}");
            MenuOptions.Add($"5. Select Size - {DataAccessor.GetItemInfo(3, customPizza.Size)[0]}");
            string toppingsString = "| ";
            foreach (var topping in customPizza.Toppings)
            {
                toppingsString += $"{DataAccessor.GetItemInfo(4, topping)[0]} | ";
            }
            MenuOptions.Add("6. Select Toppings - " + toppingsString);
        }

        public void ExecuteOption(int option)
        {
            switch (option)
            {
                case 1:
                    MenuController.GoToMainMenu(currentOrder.customer);
                    break;
                case 2:
                    if (customPizza.Crust == 0 || customPizza.Sauce == 0 || customPizza.Size == 0)
                    {
                        Messenger.CustomPizzaError();
                        MenuController.GoToBYOPizzaMenu(currentOrder, customPizza);
                    }
                    else
                    {
                        currentOrder.PizzasOnOrder.Add(customPizza);
                        MenuController.GoToPizzaSelectMenu(currentOrder);
                    }
                    break;
                case 3:
                    MenuController.GoToAddPizzaItemMenu(currentOrder, customPizza, 1);
                    break;
                case 4:
                    MenuController.GoToAddPizzaItemMenu(currentOrder, customPizza, 2);
                    break;
                case 5:
                    MenuController.GoToAddPizzaItemMenu(currentOrder, customPizza, 3);
                    break;
                case 6:
                    MenuController.GoToAddPizzaItemMenu(currentOrder, customPizza, 4);
                    break;
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