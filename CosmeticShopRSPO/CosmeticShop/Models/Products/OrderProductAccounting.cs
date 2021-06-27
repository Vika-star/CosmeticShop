using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class OrderProductAccounting
    {
        public int Id { get; set; }
        //public OrderProductAccounting() => ProductContainer = new();
        public int CountRequiredProducts { get; set; }

        [NotMapped]
        public decimal Cost => ProductContainer.Cost * CountRequiredProducts;

        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public int? ProductContainerId { get; set; }
        public ProductContainer ProductContainer { get; set; }
    }
}
