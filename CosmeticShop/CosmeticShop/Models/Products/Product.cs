using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class Product
    {
        public int Id { get; set; }

        public decimal Cost { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int ProductContainerId { get; set; }
        public ProductContainer ProductContainer { get; set; }
    }
}
