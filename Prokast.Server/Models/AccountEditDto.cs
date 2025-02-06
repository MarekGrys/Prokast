using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Models
{
    public class AccountEditDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public int WarehouseID { get; set; }
        [Required]
        public int Role { get; set; }

    }
}
