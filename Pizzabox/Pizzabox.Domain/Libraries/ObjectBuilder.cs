using System;
using System.Collections.Generic;
using System.Linq;
using Pizzabox.Domain.Libraries.Models;
//using Pizzabox.Storing.dbModels;

namespace Pizzabox.Domain.Libraries
{
    public static class ObjBuilder
    {
        public static List<AStore> BuildStores(List<string[]> storeData)
        {
            List<AStore> storeList = new List<AStore>();
            foreach (var store in storeData)
            {
                storeList.Add(Factory.CreateStore(int.Parse(store[0]), store[1], store[2], new string[] {store[3], store[4]}));
            }
            return storeList;
        }
    }
}