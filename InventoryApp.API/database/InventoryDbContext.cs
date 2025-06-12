using Microsoft.EntityFrameworkCore;
using InventoryApp.Shared;

namespace InventoryApp.API.Data;

public class InventoryDbContext : DbContext
{

  private readonly IConfiguration configuration;


  // public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

  public DbSet<User> User { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Product> Products { get; set; }
  public DbSet<Sale> Sale { get; set; }
  public DbSet<InventoryLog> InventoryLog { get; set; }
  public DbSet<StockThresholdAlert> StockThresholdAlerts { get; set; }
  public DbSet<StockAdjustment> StockAdjustments { get; set; }
  public DbSet<AuditLog> AuditLogs { get; set; }



  public InventoryDbContext(IConfiguration configuration)
  {
    this.configuration = configuration;
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseNpgsql(configuration.GetConnectionString("InventoryDatabase"));
  }
}
