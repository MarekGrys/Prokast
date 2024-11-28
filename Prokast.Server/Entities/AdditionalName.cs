using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class AdditionalName
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Region { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
