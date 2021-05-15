using CosmeticShop.Models.Products.EmployeeOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class OrdersToCollect
    {
        public int Id { get; set; }

        public List<Order> Orders { get; set; }

        public int OrderProcessingId { get; set; }
        public OrderProcessing OrderProcessing { get; set; }
    }
}
