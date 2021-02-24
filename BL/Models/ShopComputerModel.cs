using CrmBL.Models;
using System;
using System.Collections.Generic;

namespace BL.Models
{
    public class ShopComputerModel
    {
        readonly Generator generator = new Generator();
        readonly Random rnd = new Random();
        public List<CashDesk> CashDesks { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Check> Checks { get; set; }
        public List<Sell> Sells { get; set; }
        public Queue<Seller> Sellers { get; set; }
        public ShopComputerModel()
        {
            var sellers = generator.GetNewSellers(20);
            foreach(var seller in sellers)
            {
                Sellers.Enqueue(seller);
            }
            for(int i = 0; i < 3; i++)
            {
                CashDesks.Add(new CashDesk(CashDesks.Count, Sellers.Dequeue()));
            }
        }
        public void Start()
        {
            var customers = generator.GetNewCustomers(10);
            var carts = new List<Cart>();
            foreach(var customer in customers)
            {
                var cart = new Cart(customer);
                foreach(var product in generator.GetRandomProducts(10, 30))
                {
                    cart.Add(product);
                }
                carts.Add(cart);
            }
            
            foreach (var cart in carts)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cash.Enqueue(cart);
                carts.Remove(cart);
            }

            while (true)
            {
                var cash = CashDesks[rnd.Next(CashDesks.Count - 1)];
                cash.Dequeue();
            }
        }
    }
}
