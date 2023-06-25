using System.ComponentModel.DataAnnotations;


namespace Firma.Data.Data.CMS
{
    public class DefaultTest
    {
        [Key]
        public int IdDef { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagany")]
        [MaxLength(15, ErrorMessage = "Nazwa może zawierać max 15 znaków")]
        [Display(Name = "Nazwa odnośnika")]
        public string Name { get; set; }
    }
}