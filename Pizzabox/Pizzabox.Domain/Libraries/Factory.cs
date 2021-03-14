using Pizzabox.Domain.Libraries.Models;
using Pizzabox.Domain.Libraries.Models.Menus;

namespace Pizzabox.Domain.Libraries
{
    public static class Factory
    {
        public static MainMenu CreateMainMenu()
        {
            return new MainMenu();
        }
        public static NewOrderMenu CreateNewOrderMenu()
        {
            return new NewOrderMenu();
        }
        public static PizzaSelectMenu CreatePizzaSelectMenu()
        {
            return new PizzaSelectMenu();
        }
        public static BYOPizzaMenu CreateBYOPizzaMenu()
        {
            return new BYOPizzaMenu();
        }
        public static AddPizzaItemMenu CreateAddPizzaItemMenu(int menu)
        {
            return new AddPizzaItemMenu(menu);
        }
        public static PreviewOrderMenu CreatePreviewOrderMenu()
        {
            return new PreviewOrderMenu();
        }
        public static RemoveItemMenu CreateRemoveItemMenu()
        {
            return new RemoveItemMenu();
        }
        public static Order CreateOrder()
        {
            return new Order();
        }
        public static Store CreateStore()
        {
            return new Store();
        }
    }
}