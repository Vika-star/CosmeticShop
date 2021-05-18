using CosmeticShop.Models.Products.EmployeeOrders;
using System.Collections.Generic;

namespace CosmeticShop.Models.Products
{
    public class OrdersToDelivery
    {
        public int Id { get; set; }

        public List<Order> Orders { get; set; }

        public int OrderProcessingId { get; set; }
        public OrderProcessing OrderProcessing { get; set; }
    }
}
