using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class Order
    {
        public int OrderTotal { get; private set; }
        public List<Pizza> PizzasOnOrder { get; set; }
        public AStore FulfillingStore { get; set; }
        public ACustomer customer { get; set; }
    }
}