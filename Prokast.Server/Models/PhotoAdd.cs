using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models
{
    public class PhotoAdd
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Value { get; set; }
    }
}