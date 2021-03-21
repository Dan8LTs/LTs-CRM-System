using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrmBL.Models;

namespace BL.Models.Tests
{
    [TestClass()]
    public class CashDeskTests
    {
        [TestMethod()]
        public void CashDeskTest()
        {
            // arrange
            var customer1 = GetCustomer("userName", 42, 1);
            var customer2 = GetCustomer("userName", 42, 1);
            var customer3 = GetCustomer("userName2", 54, 2);

            var seller = new Seller()
            {
                Name = "sellerName",
                SellerId = 1
            };

            var product = new Product()
            {
                ProductId = 1,
                Name = "prod1",
                Price = 1000,
                Count = 10
            };

            var product2 = new Product()
            {
                ProductId = 2,
                Name = "prod2",
                Price = 500,
                Count = 20
            };

            var cart1 = new Cart(customer1)
            {
                product,
                product,
                product2
            };

            var cart2 = new Cart(customer2)
            {
                product,
                product2,
                product2
            };

            var cart3 = new Cart(customer3)
            {
                product2,
                product2,
                product2
            };

            var cashdesk = new CashDesk(1, seller, null)
            {
                MaxQueueLenght = 10
            };
            cashdesk.Enqueue(cart1);
            cashdesk.Enqueue(cart2);
            cashdesk.Enqueue(cart3);

            var cart1ExpectedResult = 2500;
            var cart2ExpectedResult = 2000;
            var cart3ExpectedResult = 1500;

            // act
            var cart1ActualResult = cashdesk.Dequeue();
            var cart2ActualResult = cashdesk.Dequeue();
            var cart3ActualResult = cashdesk.Dequeue();

            // assert
            Assert.AreEqual(cart1ExpectedResult, cart1ActualResult);
            Assert.AreEqual(cart2ExpectedResult, cart2ActualResult);
            Assert.AreEqual(cart3ExpectedResult, cart3ActualResult);
            Assert.AreEqual(7, product.Count);
            Assert.AreEqual(14, product2.Count);
        }

        private static Customer GetCustomer(string name, int age, int id)
        {
            return new Customer()
            {
                Name = name,
                Age = age,
                CustomerId = id
            };
        }
    }
}