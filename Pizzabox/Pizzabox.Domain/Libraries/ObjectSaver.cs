using System;
using System.Linq;
using Pizzabox.Domain.Libraries.Models;
using Pizzabox.Storing.dbModels;

namespace Pizzabox.Domain.Libraries
{
    public static class ObjSaver
    {
        public static string[] SendCustomerToMapper(ACustomer newCustomer)
        {
            return new string[] {newCustomer.FirstName, newCustomer.LastName};            
        }
    }
}