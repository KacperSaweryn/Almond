using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Data.Data.Sklep
{
    public class ItemType
    {
        [Key] public int ItemTypeId { get; set; }


        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(30, ErrorMessage = "Nazwa może zawierać max 30 znaków")]
        public string Nazwa { get; set; }

        public string Opis { get; set; }
        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        public virtual List<Item> Item { get; set; } = new List<Item>();
    }
}
