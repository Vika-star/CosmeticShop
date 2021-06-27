using CosmeticShop.Models;
using CosmeticShop.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Crmf;
using Org.BouncyCastle.Math.EC.Rfc7748;
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
                .Include(x=>x.Order)
                .ThenInclude(x=>x.PersonalData)
                .ToListAsync();

            return View(orders);
        }

        [Authorize(Roles = "delivery")]
        public async Task<IActionResult> OrdersToDelivery()
        {
            var orders = await _context.OrdersToDelivery
                .Include(x => x.Order)
                .ThenInclude(x => x.OrderProuctAccountings)
                .ThenInclude(x => x.ProductContainer)
                .Include(x=>x.Order)
                .ThenInclude(x=>x.PersonalData)
                .ToListAsync();

            return View(orders);
        }

        [Authorize(Roles = "employee")]
        [Authorize(Roles = "delivery")]
        public async Task<IActionResult> Details(int? id)
        {
            var order = await _context.Orders
                .Include(x => x.PersonalData)
                .Include(x => x.OrderProuctAccountings)
                .ThenInclude(x => x.ProductContainer)
                .ThenInclude(x => x.ProductPictures)
                .ThenInclude(x => x.Pictures)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (order == null)
                return NotFound();

            return View(order);
        }

        [HttpPost]
        [Authorize(Roles = "employee")]
        public async Task<IActionResult> ConfirmOrderCollection(int id)
        {
            var orderToCollect = await _context.OrdersToCollect
                .Include(x=>x.Order)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (orderToCollect == null)
                return NotFound();

            _context.OrdersToCollect.Remove(orderToCollect);
            var orderToDelivery = new OrderToDelivery { Order = orderToCollect.Order };
            await _context.OrdersToDelivery.AddAsync(orderToDelivery);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(OrdersToCollect));
        }

        [HttpPost]
        [Authorize(Roles = "delivery")]
        public async Task<IActionResult> ConfirmOrderDelivering(int? id)
        {
            var orderToDelivery = await _context.OrdersToDelivery
                .Include(x=>x.Order)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            if (orderToDelivery == null)
                return NotFound();

            _context.OrdersToDelivery.Remove(orderToDelivery);
            orderToDelivery.Order.DeliveryDate = DateTime.Now;
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(OrdersToDelivery));
        }
    }
}
