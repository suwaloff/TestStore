using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestStore.Data;
using TestStore.Models;

namespace TestStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
