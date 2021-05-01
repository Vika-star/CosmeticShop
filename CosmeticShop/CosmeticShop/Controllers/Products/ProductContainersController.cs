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

        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.ProductContainers.Include(p => p.ProductCategory);
            return View(await applicationContext.ToListAsync());
        }

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

        public IActionResult Create()
        {
            ViewData["ProductCategoryId"] = new SelectList(_context.ProductCategories, "Id", "Name");
            return View();
        }

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
        
        public async Task<IActionResult> EditImages(int? id)
        {
            if (id == null)
                return NotFound();

            var pictures = await _context.Pictures
                                            .Where(x => x.ProductContainerId == id)
                                            .ToListAsync();

            if (pictures == null)
                return NotFound();

            return View(pictures);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImages(int id, List<Picture> pictures)
        {
            var productContainer = await _context.ProductContainers
                                                    .Include(p => p.Pictures)
                                                    .FirstOrDefaultAsync(x => x.Id == id);
            if (productContainer == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    productContainer.Pictures.AddRange(pictures);
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
                return RedirectToAction(nameof(EditImages), new { id = id});
            }
            return View(productContainer);
        }

        public async Task<IActionResult> DeleteImage(int? id, int? imageId )
        {
            var productContainer = await _context.ProductContainers
                                                    .Include(p=>p.Pictures)
                                                    .FirstOrDefaultAsync(x=>x.Id == id);

            if (id != productContainer.Id || !productContainer.Pictures.Any(x=>x.Id == imageId))
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var imageToDelete = productContainer.Pictures.FirstOrDefault(x => x.Id == imageId);
                    productContainer.Pictures.Remove(imageToDelete);
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
                return RedirectToAction(nameof(EditImages), new { id = id });
            }
            return View(productContainer);
        }
        
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
