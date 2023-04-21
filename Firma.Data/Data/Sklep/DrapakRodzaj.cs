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
    public class DrapakRodzaj
    {
        [Key] public int DrapakRodzajId { get; set; }


        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [MaxLength(30, ErrorMessage = "Nazwa może zawierać max 30 znaków")]
        public string Nazwa { get; set; }

        public string Opis { get; set; }
        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }
        public virtual List<Drapak> Drapaks { get; set; }
    }
}
