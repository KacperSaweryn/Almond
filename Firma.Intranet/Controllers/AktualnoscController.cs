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
    public class AktualnoscController : Controller
    {
        private readonly AlmondContext _context;

        public AktualnoscController(AlmondContext context)
        {
            _context = context;
        }

        // GET: Aktualnosc
        public async Task<IActionResult> Index()
        {
            return View(await _context.News.ToListAsync());
        }

        // GET: Aktualnosc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var aktualnosc = await _context.News
                .FirstOrDefaultAsync(m => m.IdAktualnosci == id);
            if (aktualnosc == null)
            {
                return NotFound();
            }

            return View(aktualnosc);
        }

        // GET: Aktualnosc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aktualnosc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("IdAktualnosci,LinkTytul,Tytul,Tresc,Rozwiniecie,FotoUrl,AltText,Icon,Pozycja")] News aktualnosc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aktualnosc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(aktualnosc);
        }

        // GET: Aktualnosc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var aktualnosc = await _context.News.FindAsync(id);
            if (aktualnosc == null)
            {
                return NotFound();
            }

            return View(aktualnosc);
        }

        // POST: Aktualnosc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("IdAktualnosci,LinkTytul,Tytul,Tresc,Rozwiniecie,FotoUrl,AltText,Icon,Pozycja")] News aktualnosc)
        {
            if (id != aktualnosc.IdAktualnosci)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aktualnosc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktualnoscExists(aktualnosc.IdAktualnosci))
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

            return View(aktualnosc);
        }

        // GET: Aktualnosc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.News == null)
            {
                return NotFound();
            }

            var aktualnosc = await _context.News
                .FirstOrDefaultAsync(m => m.IdAktualnosci == id);
            if (aktualnosc == null)
            {
                return NotFound();
            }

            return View(aktualnosc);
        }

        // POST: Aktualnosc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.News == null)
            {
                return Problem("Entity set 'FirmaContext.Aktualnosc'  is null.");
            }

            var aktualnosc = await _context.News.FindAsync(id);
            if (aktualnosc != null)
            {
                _context.News.Remove(aktualnosc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AktualnoscExists(int id)
        {
            return _context.News.Any(e => e.IdAktualnosci == id);
        }
    }
}