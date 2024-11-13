using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class CustomParams
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
