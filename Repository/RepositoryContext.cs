using Microsoft.EntityFrameworkCore;
using my_tv_shows.Models;

namespace my_tv_shows
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Serie> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=serie_database.db");
        }

    }
}
