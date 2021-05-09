using CosmeticShop.Migrations;
using CosmeticShop.Models;
using CosmeticShop.Models.Products;
using CosmeticShop.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit.Encodings;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public async Task<IActionResult> Add(int? productId)
        {
            if (productId == null)
                return NotFound();
            var product = await _context.ProductContainers.FindAsync(productId);

            if (product == null)
                return NotFound();

            var user = await _userManager.GetUserAsync(User);
            var order = await _context.Orders
                .Where(x => x.UserId.Equals(user.Id))
                .Include(x => x.OrderProuctAccountings)
                .ThenInclude(x => x.ProductContainer)
                .FirstOrDefaultAsync();

            var exitstingProduct = order.OrderProuctAccountings
                .Where(x => x.ProductContainerId
                .Equals(productId))
                .FirstOrDefault();

            if (exitstingProduct != null)
            {
                if (exitstingProduct.CountRequiredProducts + 1 <= exitstingProduct.ProductContainer.CountProducts)
                {
                    exitstingProduct.CountRequiredProducts++;
                }
            }
            else
            {
                order.OrderProuctAccountings.Add(new OrderProductAccounting
                {
                    CountRequiredProducts = 1,
                    ProductContainer = product,
                });
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Traiding");
        }

        public async Task<IActionResult> Details(int? id)
        {
            var productContainer = await _context.ProductContainers
                .Include(p => p.ProductCategory)
                .Include(x => x.ProductPictures)
                .ThenInclude(x => x.Pictures)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productContainer == null)
                return NotFound();

            return View(productContainer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userManager.GetUserAsync(User);
            var order = await _context.Orders
                .Include(x => x.OrderProuctAccountings)
                .ThenInclude(x => x.ProductContainer)
                .FirstOrDefaultAsync(x => x.UserId.Equals(user.Id));

            if (order == null)
                return NotFound();

            var productToRemove = order.OrderProuctAccountings
                .Where(x => x.ProductContainerId == id)
                .FirstOrDefault();

            _context.OrderProuctAccountings.Remove(productToRemove);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Ordering(int? id)
        {
            var order = await _context.Orders.Include(x=>x.OrderProuctAccountings)
                .ThenInclude(x=>x.ProductContainer)
                .ThenInclude(x=>x.ProductPictures)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (order == null)
                return NotFound();

            return View(order);
        }



        [HttpPost]
        public async Task<IActionResult> ChangeRequiredProducts(int? id, int? counter)
        {
            if (counter == null)
                return BadRequest();
            var accounting = await _context.OrderProuctAccountings
                .Include(x => x.ProductContainer)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (accounting == null)
                return NotFound();

            if (counter <= 0 || counter > accounting.ProductContainer.CountProducts)
                return BadRequest();

            accounting.CountRequiredProducts = counter.Value;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
