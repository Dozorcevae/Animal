using Microsoft.EntityFrameworkCore;
using AnimalsWeb.Models;

namespace AnimalsWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Animal> Animals { get; set; }
    }
}
