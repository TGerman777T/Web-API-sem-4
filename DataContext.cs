using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace StreamingServiceAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<MovieSeries> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
