using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Order> OrdersPlaced { get; private set; }
    }
}