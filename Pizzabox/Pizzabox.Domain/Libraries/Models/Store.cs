using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class Store
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Order> OrdersFulfilled { get; private set; }
    }
}