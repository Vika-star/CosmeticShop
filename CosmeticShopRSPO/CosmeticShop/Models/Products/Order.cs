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

        public OrderPresonalData PersonalData { get; set; }
        public List<OrderProductAccounting> OrderProuctAccountings { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public Order()
        {
            OrderProuctAccountings = new List<OrderProductAccounting>();
        }


        [NotMapped]
        public decimal SummaryCost => OrderProuctAccountings.Sum(x => x.Cost);

        
        
        public int? OrderHistoryId { get; set; }
        public OrderHistory OrderHistory { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int? OrdersToDeliveryId { get; set; }
        public OrderToDelivery OrdersToDelivery { get; set; }

        public int? OrderToCollectId { get; set; }
        public OrderToCollect OrdersToCollect { get; set; }
    }
}
