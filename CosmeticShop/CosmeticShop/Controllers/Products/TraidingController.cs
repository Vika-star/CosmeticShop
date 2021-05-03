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

namespace CosmeticShop.Controllers.Products
{
    public class TraidingController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly int _pageSize = Constants.CountProductsOnPage;

        public TraidingController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? categoryId, int page = 1,
            SortState sortOrder = SortState.NameAsc)
        {


            IQueryable<ProductContainer> products = _context.ProductContainers.Include(x => x.ProductCategory);

            products = Filter(categoryId, products);
            products = Sort(sortOrder, products);

            var count = await products.CountAsync();
            var items = await products.Skip((page - 1) * _pageSize).Take(_pageSize).ToListAsync();

            ProductsViewModel viewModel = new ProductsViewModel
            {
                PageViewModel = new PageViewModel(count, page, _pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(_context.ProductCategories.ToList(), categoryId),
                Products = items
            };
            return View(viewModel);
        }

        private static IQueryable<ProductContainer> Sort(SortState sortOrder, IQueryable<ProductContainer> products) => sortOrder switch
        {
            SortState.NameAsc => products.OrderBy(s => s.ProductName),
            SortState.NameDesc => products.OrderByDescending(s => s.ProductName),
            SortState.CostAsc => products.OrderBy(s => s.Cost),
            SortState.CostDesc => products.OrderByDescending(s => s.Cost),
            _ => products,
        };

        private static IQueryable<ProductContainer> Filter(int? categoryId, IQueryable<ProductContainer> products)
        {
            if (categoryId != null && categoryId != 0)
            {
                products = products.Where(p => p.ProductCategoryId == categoryId);
            }

            return products;
        }
    }
}
