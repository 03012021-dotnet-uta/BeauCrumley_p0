using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pizzabox.Storing.dbModels;

namespace Pizzabox.Storing.Repositories
{
    public static class DataAccessor
    {
        public static void PersistCustomer(string[] name)
        {
            using (var db = new PizzaboxDBContext())
            {
                var custTableData = db.Customers.FromSqlRaw($"SELECT * FROM Customers WHERE FirstName = '{name[0]}' AND LastName = '{name[1]}';").ToList();
                if (custTableData.Count == 0)
                {
                    db.Add(new Customer { FirstName = name[0].ToLower(), LastName = name[1].ToLower() });
                    db.SaveChanges();
                }
            }
        }
        public static void PersistOrder(string[] data)
        {
            using (var db = new PizzaboxDBContext())
            {
                DateTime newDate = new DateTime();
                newDate = DateTime.Now;
                db.Add(new Order { FulfillingStore = int.Parse(data[0]), Customer = int.Parse(data[1]), OrderDate = newDate, TotalSale = decimal.Parse(data[2]) });
                db.SaveChanges();
            }
        }
        public static void PersistPizzaHistory(int orderNum)
        {
            using (var db = new PizzaboxDBContext())
            {
                db.Add(new PizzaHistory { OrderId = orderNum });
                db.SaveChanges();
            }
        }
        public static void PersistPizzaJunction(int[] options)
        {
            /*using (var db = new PizzaboxDBContext())// need to set up database so that pizza history junction has PK so EF can track it :D
            {
                db.Add(new PizzaHistoryJunction { PizzaId = options[0], CrustId = options[1], SauceId = options[2], SizeId = options[3], ToppingId = options[4] });
                db.SaveChanges();
            }
            */
        }
        public static List<string[]> GetStores()
        {
            using (var db = new PizzaboxDBContext())
            {
                List<string[]> storeList = new List<string[]>();
                foreach (var store in db.Stores)
                {
                    storeList.Add(new string[] {store.StoreId.ToString(), store.StoreName, store.StoreAddress, store.OpperationHourStart, store.OpperationHourEnd});
                }
                return storeList;
            }
        }

        public static List<int> GetPresetPizzas()
        {
            using (var db = new PizzaboxDBContext())
            {
                var presetPizzas = db.PresetPizzas.FromSqlRaw("SELECT * FROM PresetPizzas").ToList();

                List<int> pizzaList = new List<int>();
                foreach (var pizza in presetPizzas)
                {
                    pizzaList.Add(pizza.PizzaId);
                }

                return pizzaList; // return set of data to build pizza objects
            }
        }

