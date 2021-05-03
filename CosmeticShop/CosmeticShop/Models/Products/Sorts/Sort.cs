using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products.Sorts
{
    public class Sort
    {
        public SortState State { get; set; }
        public bool IsActive { get; set; }
    }
}
