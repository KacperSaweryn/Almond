
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Firma.Data.Data.CMS
{
    public class News
    {
        [Key]
        public int IdAktualnosci { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(15, ErrorMessage = "Tytuł może zawierać max 15 znaków")]
        [Display(Name = "Tytuł odnośnika do aktualnosci")]
        public string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany")]
        [MaxLength(30, ErrorMessage = "Tytuł może zawierać max 30 znaków")]
        [Display(Name = "Tytuł aktualnosci")]
        public string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }

        [Display(Name = "Ikona")]
        [MaxLength(30, ErrorMessage = "Nazwa ikony może zawierać max 30 znaków")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }
    }
}
