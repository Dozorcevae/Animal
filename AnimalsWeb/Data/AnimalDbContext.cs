using AnimalsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimaslWeb.Data
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
    }
}