using Microsoft.EntityFrameworkCore;
using ProniaTask.Models;

namespace ProniaTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Slide> Slides { get; set; }
    }
}
