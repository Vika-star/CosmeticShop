using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class ProductContainer
    {
        public int Id { get; set; }

        public string ProductName { get; set; }
        
        public List<Product> Products { get; set; }
        public List<Picture> Pictures { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
