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
using CosmeticShop.Models.AuxiliaryEntities;

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

        public async Task<IActionResult> Index(ProductsFavorProperties properties)
        {
            IQueryable<ProductContainer> products = _context.ProductContainers
                                                    .Include(x => x.ProductPictures)
                                                    .ThenInclude(x => x.Pictures)
                                                    .Include(x => x.ProductCategory);

            products = Filter(properties.CategoriesId, properties.CostFrom, properties.CostTo, products);
            products = Sort(properties.sortOrder, products);

            var count = await products.CountAsync();
            var items = await products.Skip((properties.Page - 1) * _pageSize).Take(_pageSize).ToListAsync();

            var viewModel = new ProductsViewModel
            {
                PageViewModel = new PageViewModel(count, properties.Page, _pageSize),
                SortViewModel = new SortViewModel(properties.sortOrder),
                FilterViewModel = new FilterViewModel(_context.ProductCategories.ToList(),
                    properties.CategoriesId, properties.CostFrom, properties.CostTo),
                Products = items
            };
            return View(viewModel);
        }

        private IQueryable<ProductContainer> Sort(SortState sortOrder, IQueryable<ProductContainer> products) => sortOrder switch
        {
            SortState.NameAsc => products.OrderBy(s => s.ProductName),
            SortState.NameDesc => products.OrderByDescending(s => s.ProductName),
            SortState.CostAsc => products.OrderBy(s => s.Cost),
            SortState.CostDesc => products.OrderByDescending(s => s.Cost),
            _ => products,
        };

        private IQueryable<ProductContainer> Filter(int[] categoriesId, int? costFrom, int? costTo, IQueryable<ProductContainer> products)
        {
            if (categoriesId != null && categoriesId.Length > 0)
                products = products
                    .Where(p => 
                        categoriesId.Any(x =>
                            x.Equals(p.ProductCategoryId)));   
            if (costFrom != null && costTo != null)
                products = products.Where(x => x.Cost >= costFrom && x.Cost <= costTo);

            return products;
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var productContainer = await _context.ProductContainers
                .Include(p => p.ProductCategory)
                .Include(x => x.ProductPictures).ThenInclude(x => x.Pictures)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productContainer == null)
                return NotFound();

            return View(productContainer);
        }


    }
}
