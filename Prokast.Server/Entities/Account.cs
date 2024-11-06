using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Account
    {
        [Key]
        public int Account_ID { get; set; }
        [Required]
        public string Account_Login { get; set; }
        [Required]
        public string Account_Password { get; set; }
    }
}
