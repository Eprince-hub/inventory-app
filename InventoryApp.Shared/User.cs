using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace InventoryApp.Shared;

[Table("users", Schema = "inventory_db")]
public class User
{
  [Column("id")]
  public int Id { get; set; }
  [Column("username")]
  [MaxLength(50)]
  public required string Username { get; set; }
  [Column("email")]
  [MaxLength(100)]
  [EmailAddress]
  public required string Email { get; set; }
  [Column("password_hash")]
  [MaxLength(255)]
  public required string PasswordHash { get; set; }
  [Column("role")]
  [MaxLength(20)]
  public required string Role { get; set; }
  [Column("is_active")]
  public bool IsActive { get; set; }
  [Column("created_at")]
  public DateTime CreatedAt { get; set; }
  [Column("last_login")]
  public DateTime? LastLogin { get; set; }
}
