using Microsoft.EntityFrameworkCore;

namespace MVCCar.Models
{
    // MVCCarContext nasljeđuje DbContext, što mu daje funkcionalnost za rad s bazom
    public class MVCCarContext : DbContext
    {
        // KONSTRUKTOR: Nužan za konfiguraciju i Dependency Injection
        public MVCCarContext(DbContextOptions<MVCCarContext> options) : base(options)
        {

        }

        // DBSET: Ovo Entity Frameworku govori da kreira tablicu "Car" u bazi
        public DbSet<Car> Car { get; set; }
    }
}