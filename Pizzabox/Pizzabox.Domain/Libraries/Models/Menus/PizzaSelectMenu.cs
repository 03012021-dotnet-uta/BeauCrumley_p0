using System;
using System.Collections.Generic;
using Pizzabox.Domain.IO;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models.Menus
{
    public class PizzaSelectMenu
    {
        public PizzaSelectMenu(AOrder order)
        {
            currentOrder = order;
            SetOptions();
            OptionRange[1] = MenuOptions.Count;
        }

        public List<string> MenuOptions { get; set; } = new List<string>();
        public string Name { get; set; } = "Select Pizza";
        public int[] OptionRange { get; set; } = {1, 0};
        public List<APizza> PizzaList { get; set; } = new List<APizza>();
        public AOrder currentOrder { get; set; }

        public void SetOptions()
        {
            MenuOptions.Add("1. Cancel");
            MenuOptions.Add("2. Preview Order");
            MenuOptions.Add("3. Build Your Own");
            var i = 3;
            var pizzaList = DataAccessor.GetPresetPizzas();
            foreach (var pizzaID in pizzaList)
            {
                i++;
                APizza newPizza = Factory.CreateAPizza();
                newPizza.BuildPizzaFromData(DataAccessor.CreatePresetPizza(pizzaID));
                PizzaList.Add(newPizza);
                MenuOptions.Add($"{i}. {newPizza.Name}");
            }
        }

        public void ExecuteOption(int option)
        {
            if (option == 1)
            {
                MenuController.GoToMainMenu(currentOrder.customer);
            }
            else if (option == 2)
            {
                MenuController.GoToPreviewOrderMenu(currentOrder);
            }
            else if (option == 3)
            {
                MenuController.GoToBYOPizzaMenu(currentOrder);
            }
            else
            {
                Console.WriteLine("Select Size\n\n1. Personal\n2. Small\n3. Medium\n4. Large\n5. Mighty Mark");
                var sizeInput = InputReader.ValidateInput(InputReader.GetInput(), new int[] {1, 5});
                PizzaList[option - 4].Size = sizeInput;


                Console.WriteLine($"Adding {PizzaList[option - 4].Name} to order. . .");
                currentOrder.PizzasOnOrder.Add(PizzaList[option - 4]);
                MenuController.GoToPizzaSelectMenu(currentOrder);
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