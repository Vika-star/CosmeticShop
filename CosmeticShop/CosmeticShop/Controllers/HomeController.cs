using CosmeticShop.Models;
using CosmeticShop.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var amountProducts = await _context.ProductContainers.CountAsync();


            if (amountProducts >= Constants.CountLatestProducts)
            {
                var latestProducts = await _context.ProductContainers
                .Include(x => x.ProductCategory)
                .Include(x => x.ProductPictures)
                    .ThenInclude(x => x.Pictures)
                .Skip(amountProducts - Constants.CountLatestProducts)
                .Take(Constants.CountLatestProducts).ToListAsync();

                var countSymbols = 35;

                foreach (var product in latestProducts)
                {
                    if(product.ProductName.Length > countSymbols)
                        product.ProductName = $"{string.Join("", product.ProductName.Take(countSymbols - 3))}...";
                }
                latestProducts.Reverse();
                return View(latestProducts);
            }

            return View(new List<ProductContainer>());
        }

        public IActionResult Privacy() => View();

        public IActionResult Contacts() => View();
        public IActionResult AboutUs() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
