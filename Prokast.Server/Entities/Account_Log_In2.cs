using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Account_Log_In2
    {
        [Key]
        public int Account_ID { get; set; }
        [Required]
        public string Account_Login { get; set; }
        [Required]
        public string Account_Password { get; set; }
    }
}
