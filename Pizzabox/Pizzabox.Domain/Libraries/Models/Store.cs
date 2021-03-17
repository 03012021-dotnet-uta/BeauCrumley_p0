using System.Collections.Generic;

namespace Pizzabox.Domain.Libraries.Models
{
    public class AStore
    {
        public AStore(int storeID, string name, string address, string[] hours)
        {
            StoreNumber = storeID;
            Name = name;
            Address = address;
            HoursStart = hours[0];
            HoursEnd = hours[1];
            OrdersFulfilled = GetListOfOrders();
        }
        public int StoreNumber { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string HoursStart { get; set; }
        public string HoursEnd { get; set; }
        public List<AOrder> OrdersFulfilled { get; private set; }

        private List<AOrder> GetListOfOrders()
        {
            List<AOrder> orderList = new List<AOrder>();
            // db context logic to get orders
            return orderList;
        }
    }
}