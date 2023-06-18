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

        [Required(ErrorMessage = "Shipping address is required")]
        [MaxLength(100, ErrorMessage = "Shipping address cannot exceed 100 characters")]
        public string ShippingAddress { get; set; }
        [MaxLength(50, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [MaxLength(20, ErrorMessage = "Phone cannot exceed 100 characters")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Order date is required")]
        public DateTime OrderDate { get; set; }
        public int CartElementId { get; set; }
        public CartElement CartElement { get; set; }
       
    }
}