using System;
using System.Collections.Generic;
using System.Linq;
using Pizzabox.Storing.dbModels;

namespace Pizzabox.Storing.Repositories
{
    public static class DataAccessor
    {
        public static void PersistCustomer(string[] name)
        {
            using (var db = new PizzaboxDBContext())
            {
                // logic to check if customer already exists goes here
                db.Add(new Customer { FirstName = name[0].ToLower(), LastName = name[1].ToLower() });
                db.SaveChanges();
            }
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