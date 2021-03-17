using System.Collections.Generic;
using Pizzabox.Storing.Repositories;

namespace Pizzabox.Domain.Libraries.Models
{
    public class ACustomer
    {
        public ACustomer(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
            CustomerID = DataAccessor.GetCustID(FirstName, LastName);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerID { get; set; }
        public List<AOrder> OrdersPlaced { get; private set; }
    }
}