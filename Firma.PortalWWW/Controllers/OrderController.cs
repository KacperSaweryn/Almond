using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Firma.PortalWWW.Controllers
{
    public class OrderController : Controller
    {
        private readonly AlmondContext _context;

        public OrderController(AlmondContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult ShippingDetails()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShippingDetails(Order order)
        {
            order.CartElementId = 1;
            order.OrderDate = DateTime.Now;
            if (ModelState.IsValid)
            {
               _context.Order.Add(order);
                _context.SaveChanges();

                return RedirectToAction("OrderConfirmation");
            }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
            }


            return View(order);
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}