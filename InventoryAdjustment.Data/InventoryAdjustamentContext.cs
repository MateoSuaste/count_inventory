using InventoryAdjustment.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;


namespace InventoryAdjustment.Data
{
    public class InventoryAdjustamentContext : DbContext
    {

        public DbSet<Adjustament> Adjustaments { get; set; }
        
        public DbSet<ProductAdjustament> ProductAdjustments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Usuario\\source\\repos\\InventoryAdjustment\\InventoryAdjustment.app\\Database1.mdf;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adjustament>()
                .HasMany(a => a.Products)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
