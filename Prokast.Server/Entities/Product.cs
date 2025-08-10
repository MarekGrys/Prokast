using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string SKU { get; set; }
        public required string EAN { get; set; }
        public required string Description { get; set; }
        public DateTime AdditionDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; } = DateTime.Now; 

        public virtual List<AdditionalDescription> AdditionalDescriptions { get; set; }
        public virtual List<AdditionalName> AdditionalNames { get; set; }
        public virtual List<CustomParams> CustomParams { get; set; }
        public List<ProductDictionaryParam> ProductDictionaryParams { get; set; } = [];
        public virtual List<Photo> Photos { get; set; }

        public virtual PriceLists PriceLists { get; set; }

        public required int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public int? StoredProductID { get; set; }
        public virtual StoredProduct? StoredProduct { get; set; }

        public virtual List<OrderProduct>? OrderProducts { get; set; } = [];
    }
}
