using AnimalsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalsWeb.Controllers
{
    public class AnimalDbContext : DbContext
    {
        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options) { }

        public DbSet<Animal> Animals { get; set; }
    }
}