using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Shared;

[Table("inventory_logs", Schema = "inventory_db")]
public class InventoryLog
{
  [Column("id")]
  public int Id { get; set; }
  [Column("product_id")]
  public int ProductId { get; set; }
  [Column("user_id")]
  public int UserId { get; set; }
  [Column("action_type")]
  [MaxLength(3)]
  public required string ActionType { get; set; } // public "IN" or "OUT"
  [Column("quantity_changed")]
  public int QuantityChanged { get; set; }

  [Column("timestamp")]
  public DateTime Timestamp { get; set; }
  [Column("reason")]
  [MaxLength(200)]
  public string? Reason { get; set; }
  [Column("reference_number")]
  [MaxLength(50)]
  public string? ReferenceNumber { get; set; }

  [ForeignKey("product_id")]
  public Product Product { get; set; } = null!;
  [ForeignKey("user_id")]
  public User User { get; set; } = null!;
}
