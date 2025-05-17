using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAcces
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        { 

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        
    }
}
