using System.Collections.Generic;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models
{
    public class APizza
    {
        public string Name { get; set; }
        public float Price { get; private set; }
        public int Crust { get; set; }
        public int Sauce { get; set; }
        public int Size { get; set; }
        public List<int> Toppings { get; set; } = new List<int>();


        public void BuildPizzaFromData(PizzaData data)
        {
            Name = data.Name;
            Crust = data.Crust;
            Sauce = data.Sauce;
            Size = data.Size;
            Toppings = data.Toppings;
        }

        public void CalculatePrice()
        {
            Price = 0;
            Price += float.Parse(DataAccessor.GetItemInfo(1, Crust)[1]);
            Price += float.Parse(DataAccessor.GetItemInfo(3, Size)[1]);
            foreach (var topping in Toppings)
            {
                Price += float.Parse(DataAccessor.GetItemInfo(4, topping)[1]);
            }
        }
    }
}