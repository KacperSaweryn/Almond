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
    public class ItemTypesController : BaseController
    {
      

        // GET: ItemTypes
        public override async Task<IActionResult> Index()
        {
              return _context.ItemType != null ? 
                          View(await _context.ItemType.ToListAsync()) :
                          Problem("Entity set 'AlmondContext.ItemType'  is null.");
        }

        // GET: ItemTypes/Details/5
        public override async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemType == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemType
                .FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemType == null)
            {
                return NotFound();
            }

            return View(itemType);
        }


        // POST: ItemTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemTypeId,Nazwa,Opis,Pozycja")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemType);
        }

        // GET: ItemTypes/Edit/5
        public override async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemType == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemType.FindAsync(id);
            if (itemType == null)
            {
                return NotFound();
            }
            return View(itemType);
        }

        // POST: ItemTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemTypeId,Nazwa,Opis,Pozycja")] ItemType itemType)
        {
            if (id != itemType.ItemTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemTypeExists(itemType.ItemTypeId))
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
            return View(itemType);
        }

        // GET: ItemTypes/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemType == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemType
                .FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemType == null)
            {
                return NotFound();
            }

            return View(itemType);
        }

        // POST: ItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemType == null)
            {
                return Problem("Entity set 'AlmondContext.ItemType'  is null.");
            }
            var itemType = await _context.ItemType.FindAsync(id);
            if (itemType != null)
            {
                _context.ItemType.Remove(itemType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemTypeExists(int id)
        {
          return (_context.ItemType?.Any(e => e.ItemTypeId == id)).GetValueOrDefault();
        }

        public ItemTypesController(AlmondContext context) : base(context)
        {
        }
    }
}
