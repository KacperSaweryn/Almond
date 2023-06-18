using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Firma.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        protected readonly AlmondContext _context;

        public ShopController(AlmondContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id, string sortOrder)
        {
            if (_context.ItemType != null)
            {
                ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
                if (id == null)
                {
                    var first = await _context.ItemType.FirstAsync();
                    id = first.ItemTypeId;
                }
            }

            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParam"] = sortOrder == "price_asc" ? "price_desc" : "price_asc";

            var items = _context.Item.Where(t => t.ItemTypeId == id);

            switch (sortOrder)
            {
                case "name_desc":
                    items = items.OrderByDescending(t => t.InfoGlowne);
                    break;
                case "price_asc":
                    items = items.OrderBy(t => t.Cena);
                    break;
                case "price_desc":
                    items = items.OrderByDescending(t => t.Cena);
                    break;
                default:
                    items = items.OrderBy(t => t.InfoGlowne);
                    break;
            }

            return View(await items.ToListAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
            return View(await _context.Item.FirstOrDefaultAsync(t => t.ItemId == id));
        }
    }
}