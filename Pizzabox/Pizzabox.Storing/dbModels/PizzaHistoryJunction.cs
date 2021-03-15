using System;
using System.Collections.Generic;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class PizzaHistoryJunction
    {
        public int? PizzaId { get; set; }
        public int? CrustId { get; set; }
        public int? SauceId { get; set; }
        public int? SizeId { get; set; }
        public int? ToppingId { get; set; }

        public virtual CrustOption Crust { get; set; }
        public virtual PizzaHistory Pizza { get; set; }
        public virtual SauceOption Sauce { get; set; }
        public virtual SizeOption Size { get; set; }
        public virtual Topping Topping { get; set; }
    }
}
