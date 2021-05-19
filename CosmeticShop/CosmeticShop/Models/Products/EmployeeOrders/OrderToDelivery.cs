using System.Collections.Generic;

namespace CosmeticShop.Models.Products
{
    public class OrderToDelivery
    {
        public int Id { get; set; }

        public Order Order { get; set; }
    }
}
