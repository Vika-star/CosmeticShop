using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CosmeticShop.Models;
using CosmeticShop.Models.Products;
using Microsoft.AspNetCore.Authorization;
using CosmeticShop.Models.Products.ViewModels;

namespace CosmeticShop.Controllers
{
    [Authorize(Roles = "employee")]
    public class ProductContainersController : Controller
    {
        private readonly ApplicationContext _context;

        public ProductContainersController(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var productContainers = await _context.ProductContainers.ToListAsync();
            
            return View(productContainers);
        }

        // GET: Products/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .Include(p => p.ProductContainer)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _context.ProductCategories.ToListAsync();
            var model = new ProductContainterViewModel
            {
                AllCategories = categories.Select(x=>x.Name).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductContainterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var container = new ProductContainer
                {
                    ProductName = model.ProductName,
                    ProductCategory = new ProductCategory { Name = model.CategoryName },
                    Pictures = model.Pictures,
                };
                //await _context.AddAsync(container.Products);
                await _context.AddAsync(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProductContainerId"] = new SelectList(_context.ProductContainers, "Id", "Id", product.ProductContainerId);
        //    return View(product);
        //}

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Cost,CreateDate,ExpirationDate,ProductContainerId")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProductContainerId"] = new SelectList(_context.ProductContainers, "Id", "Id", product.ProductContainerId);
        //    return View(product);
        //}

        // GET: Products/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products
        //        .Include(p => p.ProductContainer)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        //// POST: Products/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.Id == id);
        //}
    }
}
