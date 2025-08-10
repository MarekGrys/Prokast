namespace Prokast.Server.Entities
{
    public class ProductDictionaryParam
    {
        public int ID { get; set; }
        
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int DictionaryParamID { get; set; }
        public DictionaryParams DictionaryParam { get; set; }
    }
}
