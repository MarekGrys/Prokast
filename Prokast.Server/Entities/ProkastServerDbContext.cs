using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class ProkastServerDbContext: DbContext
    {
        public ProkastServerDbContext(DbContextOptions<ProkastServerDbContext> options) : base(options) { }
        
        public DbSet<AccountLogIn> AccountLogIn { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CustomParams> CustomParams { get; set; }
        public DbSet<DictionaryParams> DictionaryParams { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<PriceLists> PriceLists { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<AdditionalName> AdditionalName { get; set; }
        public DbSet<Product> Products { get; set; }
 
    }
}
