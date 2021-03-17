using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class AOrder
    {
        public AOrder()
        {
            PizzasOnOrder = new List<APizza>();
        }
        public float OrderTotal { get; private set; }
        public List<APizza> PizzasOnOrder { get; set; }
        public AStore FulfillingStore { get; set; }
        public ACustomer customer { get; set; }

        public void CalculateOrderTotal()
        {
            OrderTotal = 0;
            foreach (var pizza in PizzasOnOrder)
            {
                pizza.CalculatePrice();
                OrderTotal += pizza.Price;
            }
        }
    }
}