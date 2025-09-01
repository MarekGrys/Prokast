using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class PriceLists
    {
        public int ID { get; set; }
        public required string Name { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }

        public virtual List<Prices> Prices { get; set; } 
    }
}
