using Firma.PortalWWW.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Firma.Data.Data;
using Firma.Data.Data.CMS;

namespace Firma.PortalWWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly AlmondContext _context;

        public HomeController(AlmondContext context)
        {
            _context = context;
        }

       

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
            return View(); 
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

            ViewBag.ModelParamsFindUs =
            (
                from parametr in _context.Params 
                where parametr.Typ=="findUs"
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
            ).Take(3).ToList();

            List<Page> list = new List<Page>();
            foreach (Page page in (_context.Page.Where(strona => strona.LinkTytul == "Prywatność" || strona.LinkTytul=="Kontakt").OrderBy(strona => strona.Pozycja))) list.Add(page);
            ViewBag.ModelInformacjeDodatkowe =
            list;



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