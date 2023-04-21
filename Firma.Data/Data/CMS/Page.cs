using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Firma.Data.Data.CMS
{
    
    public class Page
    {
        [Key]
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(15,ErrorMessage = "Tytuł może zawierać max 15 znaków")]
        [Display(Name = "Tytuł odnośnika do strony")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytuł może zawierać max 30 znaków")]
        [Display(Name = "Tytuł strony")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }

        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

    }
}
