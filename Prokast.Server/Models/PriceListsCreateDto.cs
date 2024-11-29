using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models
{
    public class PriceListsCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
