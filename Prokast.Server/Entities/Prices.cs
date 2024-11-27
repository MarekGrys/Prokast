using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Prices
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int RegionID { get; set; }
        [Required]
        public decimal Netto { get; set; }
        [Required]
        public decimal VAT { get; set; }
        [Required]
        public decimal Brutto { get; set; }
        [Required]
        public int PriceListID { get; set; }
    }
}
