using System.Collections.Generic;

namespace CrmBL.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public uint Count { get; set; }
        public virtual ICollection<Sell> Sells { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
