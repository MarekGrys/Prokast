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

        public virtual required List<AdditionalDescription> AdditionalDescriptions { get; set; }
        public virtual required List<AdditionalName> AdditionalNames { get; set; }
        public required List<CustomParams> CustomParams { get; set; }
        public required List<DictionaryParams> DictionaryParams { get; set; }
        public required List<Photo> Photos { get; set; }

        public required int PriceListId { get; set; }
        public virtual PriceLists PriceLists { get; set; }

        public required int ClientID { get; set; }
        public virtual Client Client { get; set; }
    }
}
