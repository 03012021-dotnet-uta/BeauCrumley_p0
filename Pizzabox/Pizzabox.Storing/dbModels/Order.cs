using System;
using System.Collections.Generic;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class Order
    {
        public Order()
        {
            PizzaHistories = new HashSet<PizzaHistory>();
        }

        public int OrderId { get; set; }
        public int? FulfillingStore { get; set; }
        public int? Customer { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalSale { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Store FulfillingStoreNavigation { get; set; }
        public virtual ICollection<PizzaHistory> PizzaHistories { get; set; }
    }
}
