using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class PriceLists
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ClientID { get; set; }
    }
}
