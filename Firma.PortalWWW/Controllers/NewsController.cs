using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Firma.PortalWWW.Controllers
{
    public class NewsController : HomeController
    {
        public IActionResult Index()
        {
            return View();
        }

        public NewsController(AlmondContext context) : base(context)
        {
        }
    }
}
