using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products.EmployeeOrders
{
    public class OrderProcessing
    {
        public int Id { get; set; }

        public List<OrderHistory> OrderHistories { get; set; }

        public OrdersToCollect OrdersToCollect { get; set; }
        public OrdersToDelivery OrdersToDelivery { get; set; }
    }
}
