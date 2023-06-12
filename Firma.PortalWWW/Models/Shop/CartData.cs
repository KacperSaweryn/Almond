using Firma.Data.Data.Sklep;

namespace Firma.PortalWWW.Models.Shop
{
    public class CartData
    {
        public List<CartElement> CartElements { get; set; }
        public decimal AllDecimal { get; set; }

    }
}
