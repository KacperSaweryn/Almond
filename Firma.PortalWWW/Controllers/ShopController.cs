using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Controllers
{
    public class ShopController : Controller
    {
        protected readonly AlmondContext _context;

        public ShopController(AlmondContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
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
            return View(await _context.Item.Where(t => t.ItemTypeId == id).ToListAsync());
        }

        public async Task<IActionResult> Details(int id) //w parametrze id nie bedzie nulla bo klikamy obiekt
        {
            ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
            //do widoku przekazujemy towar o danym kliknietym id
            return View(await _context.Item.FirstOrDefaultAsync(t => t.ItemId == id));

        }
    }
}