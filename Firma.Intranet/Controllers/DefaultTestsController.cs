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
    public class DefaultTestsController : Controller
    {
        private readonly AlmondContext _context;

        public DefaultTestsController(AlmondContext context)
        {
            _context = context;
        }

        // GET: DefaultTests
        public async Task<IActionResult> Index()
        {
              return _context.DefaultTest != null ? 
                          View(await _context.DefaultTest.ToListAsync()) :
                          Problem("Entity set 'AlmondContext.DefaultTest'  is null.");
        }

        // GET: DefaultTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DefaultTest == null)
            {
                return NotFound();
            }

            var defaultTest = await _context.DefaultTest
                .FirstOrDefaultAsync(m => m.IdDef == id);
            if (defaultTest == null)
            {
                return NotFound();
            }

            return View(defaultTest);
        }

        // GET: DefaultTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DefaultTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDef,Name")] DefaultTest defaultTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(defaultTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(defaultTest);
        }

        // GET: DefaultTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DefaultTest == null)
            {
                return NotFound();
            }

            var defaultTest = await _context.DefaultTest.FindAsync(id);
            if (defaultTest == null)
            {
                return NotFound();
            }
            return View(defaultTest);
        }

        // POST: DefaultTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDef,Name")] DefaultTest defaultTest)
        {
            if (id != defaultTest.IdDef)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(defaultTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DefaultTestExists(defaultTest.IdDef))
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
            return View(defaultTest);
        }

        // GET: DefaultTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DefaultTest == null)
            {
                return NotFound();
            }

            var defaultTest = await _context.DefaultTest
                .FirstOrDefaultAsync(m => m.IdDef == id);
            if (defaultTest == null)
            {
                return NotFound();
            }

            return View(defaultTest);
        }

        // POST: DefaultTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DefaultTest == null)
            {
                return Problem("Entity set 'AlmondContext.DefaultTest'  is null.");
            }
            var defaultTest = await _context.DefaultTest.FindAsync(id);
            if (defaultTest != null)
            {
                _context.DefaultTest.Remove(defaultTest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DefaultTestExists(int id)
        {
          return (_context.DefaultTest?.Any(e => e.IdDef == id)).GetValueOrDefault();
        }
    }
}
