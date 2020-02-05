using Microsoft.EntityFrameworkCore;
using webapp.Models;

namespace webapp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Entreprise> Entreprise { get; set; }
    }
}
