using Pizzabox.Domain.IO;

namespace Pizzabox.Domain.Libraries.Models.Menus
{

    public static class MenuController
    {
        public static void GoToMainMenu(ACustomer cust)
        {
            MainMenu mainMenu = Factory.CreateMainMenu(cust);
            mainMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, mainMenu.OptionRange);
            mainMenu.ExecuteOption(option);
        }

        public static void GoToNewOrderMenu(ACustomer cust)
        {
            NewOrderMenu newOrderMenu = Factory.CreateNewOrderMenu(cust);
            newOrderMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, newOrderMenu.OptionRange);
            newOrderMenu.ExecuteOption(option);
        }

        public static void GoToPizzaSelectMenu(AOrder order)
        {
            PizzaSelectMenu pizzaSelectMenu = Factory.CreatePizzaSelectMenu(order);
            pizzaSelectMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, pizzaSelectMenu.OptionRange);
            pizzaSelectMenu.ExecuteOption(option);
        }

        public static void GoToBYOPizzaMenu(AOrder order)
        {
            BYOPizzaMenu byoPizzaMenu = Factory.CreateBYOPizzaMenu(order);
            byoPizzaMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, byoPizzaMenu.OptionRange);
            byoPizzaMenu.ExecuteOption(option);
        }
        public static void GoToBYOPizzaMenu(AOrder order, APizza pizza)
        {
            BYOPizzaMenu byoPizzaMenu = Factory.CreateBYOPizzaMenu(order, pizza);
            byoPizzaMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, byoPizzaMenu.OptionRange);
            byoPizzaMenu.ExecuteOption(option);
        }

        public static void GoToAddPizzaItemMenu(AOrder order, APizza pizza, int menu)
        {
            AddPizzaItemMenu addPizzaMenu = Factory.CreateAddPizzaItemMenu(order, pizza, menu);
            addPizzaMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, addPizzaMenu.OptionRange);
            addPizzaMenu.ExecuteOption(option);
        }

        public static void GoToPreviewOrderMenu(AOrder order)
        {
            PreviewOrderMenu previewOrderMenu = Factory.CreatePreviewOrderMenu(order);
            previewOrderMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, previewOrderMenu.OptionRange);
            previewOrderMenu.ExecuteOption(option);
        }

        public static void GoToRemoveItemMenu(AOrder order)
        {
            RemoveItemMenu removeItemMenu = Factory.CreateRemoveItemMenu(order);
            removeItemMenu.DisplayMenuOptions();

            var input = InputReader.GetInput();

            var option = InputReader.ValidateInput(input, removeItemMenu.OptionRange);
            removeItemMenu.ExecuteOption(option);
        }
    }
}