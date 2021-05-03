using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Models.Products.ViewModels
{
    public class FilterViewModel
    {
        public SelectList Categories { get; private set; } 
        public int? SelectedCategory { get; private set; }  
        
        public FilterViewModel(List<ProductCategory> categories, int? categoryId)
        {
            categories.Insert(0, new ProductCategory { Name = "Все", Id = 0 });

            Categories = new SelectList(categories, "Id", "Name", categoryId);
            SelectedCategory = categoryId;
        }
    }
}
