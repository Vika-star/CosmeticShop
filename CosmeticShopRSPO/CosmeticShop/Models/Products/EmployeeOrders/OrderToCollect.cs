using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class OrderToCollect
    {
        public int Id { get; set; }

        public Order Order { get; set; }
    }
}
