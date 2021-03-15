using System;
using System.Collections.Generic;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string OpperationHourStart { get; set; }
        public string OpperationHourEnd { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
