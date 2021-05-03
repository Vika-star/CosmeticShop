using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticShop.Models.Products;
using CosmeticShop.Models.Users;
using CosmeticShop.Models;
using Microsoft.EntityFrameworkCore;
using CosmeticShop.Models.Products.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using CosmeticShop.Models.Products.Sorts;

namespace CosmeticShop.Controllers.Products
{
    public class TraidingController : Controller
    {
        private readonly ApplicationContext _context;

        public TraidingController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId, List<Sort> sorts)
        {
            IQueryable<ProductContainer> products = _context.ProductContainers.Include(p => p.Pictures).Include(x => x.ProductCategory);

            //products = OrderProducts(sortOrder, products);

            products = FilterProducts(categoryId, products);

            //var viewSorts = new List<Sort>
            //{
            //    new Sort{ Name = "",}
            //};

            var viewCategories = _context.ProductCategories.ToList();
            viewCategories.Insert(0, new ProductCategory { Name = "Все категории", Id = 0 });

            ProductListViewModel viewModel = new ProductListViewModel
            {
                Products = await products.AsNoTracking().ToListAsync(),
                Categories = new SelectList(viewCategories, "Id", "Name"),
                //Sorts = new SelectList(viewSorts),
            };

            return View(viewModel);
        }

        private IQueryable<ProductContainer> FilterProducts(int? categoryId, IQueryable<ProductContainer> products)
        {
            if (categoryId != null && categoryId != 0)
            {
                products = products.Where(p => p.ProductCategoryId == categoryId);
            }

            return products;
        }

        private IQueryable<ProductContainer> OrderProducts(SortState sortOrder, IQueryable<ProductContainer> products)
        {
            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["CostSort"] = sortOrder == SortState.CostAsc ? SortState.CostDesc : SortState.CostAsc;

            products = sortOrder switch
            {
                SortState.NameDesc => products.OrderByDescending(s => s.ProductName),
                SortState.CostDesc => products.OrderByDescending(s => s.Cost),
                SortState.CostAsc => products.OrderBy(s => s.Cost),
                _ => products.OrderBy(s => s.ProductName),
            };
            return products;
        }
    }
}
