using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Prokast.Server.Entities
{
    public class ProkastServerDbContext: DbContext
    {
        private string _connectionString = "Server=DESKTOP-Q9QL5D9\\SQLEXPRESS;DataBase=Prokrastynejszyn nejszyn; Trusted_Connection=True; TrustServerCertificate=True";
        public DbSet<Account_Log_In2> Account_Log_In2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
