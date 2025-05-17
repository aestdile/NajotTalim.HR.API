using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAcces.Entities;

namespace NajotTalim.HR.DataAcces
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasDefaultValueSql("'sample@email.com'");

            modelBuilder.Entity<Adress>()
                .HasData(
                    new Adress
                    {
                        Id = 10001,
                        AdressLine1 = "76, Uzar Street",
                        AdressLine2 = "Sergeli Region",
                        PostalCode = "7007",
                        City = "Tashkent",
                        Country = "Uzbekistan"
                    }
                );
        }
    }
}
