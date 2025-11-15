using Microsoft.EntityFrameworkCore;
using RESTApi.Models;

namespace RESTApi.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
