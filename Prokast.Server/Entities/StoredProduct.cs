﻿using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class StoredProduct
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int WarehouseID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int MinQuantity { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
