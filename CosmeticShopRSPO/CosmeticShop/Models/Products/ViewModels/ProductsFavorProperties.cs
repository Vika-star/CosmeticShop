using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products.ViewModels
{
    public class ProductsFavorProperties
    {
        public int Page { get; set; } = 1;
        public SortState sortOrder { get; set; } = SortState.NameAsc;

        public int? CostFrom { get; set; }
        public int? CostTo { get; set; }

        public int[] CategoriesId { get; set; }
    }
}
