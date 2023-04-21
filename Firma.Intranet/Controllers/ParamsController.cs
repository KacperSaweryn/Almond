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
    public class ParamsController : Controller
    {
        private readonly AlmondContext _context;

        public ParamsController(AlmondContext context)
        {
            _context = context;
        }

        // GET: Params
        public async Task<IActionResult> Index()
        {
              return _context.Params != null ? 
                          View(await _context.Params.ToListAsync()) :
                          Problem("Entity set 'AlmondContext.Params'  is null.");
        }

        // GET: Params/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Params == null)
            {
                return NotFound();
            }

            var @params = await _context.Params
                .FirstOrDefaultAsync(m => m.IdParametr == id);
            if (@params == null)
            {
                return NotFound();
            }

            return View(@params);
        }

        // GET: Params/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Params/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametr,Nazwa,Tresc,Pozycja")] Params @params)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@params);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@params);
        }

        // GET: Params/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Params == null)
            {
                return NotFound();
            }

            var @params = await _context.Params.FindAsync(id);
            if (@params == null)
            {
                return NotFound();
            }
            return View(@params);
        }

        // POST: Params/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdParametr,Nazwa,Tresc,Pozycja")] Params @params)
        {
            if (id != @params.IdParametr)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@params);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParamsExists(@params.IdParametr))
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
            return View(@params);
        }

        // GET: Params/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Params == null)
            {
                return NotFound();
            }

            var @params = await _context.Params
                .FirstOrDefaultAsync(m => m.IdParametr == id);
            if (@params == null)
            {
                return NotFound();
            }

            return View(@params);
        }

        // POST: Params/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Params == null)
            {
                return Problem("Entity set 'AlmondContext.Params'  is null.");
            }
            var @params = await _context.Params.FindAsync(id);
            if (@params != null)
            {
                _context.Params.Remove(@params);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParamsExists(int id)
        {
          return (_context.Params?.Any(e => e.IdParametr == id)).GetValueOrDefault();
        }
    }
}