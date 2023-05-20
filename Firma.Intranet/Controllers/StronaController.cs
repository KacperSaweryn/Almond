using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firma.Data.Data;
using Firma.Data.Data.CMS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Firma.Intranet.Controllers
{
    public class StronaController : Controller
    {
        public readonly AlmondContext _context;

        public StronaController(AlmondContext context)
        {
            _context = context;
        }


        // GET: Strona
        public  async Task<IActionResult> Index(string searchTytul, string searchTresc)
        {
            var pages = from p in _context.Page
                select p;

            if (!String.IsNullOrEmpty(searchTytul))
            {
                pages = pages.Where(p => p.Tytul.Contains(searchTytul));
            }

            if (!String.IsNullOrEmpty(searchTresc))
            {
                pages = pages.Where(p => p.Tresc.Contains(searchTresc));
            }

            ViewBag.CurrentFilterTytul = searchTytul;
            ViewBag.CurrentFilterTresc = searchTresc;

            return View(await pages.ToListAsync());
        }
    

        public IActionResult Create()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }

        // GET: Strona/Details/5
        public  async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Page == null)
            {
                return NotFound();
            }

            var strona = await _context.Page
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

      

        // POST: Strona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdStrony,LinkTytul,Tytul,Tresc,FotoUrl,AltText,FotoUrlDown,AltTextDown,Pozycja")] Page strona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(strona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(strona);
        }

        // GET: Strona/Edit/5
        public  async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Page == null)
            {
                return NotFound();
            }

            var strona = await _context.Page.FindAsync(id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // POST: Strona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdStrony,LinkTytul,Tytul,Tresc,FotoUrl,AltText,FotoUrlDown,AltTextDown,Pozycja")] Page strona)
        {
            if (id != strona.IdStrony)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(strona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StronaExists(strona.IdStrony))
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

            return View(strona);
        }

        // GET: Strona/Delete/5
        public  async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Page == null)
            {
                return NotFound();
            }

            var strona = await _context.Page
                .FirstOrDefaultAsync(m => m.IdStrony == id);
            if (strona == null)
            {
                return NotFound();
            }

            return View(strona);
        }

        // POST: Strona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Page == null)
            {
                return Problem("Entity set 'FirmaContext.Strona'  is null.");
            }

            var strona = await _context.Page.FindAsync(id);
            if (strona != null)
            {
                _context.Page.Remove(strona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StronaExists(int id)
        {
            return _context.Page.Any(e => e.IdStrony == id);
        }
    }
}