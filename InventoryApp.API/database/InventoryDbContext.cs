using Microsoft.EntityFrameworkCore;
using InventoryApp.Shared;

namespace InventoryApp.API.Data;

public class InventoryDbContext : DbContext
{

  public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

  public DbSet<User> User { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Sale> Sale { get; set; }
  public DbSet<InventoryLog> InventoryLog { get; set; }
  public DbSet<StockThresholdAlert> StockThresholdAlerts { get; set; }
  public DbSet<StockAdjustment> StockAdjustments { get; set; }
  public DbSet<AuditLog> AuditLogs { get; set; }

  // Create a method for seeding initial static data
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>().HasData(
      new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets" },
      new Category { Id = 2, Name = "Furniture", Description = "Home and office furniture" },
      new Category { Id = 3, Name = "Clothing", Description = "Apparel and accessories" }
    );
  }
}
