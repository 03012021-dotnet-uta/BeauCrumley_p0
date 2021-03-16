using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class ACustomer
    {
        public ACustomer(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Order> OrdersPlaced { get; private set; }
    }
}