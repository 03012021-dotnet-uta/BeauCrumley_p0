using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public float Price { get; private set; }
        public int Crust { get; set; }
        public int Sauce { get; set; }
        public int Size { get; set; }
        public List<int> Toppings { get; set; }

    }
}