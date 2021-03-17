
using System.Collections.Generic;

namespace Pizzabox.Storing.Repositories
{
    public class PizzaData
    {
        //public List<string> Options { get; set; }
        //public List<string> Toppings { get; set; }
        
        public string Name { get; set; }
        public int Crust { get; set; }
        public int Sauce { get; set; }
        public int Size { get; set; }
        public List<int> Toppings { get; set; } = new List<int>();


    }
}