        public static PizzaData CreatePresetPizza(int PizzaID)
        {
            using (var db = new PizzaboxDBContext())
            {
                PizzaData newPizza = new PizzaData();
                var junction = db.PresetPizzaJunctions.FromSqlRaw($"SELECT * FROM PresetPizzaJunction WHERE PizzaID = {PizzaID};").ToList();
                var pizzaName = db.PresetPizzas.FromSqlRaw($"SELECT * FROM PresetPizzas WHERE PizzaID = {PizzaID};").ToList();
                newPizza.Name = pizzaName[0].PizzaName;
                newPizza.Crust = junction[0].CrustId ?? default(int);
                newPizza.Sauce = junction[0].SauceId ?? default(int);
                newPizza.Size = junction[0].SizeId ?? default(int);
                foreach (var topping in junction)
                {
                    int newTopping;
                    newTopping = topping.ToppingId ?? default(int);
                    newPizza.Toppings.Add(newTopping);
                }
                return newPizza;
            }
        }
        public static List<string> GetItemInfo(int table, int itemID)
        {
            using (var db = new PizzaboxDBContext())
            {
                List<string> info = new List<string>();
                switch (table)
                {
                    case 1://crust
                        var tableData = db.CrustOptions.FromSqlRaw($"SELECT * FROM CrustOptions WHERE CrustID = {itemID};").ToList();
                        if (tableData.Count > 0)
                        {
                            info.Add(tableData[0].CrustOptionName);
                            info.Add(tableData[0].CrustOptionPrice.ToString());
                        }
                        break;
                    case 2://sauce
                        var tableData2 = db.SauceOptions.FromSqlRaw($"SELECT * FROM SauceOptions WHERE SauceID = {itemID};").ToList();
                        if (tableData2.Count > 0)
                        {
                            info.Add(tableData2[0].SauceOptionName);
                        }
                        break;
                    case 3://size
                        var tableData3 = db.SizeOptions.FromSqlRaw($"SELECT * FROM SizeOptions WHERE SizeID = {itemID};").ToList();
                        if (tableData3.Count > 0)
                        {
                            info.Add(tableData3[0].SizeName);
                            info.Add(tableData3[0].SizePrice.ToString());
                        }
                        break;
                    case 4://topping
                        var tableData4 = db.Toppings.FromSqlRaw($"SELECT * FROM Toppings WHERE ToppingID = {itemID};").ToList();
                        if (tableData4.Count > 0)
                        {
                            info.Add(tableData4[0].ToppingName);
                            info.Add(tableData4[0].ToppingPrice.ToString());
                        }
                        break;
                }
                if (info.Count > 0)
                {
                    return info;
                } 
                else
                {
                    info.Add("None");
                    return info;
                }
            }
        }
        public static List<List<string>> GetTableInfo(int table)
        {
            using (var db = new PizzaboxDBContext())
            {
                List<List<string>> info = new List<List<string>>();
                var i = 0;
                switch (table)
                {
                    case 1://crust
                        var tableData = db.CrustOptions.FromSqlRaw($"SELECT * FROM CrustOptions;").ToList();
                        foreach (var item in tableData)
                        {
                            info.Add(new List<string>());
                            info[i].Add(item.CrustId.ToString());
                            info[i].Add(item.CrustOptionName);
                            info[i].Add(item.CrustOptionPrice.ToString());
                            i++;
                        }
                        break;
                    case 2://sauce
                        var tableData2 = db.SauceOptions.FromSqlRaw($"SELECT * FROM SauceOptions;").ToList();
                        foreach (var item in tableData2)
                        {
                            info.Add(new List<string>());
                            info[i].Add(item.SauceId.ToString());
                            info[i].Add(item.SauceOptionName);
                            info[i].Add(item.SauceId.ToString());
                            i++;
                        }
                        break;
                    case 3://size
                        var tableData3 = db.SizeOptions.FromSqlRaw($"SELECT * FROM SizeOptions;").ToList();
                        foreach (var item in tableData3)
                        {
                            info.Add(new List<string>());
                            info[i].Add(item.SizeId.ToString());
                            info[i].Add(item.SizeName);
                            info[i].Add(item.SizePrice.ToString());
                            i++;
                        }
                        break;
                    case 4://topping
                        var tableData4 = db.Toppings.FromSqlRaw($"SELECT * FROM Toppings;").ToList();
                        foreach (var item in tableData4)
                        {
                            info.Add(new List<string>());
                            info[i].Add(item.ToppingId.ToString());
                            info[i].Add(item.ToppingName);
                            info[i].Add(item.ToppingPrice.ToString());
                            i++;
                        }
                        break;
                }
                return info;
            }
        }
        public static int GetNumCustomers()
        {
            using (var db = new PizzaboxDBContext())
            {
                var custTableData = db.Customers.FromSqlRaw("SELECT * FROM Customers").ToList();
                return custTableData.Count + 1;
            }
        }
        public static int GetNumOrders()
        {
            using (var db = new PizzaboxDBContext())
            {
                var orderTableData = db.Orders.FromSqlRaw("SELECT * FROM Orders").ToList();
                return orderTableData.Count + 1;
            }
        }
        public static int GetNumPizzas()
        {
            using (var db = new PizzaboxDBContext())
            {
                var pizzaTableData = db.PizzaHistories.FromSqlRaw("SELECT * FROM PizzaHistory").ToList();
                return pizzaTableData.Count + 1;
            }
        }
        public static int GetCustID(string fname, string lname)
        {
            using (var db = new PizzaboxDBContext())
            {
                var custTableData = db.Customers.FromSqlRaw($"SELECT * FROM Customers WHERE FirstName = '{fname}' AND LastName = '{lname}';").ToList();
                if (custTableData.Count > 0)
                {
                    return custTableData[0].CustomerId;
                }
                else
                {
                    return GetNumCustomers();
                }
            }
        }
    }
}