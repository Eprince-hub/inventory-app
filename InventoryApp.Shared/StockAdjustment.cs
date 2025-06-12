using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryApp.Shared;

[Table("stock_adjustments", Schema = "inventory_db")]
public class StockAdjustment
{
  [Column("id")]
  public int Id { get; set; }

  [Column("product_id")]
  public int ProductId { get; set; }

  [Column("quantity")]
  public int Quantity { get; set; }

  [Column("adjustment_type")]
  [MaxLength(20)]
  public required string AdjustmentType { get; set; } // "Damage", "Loss", "Correction"

  [Column("notes")]
  [MaxLength(200)]
  public string? Notes { get; set; }

  [Column("adjusted_by_user_id")]
  public int AdjustedByUserId { get; set; }

  [Column("timestamp")]
  public DateTime Timestamp { get; set; }

  [ForeignKey("product_id")]
  public Product Product { get; set; } = null!;

  [ForeignKey("adjusted_by_user_id")]
  public User User { get; set; } = null!;
}






/*
public record StockAdjustment(
    int Id,
    int ProductId,
    int Quantity,
    string AdjustmentType,       // "Damage", "Loss", "Correction"
    string? Notes,
    int AdjustedByUserId,
    DateTime Timestamp
);
 */
