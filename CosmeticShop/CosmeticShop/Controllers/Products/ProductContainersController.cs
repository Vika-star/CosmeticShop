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

        // GET: ProductContainers
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ProductContainers.Include(p => p.ProductCategory);
            return View(await applicationContext.ToListAsync());
        }

        // GET: ProductContainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productContainer = await _context.ProductContainers
                .Include(p => p.ProductCategory).Include(imgs => imgs.Pictures)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productContainer == null)
            {
                return NotFound();
            }

            return View(productContainer);
        }

        // GET: ProductContainers/Create
        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name");
            return View();
        }

        // POST: ProductContainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductContainer productContainer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productContainer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name", productContainer.ProductCategoryId);
            return View(productContainer);
        }

        // GET: ProductContainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productContainer = await _context.ProductContainers.FindAsync(id);
            
            if (productContainer == null)
            {
                return NotFound();
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name", productContainer.ProductCategoryId);

            return View(productContainer);
        }

        // POST: ProductContainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductContainer productContainer)
        {
            if (id != productContainer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productContainer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductContainerExists(productContainer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name", productContainer.ProductCategoryId);
            return View(productContainer);
        }

        // GET: ProductContainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productContainer = await _context.ProductContainers
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productContainer == null)
            {
                return NotFound();
            }

            return View(productContainer);
        }

        // POST: ProductContainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productContainer = await _context.ProductContainers.FindAsync(id);
            _context.ProductContainers.Remove(productContainer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductContainerExists(int id)
        {
            return _context.ProductContainers.Any(e => e.Id == id);
        }
    }
}
