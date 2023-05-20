using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

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

        // [AllowNull]
        // [DefaultValue("")]
        // [Display(Name = "Zdjęcie na stronę")]
        // [Column(TypeName = "nvarchar(MAX)")]
        // public string FotoUrl { get; set; }

        [AllowNull]
        [Display(Name = "Górne zdjęcie na stronę")]
        public byte[] FotoUrl { get; set; }

        [AllowNull]
        [Display(Name = "Tekst alternatywny")]
        [MaxLength(15, ErrorMessage = "Tekst może zawierać max 15 znaków")]
        public string AltText { get; set; }

        // [AllowNull]
        // [DefaultValue("")]
        // [Display(Name = "Dolne zdjęcie na stronę")]
        // [Column(TypeName = "nvarchar(MAX)")]
        // public string FotoUrlDown { get; set; }
        [AllowNull]
        [Display(Name = "Dolne zdjęcie na stronę")]
        public byte[] FotoUrlDown { get; set; }

        [AllowNull]
        [Display(Name = "Tekst alternatywny drugiego zdjecia")]
        [MaxLength(15, ErrorMessage = "Tekst może zawierać max 15 znaków")]
        public string AltTextDown { get; set; }

        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

    }
}
