using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class Warehouse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Postal Code must have format XX-XXX.")]
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [RegularExpression(@"\d{3}-\d{3}-\d{3}$", ErrorMessage = "Phone Number must have format: 123-456-789.")]
        public string PhoneNumber { get; set; }

        public required int ClientID { get; set; }
        public virtual Client Client { get; set; }

        public virtual required List<StoredProduct> StoredProducts { get; set; }
    }
}
