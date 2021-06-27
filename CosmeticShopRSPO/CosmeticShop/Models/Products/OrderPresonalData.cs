using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products
{
    public class OrderPresonalData
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Home { get; set; }
        public string Flat { get; set; }
        public bool IsPaid { get; set; }

        public int? OrderId { get; set; }
        public Order Order { get; set; }
    }
}
