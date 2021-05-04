using CosmeticShop.Models.Products;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Users
{
    public class User : IdentityUser
    {
        public User()
        {
            Order = new Order();
        }
        public Order Order { get; set; }
        public OrderHistory OrderHistory { get; set; }
    }
}
