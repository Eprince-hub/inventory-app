using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace InventoryApp.Shared;

[Table("stock_threshold_alerts", Schema = "inventory_db")]
public class StockThresholdAlert
{
  [Column("id")]
  public int Id { get; set; }

  [Column("product_id")]
  public int ProductId { get; set; }

  [Column("threshold_quantity")]
  public int ThresholdQuantity { get; set; }

  [Column("alert_message")]
  [MaxLength(255)]
  public required string AlertMessage { get; set; }

  [Column("is_active")]
  public bool IsActive { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [ForeignKey("product_id")]
  public Product Product { get; set; } = null!;
}
