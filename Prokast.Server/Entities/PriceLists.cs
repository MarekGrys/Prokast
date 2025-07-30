using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class PriceLists
    {
        public required int ID { get; set; }
        public required string Name { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public virtual required List<Prices> Prices { get; set; } 
    }
}
