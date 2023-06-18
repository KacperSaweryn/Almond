// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using Firma.Data.Data.Sklep;
//
// namespace Firma.Data.Data
// {
//     public class Order
//     {
//         [Key]
//         public int OrderId { get; set; }
//
//         [Required(ErrorMessage = "Shipping address is required")]
//         [MaxLength(100, ErrorMessage = "Shipping address cannot exceed 100 characters")]
//         public string ShippingAddress { get; set; }
//
//         [Required(ErrorMessage = "Order date is required")]
//         public DateTime OrderDate { get; set; }
//
//         public List<CartElement> CartElements { get; set; }
//     }
// }