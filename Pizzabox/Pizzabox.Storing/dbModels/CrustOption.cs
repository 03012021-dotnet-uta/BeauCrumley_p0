using System;
using System.Collections.Generic;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class CrustOption
    {
        public int CrustId { get; set; }
        public string CrustOptionName { get; set; }
        public decimal CrustOptionPrice { get; set; }
    }
}
