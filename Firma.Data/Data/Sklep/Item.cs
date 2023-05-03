
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Firma.Data.Data.Sklep
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Display(Name = "Kolor")]
        [MaxLength(30, ErrorMessage = "Kolor może zawierać max 30 znaków")]
        [Required(ErrorMessage = "Kolor jest wymagany")]
        public string InfoGlowne { get; set; }

        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Opis { get; set; }


        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "Wybierz zdjęcie")]
        public byte[]? Photo { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }
        public int ItemTypeId { get; set; }
        [Required(ErrorMessage = "Pozycja wymagana")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }
        public ItemType ItemType { get; set; }


    }
}
