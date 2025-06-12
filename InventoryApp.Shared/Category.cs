using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Shared;

[Table("categories", Schema = "inventory_db")]
public class Category
{
  [Column("id")]
  public int Id { get; set; }
  [Column("name")]
  [MaxLength(80)]
  public required string Name { get; set; }
  [Column("description")]
  [MaxLength(200)]
  public string? Description { get; set; }
}
