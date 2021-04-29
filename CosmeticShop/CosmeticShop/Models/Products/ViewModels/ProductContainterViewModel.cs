using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products.ViewModels
{
    public class ProductContainterViewModel
    {
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Cost { get; set; }

        public DateTime? CreateDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public List<string> AllCategories { get; set; }

        public string CategoryName;
        [Required]
        public List<Picture> Pictures { get; set; }
    }
}
