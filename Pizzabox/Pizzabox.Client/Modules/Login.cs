using Pizzabox.Domain.IO;
using Pizzabox.Domain.Libraries;
using Pizzabox.Domain.Libraries.Models;

namespace Pizzabox.Client.Modules
{
    public static class Login
    {
        public static ACustomer GetCustomer()
        {
            Messenger.FirstNamePropmt();
            string firstName = InputReader.GetInput().ToLower();

            Messenger.LastNamePropmt();
            string lastName = InputReader.GetInput().ToLower();

            ACustomer newCustomer = Factory.CreateCustomer(firstName, lastName);
            return newCustomer;
        }
    }
}