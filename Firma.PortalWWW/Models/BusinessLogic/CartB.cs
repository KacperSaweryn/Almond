using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace Firma.PortalWWW.Models.BusinessLogic
{
    public class CartB
    {
        private readonly AlmondContext _context;

        public CartB(AlmondContext context, HttpContext httpContext)
        {
            _context = context;
            SessionId = GetSessionId(httpContext);
        }

        public string SessionId { get; set; }

        private string GetSessionId(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("SessionId") == null)
            {
                if (!string.IsNullOrEmpty(httpContext.User.Identity.Name))
                {
                   httpContext.Session.SetString("SessionId", httpContext.User.Identity.Name);
                }
                else
                {
                  Guid tempSessionId = Guid.NewGuid();
                   httpContext.Session.SetString("SessionId", tempSessionId.ToString());
                }
            }

            return httpContext.Session.GetString("SessionId").ToString();
        }

        public void AddToCart(Item item)
        {
            var basketElement =
            (
                from element in _context.CartElement
                where element.SessionId == this.SessionId && element.ItemId == item.ItemId
                select element
            ).FirstOrDefault();
            if (basketElement == null)
            {
                basketElement = new CartElement()
                {
                    SessionId = this.SessionId,
                    ItemId = item.ItemId,
                    Item = _context.Item.Find(item.ItemId),
                    Quantity = 1,
                    CreateDateTime = DateTime.Now
                };
                _context.CartElement.Add(basketElement);
            }
            else
            {
                basketElement.Quantity++;
            }

            _context.SaveChanges();
        }

        public async Task<List<CartElement>> GetCartElements()
        {
            return await _context.CartElement.Where(e => e.SessionId == this.SessionId)
                .Include(e => e.Item).ToListAsync();
        }

        public async Task<decimal> GetWholePrice()
        {
            var items =
            (
                from element in _context.CartElement
                where element.SessionId == this.SessionId
                select (decimal?)element.Quantity * element.Item.Cena
            );
            return await items.SumAsync() ?? 0;
        }

        public void ClearCart()
        {
            var cartElements = _context.CartElement.Where(e => e.SessionId == this.SessionId);
            _context.CartElement.RemoveRange(cartElements);
            _context.SaveChanges();
        }

        public void RemoveFromCart(int itemId)
        {
            var cartElement = _context.CartElement.FirstOrDefault(e => e.SessionId == SessionId && e.ItemId == itemId);

            if (cartElement != null)
            {
                _context.CartElement.Remove(cartElement);
                _context.SaveChanges();
            }
        }

    }
}
