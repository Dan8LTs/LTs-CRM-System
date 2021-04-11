using CrmBL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BL.Models.Tests
{
    [TestClass()]
    public class CartTests
    {
        [TestMethod()]
        public void CartTest()
        {
            // arrange
            var customer = new Customer()
            {
                CustomerId = 1,
                Name = "user",
                Age = 50
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
                Price = 534,
                Count = 13
            };
            var cart = new Cart(customer);

            var expectedResult = new List<Product>()
            {
                product, product, product2
            };

            // act
            cart.Add(product);
            cart.Add(product);
            cart.Add(product2);

            var cartResult = cart.GetAll();
            // assert
            Assert.AreEqual(expectedResult.Count, cart.GetAll().Count);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i], cartResult[i]);
            }
        }
    }
}