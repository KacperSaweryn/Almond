using Firma.Data.Data;
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
            CartB cartB = new CartB(this._context, this.HttpContext);
            var basketData = new CartData()
            {
                CartElements = await cartB.GetCartElements(),
                AllDecimal = await cartB.GetWholePrice()
            };

            return View(basketData);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            CartB basketB = new CartB(this._context, this.HttpContext);
            basketB.AddToCart(await _context.Item.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            CartB cartB = new CartB(this._context, this.HttpContext);
            cartB.RemoveFromCart(id);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            CartB cartB = new CartB(this._context, this.HttpContext);
            var cartElement = cartB.GetCartElements().Result.FirstOrDefault(e => e.ItemId == id);

            if (cartElement != null)
            {
                if (quantity < 1)
                {
                    // Remove the item from the cart if the quantity becomes zero or negative
                    cartB.RemoveFromCart(id);
                    return Json(new { success = true, itemId = id, quantity = 0 });
                }
                else
                {
                    cartElement.Quantity = quantity;
                    _context.SaveChanges();
                    return Json(new { success = true, itemId = id, quantity });
                }
            }

            return Json(new { success = false, error = "Item not found in the cart." });
        }



    }
}

