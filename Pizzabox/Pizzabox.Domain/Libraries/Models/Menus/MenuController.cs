using Pizzabox.Domain.IO;

namespace Pizzabox.Domain.Libraries.Models.Menus
{

    public static class MenuController
    {
        public static void GoToMainMenu()
        {
            MainMenu mainMenu = Factory.CreateMainMenu();
            mainMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, mainMenu.OptionRange);
            mainMenu.ExecuteOption(option);
        }

        public static void GoToNewOrderMenu()
        {
            NewOrderMenu newOrderMenu = Factory.CreateNewOrderMenu();
            newOrderMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, newOrderMenu.OptionRange);
            newOrderMenu.ExecuteOption(option);
        }

        public static void GoToPizzaSelectMenu()
        {
            PizzaSelectMenu pizzaSelectMenu = Factory.CreatePizzaSelectMenu();
            pizzaSelectMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, pizzaSelectMenu.OptionRange);
            pizzaSelectMenu.ExecuteOption(option);
        }

        public static void GoToBYOPizzaMenu()
        {
            BYOPizzaMenu byoPizzaMenu = Factory.CreateBYOPizzaMenu();
            byoPizzaMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, byoPizzaMenu.OptionRange);
            byoPizzaMenu.ExecuteOption(option);
        }

        public static void GoToAddPizzaItemMenu(int menu)
        {
            AddPizzaItemMenu addPizzaMenu = Factory.CreateAddPizzaItemMenu(menu);
            addPizzaMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, addPizzaMenu.OptionRange);
            addPizzaMenu.ExecuteOption(option);
        }

        public static void GoToPreviewOrderMenu()
        {
            PreviewOrderMenu previewOrderMenu = Factory.CreatePreviewOrderMenu();
            previewOrderMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, previewOrderMenu.OptionRange);
            previewOrderMenu.ExecuteOption(option);
        }

        public static void GoToRemoveItemMenu()
        {
            RemoveItemMenu removeItemMenu = Factory.CreateRemoveItemMenu();
            removeItemMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, removeItemMenu.OptionRange);
            removeItemMenu.ExecuteOption(option);
        }
    }
}