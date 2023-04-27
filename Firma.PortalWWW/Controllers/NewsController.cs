using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics;
using Firma.PortalWWW.Models;

namespace Firma.PortalWWW.Controllers
{
    public class NewsController : Controller
    {

        private readonly ILogger<NewsController> _logger;
        protected readonly AlmondContext _context;

        public NewsController(AlmondContext context)
        {
            _context = context;
        }

        [SuppressMessage("ReSharper.DPA", "DPA0009: High execution time of DB command", MessageId = "time: 1123ms")]
        public IActionResult Index(int id)
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
            ViewBag.ModelAktualnosci =
            (
                from aktualnosc in _context.News
                orderby aktualnosc.Pozycja
                select aktualnosc
            ).ToList();

            // if (id == null)
            // {
            //     id = _context.Page.First().IdStrony;
            // }

            var item = _context.News.Find(id);
            return View(item);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      

       
    }
}
