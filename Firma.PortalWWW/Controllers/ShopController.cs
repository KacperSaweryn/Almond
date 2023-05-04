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


        // public async Task<IActionResult> Index(int? id, string sortOrder)
        // {
        //     if (_context.ItemType != null)
        //     {
        //         ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
        //         if (id == null)
        //         {
        //             var first = await _context.ItemType.FirstAsync();
        //             id = first.ItemTypeId;
        //         }
        //     }
        //
        //     ViewData["CurrentSort"] = sortOrder;
        //     ViewData["PriceSortParm"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
        //     ViewData["NameSortParm"] = sortOrder == "name" ? "name_desc" : "name";
        //
        //     var items = _context.Item.Where(t => t.ItemTypeId == id);
        //
        //     switch (sortOrder)
        //     {
        //         case "name":
        //             items = items.OrderBy(t => t.InfoGlowne);
        //             break;
        //         case "name_desc":
        //             items = items.OrderByDescending(t => t.InfoGlowne);
        //             break;
        //         case "price_desc":
        //             items = items.OrderByDescending(t => t.Cena);
        //             break;
        //         default:
        //             items = items.OrderBy(t => t.Cena);
        //             break;
        //     }
        //
        //     return View(await items.ToListAsync());
        // }

        // public async Task<IActionResult> Index(int? id, string sortOrder)
        // {
        //     if (_context.ItemType != null)
        //     {
        //         ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
        //         if (id == null)
        //         {
        //             var first = await _context.ItemType.FirstAsync();
        //             id = first.ItemTypeId;
        //         }
        //     }
        //
        //     // set default sort order to ascending by price
        //     ViewBag.NameSortParam = sortOrder == "name" ? "name_desc" : "name";
        //     ViewBag.PriceSortParam = sortOrder == "price_desc" ? "price" : "price_desc";
        //     var items = _context.Item.Where(t => t.ItemTypeId == id);
        //
        //     // apply sorting based on the sort order parameter
        //     switch (sortOrder)
        //     {
        //         case "name_desc":
        //             items = items.OrderByDescending(t => t.InfoGlowne);
        //             break;
        //         case "price":
        //             items = items.OrderBy(t => t.Cena);
        //             break;
        //         case "price_desc":
        //             items = items.OrderByDescending(t => t.Cena);
        //             break;
        //         default:
        //             items = items.OrderBy(t => t.InfoGlowne);
        //             break;
        //     }
        //
        //     return View(await items.ToListAsync());
        // }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
            return View(await _context.Item.FirstOrDefaultAsync(t => t.ItemId == id));
        }
    }
}



// using Firma.Data.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
//
// namespace Firma.PortalWWW.Controllers
// {
//     public class ShopController : Controller
//     {
//         protected readonly AlmondContext _context;
//
//         public ShopController(AlmondContext context)
//         {
//             _context = context;
//         }
//
//         public async Task<IActionResult> Index(int? id)
//         {
//             if (_context.ItemType != null)
//             {
//                 ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
//                 if (id == null)
//                 {
//                     var first = await _context.ItemType.FirstAsync();
//                     id = first.ItemTypeId;
//                 }
//             }
//             return View(await _context.Item.Where(t => t.ItemTypeId == id).ToListAsync());
//         }
//
//         public async Task<IActionResult> Details(int id) //w parametrze id nie bedzie nulla bo klikamy obiekt
//         {
//             ViewBag.ItemTypes = await _context.ItemType.ToListAsync();
//             //do widoku przekazujemy towar o danym kliknietym id
//             return View(await _context.Item.FirstOrDefaultAsync(t => t.ItemId == id));
//
//         }
//     }
// }