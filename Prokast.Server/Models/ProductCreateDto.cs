using Prokast.Server.Entities;
using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string EAN { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public List<AdditionalNameDto> AdditionalNames { get; set; }
        public List<DictionaryParamsDto>? DictionaryParams { get; set; }

        
        public List<CustomParamsDto>? CustomParams { get; set; }

        public List<PhotoAdd> Photos { get; set; }
        [Required]
        public List <PricesDto> Prices { get; set; }
        [Required]
        public PriceListsCreateDto PriceList { get; set; }
    }
}
