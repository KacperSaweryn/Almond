using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


namespace Firma.Data.Data.CMS
{
    public class Cat
    {
        [Key]
        public int KotId { get; set; }

        [Required(ErrorMessage = "Rasa jest wymagana")]
        [MaxLength(30, ErrorMessage = "Rasa może zawierać max 30 znaków")]
        [Display(Name = "Rasa")]
        public string Rasa { get; set; }

        [Display(Name = "Kolor")]
        [MaxLength(30, ErrorMessage = "Kolor może zawierać max 30 znaków")]
        [Required(ErrorMessage = "Kolor jest wymagany")]
        public string Kolor { get; set; }

        [Display(Name = "Imie")]
        [Column(TypeName = "nvarchar(30)")]
        public string Imie { get; set; }

        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Opis { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "Wybierz zdjęcie")]
        public string FotoUrl { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }
        

    }
}