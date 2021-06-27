using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductContainer> ProductContainers { get; set; }
    }
}
