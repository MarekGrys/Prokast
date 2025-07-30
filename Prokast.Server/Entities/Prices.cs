using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Prices
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required decimal Netto { get; set; }
        public required decimal VAT { get; set; }
        public required decimal Brutto { get; set; }

        public int RegionID { get; set; }
        public virtual Regions Regions { get; set; }

        public int PriceListID { get; set; }
        public virtual PriceLists PriceLists { get; set; }
    }
}
