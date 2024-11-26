using Prokast.Server.Entities;
using System.ComponentModel.DataAnnotations;
namespace Prokast.Server.Models.ResponseModels
{
    public class ParamsGetResponse: Response
    {
        [Required]
        public List<CustomParams> Model { get; set; }
    }
}
