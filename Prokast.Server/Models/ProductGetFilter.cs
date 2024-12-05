namespace Prokast.Server.Models
{
    public class ProductGetFilter
    {
        public string? ProductIDList { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string? ProductName { get; set; }
    }
}
