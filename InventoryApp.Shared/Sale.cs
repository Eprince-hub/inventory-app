using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Shared;

[Table("sales", Schema = "inventory_db")]

public class Sale
{
  [Column("id")]
  public int Id { get; set; }

  [Column("product_id")]
  public int ProductId { get; set; }

  [Column("quantity")]
  public int Quantity { get; set; }

  [Column("sale_price", TypeName = "decimal(18,2)")]
  public decimal SalePrice { get; set; }

  [Column("sale_date")]
  public DateTime SaleDate { get; set; }

  [Column("timestamp")]
  public DateTime Timestamp { get; set; }

  [Column("customer_name")]
  [MaxLength(80)]
  public string? CustomerName { get; set; }

  [Column("sold_by_user_id")]
  public int SoldByUserId { get; set; }

  [ForeignKey("product_id")]
  public Product Product { get; set; } = null!;

  [ForeignKey("sold_by_user_id")]
  public User User { get; set; } = null!;
}
