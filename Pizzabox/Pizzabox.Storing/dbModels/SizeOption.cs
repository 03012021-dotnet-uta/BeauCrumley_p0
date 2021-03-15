using System;
using System.Collections.Generic;

#nullable disable

namespace Pizzabox.Storing.dbModels
{
    public partial class SizeOption
    {
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal SizePrice { get; set; }
    }
}
