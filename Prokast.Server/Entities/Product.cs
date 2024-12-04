using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string EAN { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string AdditionalNames { get; set; }
        public string? DictionaryParams { get; set; }
        public string? CustomParams { get; set; }
        [Required]
        public int PriceListID { get; set; }
        public DateTime AdditionDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now;
    }
}
