using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models
{
    public class PriceListsDto
    {
        [Required]
        public string Name { get; set; }
    }
}
