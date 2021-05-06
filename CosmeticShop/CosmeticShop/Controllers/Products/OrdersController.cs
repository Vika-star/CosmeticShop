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
    [Authorize]
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
            var order = await _context.Orders
                .Where(x => x.UserId.Equals(user.Id))
                .Include(x => x.OrderProuctAccountings)
                .ThenInclude(x => x.ProductContainer)
                .ThenInclude(x => x.ProductPictures)
                .ThenInclude(x => x.Pictures)
                .FirstOrDefaultAsync();

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Add(int? productId, int count = 1)
        {
            if (productId == null)
                return NotFound();
            var product = await _context.ProductContainers.FindAsync(productId);

            if (product == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);
            var order = await _context.Orders
                .Where(x => x.UserId.Equals(user.Id))
                .Include(x=>x.OrderProuctAccountings)
                .ThenInclude(x=>x.ProductContainer)
                .FirstOrDefaultAsync();
            
            var exitstingProduct = order.OrderProuctAccountings
                .Where(x => x.ProductContainerId
                .Equals(productId))
                .FirstOrDefault();

            if (exitstingProduct != null)
            {
                exitstingProduct.CountRequiredProducts += count;
            }
            else
            {
                order.OrderProuctAccountings.Add(new OrderProductAccounting
                {
                    CountRequiredProducts = count,
                    ProductContainer = product,
                });
            }
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);
            var order = await _context.Orders
                .Where(x => x.UserId.Equals(user.Id))
                .Include(x=>x.OrderProuctAccountings)
                .ThenInclude(x=>x.ProductContainer)
                .FirstOrDefaultAsync();

            if (order == null)
                return NotFound();

            var productToRemove = order.OrderProuctAccountings
                .Where(x => x.ProductContainerId == id)
                .FirstOrDefault();
            //order.OrderProuctAccountings.Remove(productToRemove);
            _context.OrderProuctAccountings.Remove(productToRemove);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
