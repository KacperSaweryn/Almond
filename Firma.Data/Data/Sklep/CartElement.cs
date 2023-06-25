using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class CartElement
    {
        [Key]
        public int CartElementId { get; set; }
        public string SessionId { get; set; } 
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDateTime { get; set; }


    }
}
