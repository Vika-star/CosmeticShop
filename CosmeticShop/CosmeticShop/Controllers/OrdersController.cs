using CosmeticShop.Migrations;
using CosmeticShop.Models;
using CosmeticShop.Models.Products;
using CosmeticShop.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmeticShop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public OrdersController(ApplicationContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var order = await _context.Orders.Where(x=>x.UserId == user.Id).FirstOrDefaultAsync();

            return View(order);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(int? productId, int count = 1)
        {
            if (productId == null)
                return NotFound();
            var product = await _context.ProductContainers.FindAsync(productId);

            if (product == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);
            var order = await _context.Orders.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            
            order.ProductContainers.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
