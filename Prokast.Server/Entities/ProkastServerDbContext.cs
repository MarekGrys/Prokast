using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class ProkastServerDbContext: DbContext
    {
        public ProkastServerDbContext(DbContextOptions<ProkastServerDbContext> options) : base(options) { }
        
        public DbSet<Account> Account { get; set; }
 
    }
}
