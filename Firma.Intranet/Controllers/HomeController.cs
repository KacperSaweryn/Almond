using Firma.Intranet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Firma.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Firma.Intranet.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlmondContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // public HomeController(AlmondContext context)
        // {
        //     _context = context;
        // }


        // public IActionResult Index(int? id)
        // {
        //     
        //     ViewBag.ModelStrony =
        //     (
        //         from strona in _context.Page
        //         orderby strona.Pozycja
        //         select strona
        //     ).ToList();
        //     if (id == null)
        //     {
        //         // return View();
        //         id = _context.Page.First().IdStrony;
        //        
        //     }
        //     // else
        //     // {
        //     //     var item = _context.Page.Find(id);
        //     //     return View(item);
        //     // }
        //    
        //         var item = _context.Page.Find(id);
        //         return View(item);
        //     
        //     //odnajdujemy w DB strone o danym id
        //     // var item = _context.Page.Find(id);
        //     //
        //     //
        //     // return View(item);
        // }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}