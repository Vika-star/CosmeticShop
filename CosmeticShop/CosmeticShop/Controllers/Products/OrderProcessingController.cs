using CosmeticShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Controllers.Products
{
    public class OrderProcessingController : Controller
    {
        private readonly ApplicationContext _context;
        public OrderProcessingController(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        [Authorize(Roles = "employee")]
        public async Task<IActionResult> OrdersToCollect()
        {
            var orders = await _context.OrdersToCollect
                .Include(x=>x.Order)
                .ThenInclude(x=>x.OrderProuctAccountings)
                .ThenInclude(x=>x.ProductContainer)
                .ToListAsync();

            return View(orders);
        }
    }
}
