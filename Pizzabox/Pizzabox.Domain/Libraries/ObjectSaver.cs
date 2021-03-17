using System;
using System.Linq;
using Pizzabox.Domain.Libraries.Models;
using Pizzabox.Storing.dbModels;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries
{
    public static class ObjSaver
    {
        public static string[] SendCustomerToMapper(ACustomer newCustomer)
        {
            return new string[] {newCustomer.FirstName, newCustomer.LastName};
        }

        public static void SaveOrder(AOrder newOrder)
        {
            string[] orderData = new string[] {"", "", ""};
            int orderID = DataAccessor.GetNumOrders();
            newOrder.CalculateOrderTotal();

            orderData[0] = newOrder.FulfillingStore.StoreNumber.ToString();
            orderData[1] = newOrder.customer.CustomerID.ToString();
            orderData[2] = newOrder.OrderTotal.ToString();
            DataAccessor.PersistOrder(orderData);


            int[] pizzaData = new int[] {0, 0, 0, 0, 0};
            int pizzaId;
            foreach (var pizza in newOrder.PizzasOnOrder)
            {
                pizzaId = DataAccessor.GetNumPizzas();
                DataAccessor.PersistPizzaHistory(orderID);
                foreach (var topping in pizza.Toppings)
                {
                    pizzaData[0] = pizza.Crust;
                    pizzaData[1] = pizza.Sauce;
                    pizzaData[2] = pizza.Size;
                    pizzaData[3] = pizzaId;
                    pizzaData[4] = topping;
                    DataAccessor.PersistPizzaJunction(pizzaData);
                }
            }
        }
    }
}