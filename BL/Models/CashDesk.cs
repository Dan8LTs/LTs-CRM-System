using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CashDesk
    {
        readonly CrmContext LTsCrmDB = new CrmContext();
        public int Number { get; set; }
        public Seller Seller { get; set; }
        public Queue<Cart> Carts { get; set; }
        public int MaxQueueLenght { get; set; }
        public int ExitCustomer { get; set; }
        public bool IsModel { get; set; }
        public int Count => Carts.Count;
        public event EventHandler<Check> CheckClosed;
        public CashDesk(int number, Seller seller)
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
            if (Carts.Count <= MaxQueueLenght)
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
            if (cart != null)
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
                    if(product.Count > 0)
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
                        product.Count--;
                        sum += product.Price;
                    }
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
    }
}
