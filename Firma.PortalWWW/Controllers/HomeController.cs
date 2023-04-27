using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Firma.Data.Data;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AlmondContext _context;

        public HomeController(AlmondContext context)
        {
            _context = context;
        }

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }

        // public IActionResult Index()
        // {
            // ViewBag.ModelParams =
            // (
            //     from parametr in _context.Params
            //     orderby parametr.Pozycja
            //     select parametr
            // ).ToList();
            //
            // ViewBag.ModelStrony =
            // (
            //     from strona in _context.Page
            //     orderby strona.Pozycja
            //     select strona
            // ).ToList();
            //
            //
            // if (id == null)
            // {
            //return View();
            //     //id = _context.Page.First().IdStrony;
            // }
            // else
            // {
            //     var item = _context.Page.Find(id);
            //     return View(item);
            // }
            // if (id == null)
            // {
            //    // return View();
            //     id = _context.Page.First().IdStrony;
            // }
            //
            //     var item = _context.Page.Find(id);
            //     return View(item);


            // var item = _context.Page.Find(id);
            // return View(item);

            //odnajdujemy w DB strone o danym id
            // var item = _context.Page.Find(id);
            //
            //
            // return View(item);
       // }


        // public IActionResult Index()
        // {
        //     return View();
        // }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Company()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View(); //widok będzie nazywał sie tak samo jak funkcja wiec mozna -> return View()
        }

        [SuppressMessage("ReSharper.DPA", "DPA0009: High execution time of DB command", MessageId = "time: 1123ms")]
        public IActionResult Index(int? id)
        {
            ViewBag.ModelParams =
            (
                from parametr in _context.Params
                orderby parametr.Pozycja
                select parametr
            ).ToList();

            ViewBag.ModelStrony =
            (
                from strona in _context.Page
                orderby strona.Pozycja
                select strona
            ).ToList();


            if (id == null)
            {
                id = _context.Page.First().IdStrony;
            }

            var item = _context.Page.Find(id);
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}