using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Shared;

[Table("audit_logs", Schema = "inventory_db")]
public class AuditLog
{
  [Column("id")]
  public int Id { get; set; }

  [Column("user_id")]
  public int UserId { get; set; }

  [Column("action")]
  [MaxLength(10)]
  public required string Action { get; set; } // e.g., "Create", "Update", "Delete"

  [Column("entity_type")]
  [MaxLength(50)]
  public required string EntityType { get; set; } // e.g., "Product", "Sale", "StockAdjustment"

  [Column("details")]
  [MaxLength(200)]
  public string? Details { get; set; } // Additional details about the action

  [Column("timestamp")]
  public DateTime Timestamp { get; set; } // When the action occurred

  [ForeignKey("user_id")]
  public User User { get; set; } = null!; // Reference to the user who performed the action
}
