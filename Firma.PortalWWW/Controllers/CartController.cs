﻿using Firma.Data.Data;
using Firma.PortalWWW.Models.BusinessLogic;
using Firma.PortalWWW.Models.Shop;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Firma.PortalWWW.Controllers
{
    public class CartController : Controller
    {
        public readonly AlmondContext _context;

        public CartController(AlmondContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            CartB basketB = new CartB(this._context, this.HttpContext);
            var basketData = new CartData()
            {
                CartElements = await basketB.GetCartElements(),
                AllDecimal = await basketB.GetWholePrice()
            };

            return View();
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            CartB basketB = new CartB(this._context, this.HttpContext);
            basketB.AddToCart(await _context.Item.FindAsync(id));
            return RedirectToAction("Index");
        }
    }
}
