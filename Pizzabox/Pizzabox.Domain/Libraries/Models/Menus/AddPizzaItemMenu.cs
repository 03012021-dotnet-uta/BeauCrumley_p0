using System;
using System.Collections.Generic;
using Pizzabox.Domain.IO;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class AddPizzaItemMenu
    {
        public AddPizzaItemMenu(AOrder order, APizza customPizza, int menu)
        {
            currentOrder = order;
            SubMenuType = menu;
            CustomPizza = customPizza;
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string[] Name { get; set; } = {"Select Crust", "Select Sauce", "Select Size", "Select Topping"};
        public int[] OptionRange { get; set; } = {1, 0};
        public AOrder currentOrder { get; set; }
        public int SubMenuType { get; set; }
        public APizza CustomPizza { get; set; }
        public List<List<string>> MenuData { get; set; }

        public void SetOptions()
        {
            MenuOptions.Add("1. Cancel");
            var i = 2;
            MenuData = DataAccessor.GetTableInfo(SubMenuType);
            foreach (var row in MenuData)
            {
                MenuOptions.Add($"{i}. {row[1]}");
                i++;
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
                switch (SubMenuType)
                {
                    case 1:
                        CustomPizza.Crust = int.Parse(MenuData[option - 2][0]);
                        break;
                    case 2:
                        CustomPizza.Sauce = int.Parse(MenuData[option - 2][0]);
                        break;
                    case 3:
                        CustomPizza.Size = int.Parse(MenuData[option - 2][0]);
                        break;
                    case 4:
                        if (CustomPizza.Toppings.Count < 5)
                        {
                            CustomPizza.Toppings.Add(int.Parse(MenuData[option - 2][0]));
                        }
                        else
                        {
                            Messenger.ToppingError();
                        }
                        break;
                }
                MenuController.GoToBYOPizzaMenu(currentOrder, CustomPizza);
            }
        }

        public void DisplayMenuOptions()
        {
            Messenger.StandardLineBreak();
            Console.WriteLine($"{Name[SubMenuType - 1]}\n");
            foreach (var option in MenuOptions)
            {
                Console.WriteLine(option);
            }
        }
    }
}