using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Firma.Intranet.Controllers
{
    public abstract class BaseController<T> : Controller
    {
        public readonly AlmondContext _context;

        protected BaseController(AlmondContext context)
        {
            _context = context;
        }

        public abstract Task<List<T>> GetEntityList();
        public  virtual async Task<IActionResult> Create()
        {
           // await SetSelectList();
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
        public virtual Task SetSelectList()
        {
            //null bo moze nie miec selectListy
            return null;
        }
        public virtual async Task<IActionResult> Index()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View(await GetEntityList());
        }

        public virtual async Task<IActionResult> Edit(int? id)
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }

        public virtual async Task<IActionResult> Delete(int? id)
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }

        public virtual async Task<IActionResult> Details(int? id)
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
        }
    }
}