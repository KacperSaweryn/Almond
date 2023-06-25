
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;


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

        [Display(Name = "Tresc")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tresc { get; set; }

        [Display(Name = "Rozwiniecie")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Rozwiniecie { get; set; }

        [AllowNull]
        [DefaultValue("")]
        [Display(Name = "Zdjęcie na stronę")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string FotoUrl { get; set; }
        
        [AllowNull]
        [Display(Name = "Tekst alternatywny")]
        [MaxLength(15, ErrorMessage = "Tekst może zawierać max 15 znaków")]
        public string AltText { get; set; }

        [Display(Name = "Ikona")]
        [MaxLength(30, ErrorMessage = "Nazwa ikony może zawierać max 30 znaków")]
        public string Icon { get; set; }

        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }
    }
}
