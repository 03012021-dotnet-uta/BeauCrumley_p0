using System;
using System.Collections.Generic;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class Topping
    {
        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal ToppingPrice { get; set; }
    }
}
