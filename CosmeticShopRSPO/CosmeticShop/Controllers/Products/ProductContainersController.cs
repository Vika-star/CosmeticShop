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
                return NotFound();


            var productContainer = await _context.ProductContainers
                .Include(p => p.ProductCategory)
                .Include(imgs => imgs.ProductPictures).ThenInclude(x => x.Pictures)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (productContainer == null)
                return NotFound();

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
                    var sourseContainer = await _context.ProductContainers
                    .Include(x=>x.ProductCategory)
                    .FirstOrDefaultAsync(x=>x.Id.Equals(id));
                    
                    sourseContainer.CountProducts = productContainer.CountProducts;
                    sourseContainer.ProductName = productContainer.ProductName;
                    sourseContainer.Cost = productContainer.Cost;
                    sourseContainer.Description = productContainer.Description;
                    sourseContainer.CreateDate = productContainer.CreateDate;
                    sourseContainer.ExpirationDate = productContainer.ExpirationDate;
                    sourseContainer.ProductCategoryId = productContainer.ProductCategoryId;

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

            var pictures = await _context.ProductPictures
                                            .Where(x => x.ProductContainerId == id)
                                            .Include(p => p.Pictures)
                                            .FirstOrDefaultAsync();

            if (pictures == null)
                return NotFound();

            return View(pictures);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImages(int id, List<Picture> pictures, int? previewNnmber)
        {
            var productContainer = await _context.ProductContainers
                                            .Include(imgs => imgs.ProductPictures).ThenInclude(x => x.Pictures)
                                            .FirstOrDefaultAsync(x => x.Id == id);
            if (productContainer == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {

                    productContainer.ProductPictures.PreviewNnmber = previewNnmber ?? 0;
                    productContainer.ProductPictures.Pictures.AddRange(pictures);
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

        public async Task<IActionResult> DeleteImage(int? id, int? imageId)
        {
            var productContainer = await _context.ProductContainers
                                            .Include(imgs => imgs.ProductPictures).ThenInclude(x => x.Pictures)
                                            .FirstOrDefaultAsync(x => x.Id == id);

            if (id != productContainer.Id || !productContainer.ProductPictures.Pictures.Any(x => x.Id == imageId))
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var imageToDelete = productContainer.ProductPictures.Pictures.FirstOrDefault(x => x.Id == imageId);
                    productContainer.ProductPictures.Pictures.Remove(imageToDelete);
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
            var productContainer = await _context.ProductContainers
                .Include(x => x.ProductPictures)
                .ThenInclude(x => x.Pictures)
                .Include(x => x.OrderProuctAccountings)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
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
