using GYF_Stock_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace GYF_Stock_Management.Data
{
    public class dbContext: DbContext
    {
        public dbContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
           .Navigation(b => b.Categories)
           .UsePropertyAccessMode(PropertyAccessMode.Property);
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
