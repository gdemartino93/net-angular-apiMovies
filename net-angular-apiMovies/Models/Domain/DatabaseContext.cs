using Microsoft.EntityFrameworkCore;

namespace net_angular_apiMovies.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
        {

        }
    }
}
