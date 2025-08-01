using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Regions
    {
        public int ID { get; set; }
        public required string Name { get; set; }
    }
}