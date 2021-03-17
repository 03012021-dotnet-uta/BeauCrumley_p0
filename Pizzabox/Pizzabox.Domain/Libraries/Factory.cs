using Pizzabox.Domain.Libraries.Models;
using Pizzabox.Domain.Libraries.Models.Menus;

namespace Pizzabox.Domain.Libraries
{
    public static class Factory
    {
        public static MainMenu CreateMainMenu(ACustomer cust)
        {
            return new MainMenu(cust);
        }
        public static NewOrderMenu CreateNewOrderMenu(ACustomer cust)
        {
            return new NewOrderMenu(cust);
        }
        public static PizzaSelectMenu CreatePizzaSelectMenu(AOrder order)
        {
            return new PizzaSelectMenu(order);
        }
        public static BYOPizzaMenu CreateBYOPizzaMenu(AOrder order)
        {
            return new BYOPizzaMenu(order);
        }
        public static BYOPizzaMenu CreateBYOPizzaMenu(AOrder order, APizza pizza)
        {
            return new BYOPizzaMenu(order, pizza);
        }
        public static AddPizzaItemMenu CreateAddPizzaItemMenu(AOrder order, APizza pizza, int menu)
        {
            return new AddPizzaItemMenu(order, pizza, menu);
        }
        public static PreviewOrderMenu CreatePreviewOrderMenu(AOrder order)
        {
            return new PreviewOrderMenu(order);
        }
        public static RemoveItemMenu CreateRemoveItemMenu(AOrder order)
        {
            return new RemoveItemMenu(order);
        }
        public static AOrder CreateOrder()
        {
            return new AOrder();
        }
        public static AStore CreateStore(int storeID, string name, string address, string[] hours)
        {
            return new AStore(storeID, name, address, hours);
        }
        public static ACustomer CreateCustomer(string firstname, string lastname)
        {
            return new ACustomer(firstname, lastname);
        }
        public static APizza CreateAPizza()
        {
            return new APizza();
        }
    }
}