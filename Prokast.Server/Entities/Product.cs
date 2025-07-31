using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Product
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required string SKU { get; set; }
        public required string EAN { get; set; }
        public required string Description { get; set; }
        public required DateTime AdditionDate { get; set; } = DateTime.Now;
        public required DateTime ModificationDate { get; set; } = DateTime.Now; 

        public virtual List<AdditionalDescription> AdditionalDescriptions { get; set; }
        public virtual List<AdditionalName> AdditionalNames { get; set; }
        public virtual List<CustomParams> CustomParams { get; set; }
        public virtual List<DictionaryParams> DictionaryParams { get; set; }
        public virtual List<Photo> Photos { get; set; }

        public required int PriceListID { get; set; }
        public virtual PriceLists PriceLists { get; set; }

        public required int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
