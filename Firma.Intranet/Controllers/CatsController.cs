﻿using System;
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
    public class CatsController : Controller
    {
        private readonly AlmondContext _context;

        public CatsController(AlmondContext context)
        {
            _context = context;
        }

        // GET: Cats
        public async Task<IActionResult> Index()
        {
              return _context.Cat != null ? 
                          View(await _context.Cat.ToListAsync()) :
                          Problem("Entity set 'AlmondContext.Cat'  is null.");
        }

        // GET: Cats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .FirstOrDefaultAsync(m => m.KotId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // GET: Cats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KotId,Rasa,Kolor,Imie,Opis,Cena,FotoUrl,IsActive,Pozycja")] Cat cat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cat);
        }

        // GET: Cats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat.FindAsync(id);
            if (cat == null)
            {
                return NotFound();
            }
            return View(cat);
        }

        // POST: Cats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KotId,Rasa,Kolor,Imie,Opis,Cena,FotoUrl,IsActive,Pozycja")] Cat cat)
        {
            if (id != cat.KotId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatExists(cat.KotId))
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
            return View(cat);
        }

        // GET: Cats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat
                .FirstOrDefaultAsync(m => m.KotId == id);
            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        // POST: Cats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cat == null)
            {
                return Problem("Entity set 'AlmondContext.Cat'  is null.");
            }
            var cat = await _context.Cat.FindAsync(id);
            if (cat != null)
            {
                _context.Cat.Remove(cat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatExists(int id)
        {
          return (_context.Cat?.Any(e => e.KotId == id)).GetValueOrDefault();
        }
    }
}
