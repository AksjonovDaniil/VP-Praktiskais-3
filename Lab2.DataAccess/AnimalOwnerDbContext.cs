using Microsoft.EntityFrameworkCore;

namespace Lab2.DataAccess
{
    public class AnimalOwnerDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }

        public AnimalOwnerDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databasePath = Path.Combine(
                AppContext.BaseDirectory,
                "AnimalOwnerDb.mdf");

            optionsBuilder.UseSqlServer(
                $"Data Source=(LocalDB)\\MSSQLLocalDB;" +
                $"AttachDbFilename={databasePath};" +
                "Integrated Security=True");
        }
    }
}