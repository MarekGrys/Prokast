using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class CustomParams
    {
        [Key]
        public int ID { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Value { get; set; }

        public required int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public required int RegionID { get; set; }
        public virtual Regions Regions { get; set; }
    }
}
