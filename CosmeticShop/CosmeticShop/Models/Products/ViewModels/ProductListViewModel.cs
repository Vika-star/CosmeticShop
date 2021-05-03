using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductContainer> Products { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Sorts { get; set; }
    }
}
