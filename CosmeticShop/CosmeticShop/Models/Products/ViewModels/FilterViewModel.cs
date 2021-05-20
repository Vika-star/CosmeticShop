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
        public int[] SelectedCategories { get; set; }

        public int SelectedCostForm { get; set; }
        public int SelectedCostTo { get; set; }

        public FilterViewModel(List<ProductCategory> categories,
            int[] categoriesId, int? selectedCostForm, int? selectedCostTo)
        {
            Categories = new SelectList(categories, "Id", "Name", categoriesId);
            SelectedCategories = categoriesId ?? new int[0];
            SelectedCostForm = selectedCostForm ?? 0;
            SelectedCostTo = selectedCostTo ?? int.MaxValue;
        }
    }
}
