using CosmeticShop.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class OrderHistory
    {
        public OrderHistory()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public List<Order> Orders { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
