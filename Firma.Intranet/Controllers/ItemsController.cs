using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.Sklep;

namespace Firma.Intranet.Controllers
{
    public class ItemsController : BaseController
    {

        public ItemsController(AlmondContext context) : base(context)
        {
        }
        // GET: Items
        public override async Task<IActionResult> Index()
        {
            var almondContext = _context.Item.Include(i => i.ItemType);
            return View(await almondContext.ToListAsync());
        }

        // GET: Items/Details/5
        public override async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.ItemType)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public override IActionResult Create()
        {
            ViewData["ItemTypeId"] = new SelectList(_context.ItemType, "ItemTypeId", "Nazwa");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ItemId,InfoGlowne,Opis,Cena,IsActive,ItemTypeId,Pozycja")] Item item, IFormFile photo)
        {
            
                if (photo != null && photo.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await photo.CopyToAsync(ms);
                        item.Photo = ms.ToArray();
                    }
                }
                ViewData["ItemTypeId"] = new SelectList(_context.ItemType, "ItemTypeId", "Nazwa", item.ItemTypeId);
            _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

                ViewData["ItemTypeId"] = new SelectList(_context.ItemType, "ItemTypeId", "Nazwa", item.ItemTypeId);
         
        }

        // GET: Items/Edit/5
        public override async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            ViewData["ItemTypeId"] = new SelectList(_context.ItemType, "ItemTypeId", "Nazwa", item.ItemTypeId);
            return View(item);
        }

        public async Task<IActionResult> Edit(int id,
            [Bind("ItemId,InfoGlowne,Opis,Cena,IsActive,ItemTypeId,Pozycja")] Item item, IFormFile photo)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (photo != null && photo.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        photo.CopyTo(ms);
                        item.Photo = ms.ToArray();
                    }
                }

                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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

            ViewData["ItemTypeId"] = new SelectList(_context.ItemType, "ItemTypeId", "Nazwa", item.ItemTypeId);
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("ItemId,InfoGlowne,Opis,Cena,Photo,IsActive,ItemTypeId,Pozycja")]
            Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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

            ViewData["ItemTypeId"] = new SelectList(_context.ItemType, "ItemTypeId", "Nazwa", item.ItemTypeId);
            return View(item);
        }

        // GET: Items/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.ItemType)
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Item == null)
            {
                return Problem("Entity set 'AlmondContext.Item'  is null.");
            }

            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return (_context.Item?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }

        
    }
}