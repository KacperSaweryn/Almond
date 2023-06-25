using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Firma.Data.Data.Sklep;

namespace Firma.Data.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Adres jest wymagany")]
        [MaxLength(100, ErrorMessage = "Adres nie może być dłuższy niż 100 znaków")]
        public string ShippingAddress { get; set; }
        [Required(ErrorMessage = "Email jest wymagany")]
        [MaxLength(50, ErrorMessage = "Email nie może być dłuższy niż 50 znaków")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon jest wymagany")]
        [MaxLength(20, ErrorMessage = "Telefon nie może być dłuższy niż 20 znaków")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        public DateTime OrderDate { get; set; }
        public int CartElementId { get; set; }
        public CartElement CartElement { get; set; }
       
    }
}