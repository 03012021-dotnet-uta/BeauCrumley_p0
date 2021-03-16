using System;
using System.Linq;
using Pizzabox.Storing.dbModels;
using Pizzabox.Domain.Libraries.Models;
using System.Collections.Generic;
using Pizzabox.Domain.Libraries;

namespace Pizzabox.Storing.Repositories
{
    public class DataAccessor
    {
        public void PersistCustomer(ACustomer newCustomer)
        {
            using (var db = new PizzaboxDBContext())
            {
                // logic to check if customer already exists goes here
                db.Add(new Customer { FirstName = newCustomer.FirstName, LastName = newCustomer.LastName });
                db.SaveChanges();
            }
        }
        public List<AStore> GetStores()
        {
            using (var db = new PizzaboxDBContext())
            {
                List<AStore> storeList = new List<AStore>();
                foreach (var store in db.Stores)
                {
                    Factory.CreateStore(store.StoreId, store.StoreName, store.StoreAddress, new string[] {store.OpperationHourStart, store.OpperationHourEnd});
                }
                return storeList;
            }
        }
    }
}
// Note: This sample requires the database to be created before running.
/*
// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();
*/
/*
// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();
*/