using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models.ResponseModels
{
    public class ErrorResponse: Response
    {
        [Required]
        public string errorMsg { get; set; }
    }
}
