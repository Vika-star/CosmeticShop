using CosmeticShop.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class Order
    {
        public int Id { get; set; }
        
        public List<ProductCategory> ProductCategories { get; set; }

        public int OrderHistoryId { get; set; }
        public OrderHistory OrderHistory { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
