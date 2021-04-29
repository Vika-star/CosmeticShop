using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class ProductContainer
    {
        public int Id { get; set; }

        public int CountProducts { get; set; }

        public string ProductName { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public List<Picture> Pictures { get; set; }

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }
    }
}
