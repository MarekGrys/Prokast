﻿using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models.OrderModels
{
    public class OrderCreateDto
    {
        [Required]
        public string ShopOrderID { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public decimal TotalWeightKg { get; set; }
        [Required]
        public string PaymentMethod { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime UpdateDate { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"\d{3}-\d{3}-\d{3}$", ErrorMessage = "Phone Number must have format: 123-456-789.")]
        public string PhoneNumber { get; set; }
    }
}
