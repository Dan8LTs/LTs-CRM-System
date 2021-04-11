using CrmBL.Models;
using System;
using System.Collections.Generic;

namespace BL.Models
{
    class Generator
    {
        readonly Random rnd = new Random();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Seller> Sellers { get; set; } = new List<Seller>();
        public List<Product> Products { get; set; } = new List<Product>();

        public List<Customer> GetNewCustomers(int count)
        {
            var result = new List<Customer>();
            for (int i = 0; i < count; i++)
            {
                var customer = new Customer()
                {
                    CustomerId = Customers.Count,
                    Name = GetText(),
                    Age = rnd.Next(14, 110)
                };
                Customers.Add(customer);
                result.Add(customer);
            }
            return result;
        }
        public List<Seller> GetNewSellers(int count)
        {
            var result = new List<Seller>();
            for (int i = 0; i < count; i++)
            {
                var seller = new Seller()
                {
                    SellerId = Sellers.Count,
                    Name = GetText()
                };
                Sellers.Add(seller);
                result.Add(seller);
            }
            return result;
        }

        public List<Product> GetNewProducts(int count)
        {
            var result = new List<Product>();
            for (int i = 0; i < count; i++)
            {
                var product = new Product()
                {
                    ProductId = Products.Count,
                    Name = GetText(),
                    Count = rnd.Next(5, 1000),
                    Price = Convert.ToDecimal(rnd.Next(1, 1000000) + rnd.NextDouble())
                };
                Products.Add(product);
                result.Add(product);
            }
            return result;
        }
        public List<Product> GetRandomProducts(int min, int max)
        {
            var result = new List<Product>();
            var count = rnd.Next(min, max);
            for (int i = 0; i < count; i++)
            {
                result.Add(Products[rnd.Next(Products.Count - 1)]);
            }
            return result;
        }
        private static string GetText()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }
    }
}
