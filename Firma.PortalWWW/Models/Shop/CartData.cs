using Firma.Data.Data.Sklep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Models.Shop
{
    public class CartData
    {
        public List<CartElement> CartElements { get; set; }
        public decimal AllDecimal { get; set; }

    }
}
