﻿using CrmBL.Models;
using System;
using System.Collections.Generic;

namespace BL.Models
{
    public class CashDesk
    {
        CrmContext LTsCrmDB;

        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Carts { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public int Count => Carts.Count;

        public event EventHandler<Check> CheckClosed;
        public CashDesk(int number, Seller seller, CrmContext LTsCrmDB)
        {
            Number = number;
            Seller = seller;
            Carts = new Queue<Cart>();
            IsModel = true;
            MaxQueueLenght = 10;
            this.LTsCrmDB = LTsCrmDB ?? new CrmContext();
        }
        public void Enqueue(Cart cart)
        {
            if (Carts.Count < MaxQueueLenght)
            {
                Carts.Enqueue(cart);
            }
            else
            {
                ExitCustomer++;
            }
        }
        public decimal Dequeue()
        {
            decimal sum = 0;
            if (Carts.Count == 0)
            {
                return 0;
            }
            var cart = Carts.Dequeue();
            if (cart != null && Seller != null)
            {
                var check = new Check()
                {
                    SellerId = Seller.SellerId,
                    Seller = Seller,
                    CustomerId = cart.Customer.CustomerId,
                    Customer = cart.Customer,
                    Created = DateTime.Now
                };
                if (!IsModel)
                {
                    LTsCrmDB.Checks.Add(check);
                    LTsCrmDB.SaveChanges();
                }
                else
                {
                    check.CheckId = 0;
                }
                var sells = new List<Sell>();
                foreach (Product product in cart)
                {
                    var sell = new Sell()
                    {
                        CheckId = check.CheckId,
                        Check = check,
                        ProductId = product.ProductId,
                        Product = product
                    };

                    sells.Add(sell);
                    if (!IsModel)
                    {
                        LTsCrmDB.Sells.Add(sell);
                    }
                    sum += product.Price;
                }

                check.Price = sum;
                if (!IsModel)
                {
                    LTsCrmDB.SaveChanges();
                }
                CheckClosed?.Invoke(this, check);
            }
            return sum;
        }
        public override string ToString()
        {
            return $"Cashdesk №{Number}";
        }
    }
}
