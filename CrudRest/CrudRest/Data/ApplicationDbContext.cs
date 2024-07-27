using CrudRest.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudRest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnName("product_name").HasColumnType("varchar(255)");
                entity.Property(e => e.Price).HasColumnName("price").HasColumnType("decimal(18,2)");
                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
