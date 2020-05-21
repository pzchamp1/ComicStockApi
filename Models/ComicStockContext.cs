using Microsoft.EntityFrameworkCore;

namespace ComicStock.Models
{
    public class ComicStockContext : DbContext
    {
        public ComicStockContext(DbContextOptions<ComicStockContext> options) 
            : base(options)
        {
        }
        public DbSet<Supplier> Suppliers {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)        
        {
            modelBuilder.Entity<Supplier>()
            .HasData(new Supplier
                    {
                        Id = 546,
                        Name = "Guns and Roses",
                        City = "Dubai",
                        Reference = "32425453453"
                    });
        }
    }
}