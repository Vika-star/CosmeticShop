using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class OrderPresonalData
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }
        public string Flat { get; set; }
        public bool IsPaid { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
