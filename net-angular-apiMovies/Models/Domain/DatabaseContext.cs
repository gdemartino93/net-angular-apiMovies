using Microsoft.EntityFrameworkCore;

namespace net_angular_apiMovies.Models.Domain
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts):base(opts)
        {
            
        }
    }
}
