using System.ComponentModel.DataAnnotations;

namespace Firma.Data.Data;

public class User
{
    [Key] public int UserId { get; set; }

    [Required(ErrorMessage = "Imię jest wymagane")]
    [MaxLength(50, ErrorMessage = "Imię może zawierać max 50 znaków")]
    [Display(Name = "Imię")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    [MaxLength(50, ErrorMessage = "Nazwisko może zawierać max 50 znaków")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Adres email jest wymagany")]
    [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Hasło jest wymagane")]
    [DataType(DataType.Password)]
    [Display(Name = "Hasło")]
    public string Password { get; set; }
}