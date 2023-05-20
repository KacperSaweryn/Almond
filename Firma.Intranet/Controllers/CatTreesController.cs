using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.Intranet.Controllers
{
    public class CatTreesController : BaseController
    {
      

        // GET: CatTrees
        public override async Task<IActionResult> Index()
        {
              return _context.CatTree != null ? 
                          View(await _context.CatTree.ToListAsync()) :
                          Problem("Entity set 'AlmondContext.CatTree'  is null.");
        }

        // GET: CatTrees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatTree == null)
            {
                return NotFound();
            }

            var catTree = await _context.CatTree
                .FirstOrDefaultAsync(m => m.DrapakId == id);
            if (catTree == null)
            {
                return NotFound();
            }

            return View(catTree);
        }


        // POST: CatTrees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DrapakId,Kolor,Opis,Cena,FotoUrl,IsActive,Pozycja")] CatTree catTree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catTree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catTree);
        }

        // GET: CatTrees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatTree == null)
            {
                return NotFound();
            }

            var catTree = await _context.CatTree.FindAsync(id);
            if (catTree == null)
            {
                return NotFound();
            }
            return View(catTree);
        }

        // POST: CatTrees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DrapakId,Kolor,Opis,Cena,FotoUrl,IsActive,Pozycja")] CatTree catTree)
        {
            if (id != catTree.DrapakId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catTree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatTreeExists(catTree.DrapakId))
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
            return View(catTree);
        }

        // GET: CatTrees/Delete/5
        public override async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatTree == null)
            {
                return NotFound();
            }

            var catTree = await _context.CatTree
                .FirstOrDefaultAsync(m => m.DrapakId == id);
            if (catTree == null)
            {
                return NotFound();
            }

            return View(catTree);
        }

        // POST: CatTrees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatTree == null)
            {
                return Problem("Entity set 'AlmondContext.CatTree'  is null.");
            }
            var catTree = await _context.CatTree.FindAsync(id);
            if (catTree != null)
            {
                _context.CatTree.Remove(catTree);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatTreeExists(int id)
        {
          return (_context.CatTree?.Any(e => e.DrapakId == id)).GetValueOrDefault();
        }

        public CatTreesController(AlmondContext context) : base(context)
        {
        }
    }
}
