using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class Order
    {
        public int OrderTotal { get; private set; }
        public List<Pizza> PizzasOnOrder { get; set; }
        public Store FulfillingStore { get; set; }
    }
}