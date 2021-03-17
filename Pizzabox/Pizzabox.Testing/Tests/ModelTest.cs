using Pizzabox.Domain.IO;
using Pizzabox.Domain.Libraries;
using Pizzabox.Domain.Libraries.Models;
using Pizzabox.Domain.Libraries.Models.Menus;
using Xunit;

namespace Pizzabox.Testing.Tests
{
    public class ModelTest
    {
        [Fact]
        public void TestBuildingOrder()
        {
            AOrder expected = new AOrder();

            AOrder actual = Factory.CreateOrder();

            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void TestBuildingStore()
        {
            AStore expected = new AStore(1, "test", "test", new string[] {"11a", "11p"});

            AStore actual = Factory.CreateStore(1, "test", "test", new string[] {"11a", "11p"});

            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void TestBuildingCustomer()
        {
            ACustomer expected = new ACustomer("test", "test");

            ACustomer actual = Factory.CreateCustomer("test", "test");

            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void TestBuildingPizza()
        {
            APizza expected = new APizza();

            APizza actual = Factory.CreateAPizza();

            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void TestBuildingMainMenu()
        {
            ACustomer testCust = new ACustomer("test", "test");
            MainMenu expected = new MainMenu(testCust);

            MainMenu actual = Factory.CreateMainMenu(testCust);

            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void TestBuildingNewOrderMenu()
        {
            ACustomer testCust = new ACustomer("test", "test");
            NewOrderMenu expected = new NewOrderMenu(testCust);

            NewOrderMenu actual = Factory.CreateNewOrderMenu(testCust);

            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void TestBuildingOrderPreviewMenu()
        {
            AOrder testOrder = new AOrder();
            PreviewOrderMenu expected = new PreviewOrderMenu(testOrder);

            PreviewOrderMenu actual = Factory.CreatePreviewOrderMenu(testOrder);

            Assert.True(expected.Equals(actual));
        }
        [Fact]
        public void TestBuildingBYOPizzaMenu()
        {
            AOrder testOrder = new AOrder();
            BYOPizzaMenu expected = new BYOPizzaMenu(testOrder);

            BYOPizzaMenu actual = Factory.CreateBYOPizzaMenu(testOrder);

            Assert.True(expected.Equals(actual));
        }
    }
}