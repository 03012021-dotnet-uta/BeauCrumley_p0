using System;
using System.Collections.Generic;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class PizzaHistory
    {
        public int PizzaId { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
