using CosmeticShop.Migrations;
using CosmeticShop.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class Order
    {
        public int Id { get; set; }

        public Order()
        {
            OrderProuctAccountings = new List<OrderProductAccounting>();
        }

        public OrderPresonalData PersonalData { get; set; }

        [NotMapped]
        public decimal SummaryCost => OrderProuctAccountings.Sum(x => x.Cost);

        public List<OrderProductAccounting> OrderProuctAccountings { get; set; }

        public int? OrderHistoryId { get; set; }
        public OrderHistory OrderHistory { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int? OrdersToDeliveryId { get; set; }
        public OrdersToDelivery OrdersToDelivery { get; set; }

        public int? OrdersToCollectId { get; set; }
        public OrdersToCollect OrdersToCollect { get; set; }
    }
}
