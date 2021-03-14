using System;
using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class MainMenu
    {
        public MainMenu()
        {
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Main Menu";
        public int[] OptionRange { get; set; } = {1, 0};

        public void SetOptions()
        {
            MenuOptions.Add("1. Start New Order");
            MenuOptions.Add("2. View Order History");
            MenuOptions.Add("3. Exit");
        }

        public void ExecuteOption(int option)
        {
            switch (option)
            {
                case 1:
                    //start new order
                    MenuController.GoToNewOrderMenu();
                    break;
                case 2:
                    //view order history
                    Console.WriteLine("Order History");
                    Console.WriteLine("I am the order history, look at me!");
                    Console.WriteLine("\nPress any key to continue. . .");
                    Console.Read();
                    MenuController.GoToMainMenu();
                    break;
                case 3:
                    //exit application
                    Console.WriteLine("Exit. . .");
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