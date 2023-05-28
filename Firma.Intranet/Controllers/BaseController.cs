﻿using Firma.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

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
        public virtual IActionResult Create()
        {
            // ReSharper disable once Mvc.ViewNotResolved
            return View();
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