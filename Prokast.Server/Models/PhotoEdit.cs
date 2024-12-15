using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models
{
    public class PhotoEdit
    {
        [Required]
        public string Name { get; set; }
        
    }
}