using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class AdditionalDescription
    {
        public required int ID { get; set; }
        public required string Title { get; set; }
        public required int Region {  get; set; }
        public required string Value { get; set; }

        public required int productID { get; set; }
        public virtual Product Product { get; set; }

        public required int RegionID { get; set; }
        public virtual Regions Regions { get; set; }
    }
}
