using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryApp.Shared;

[Table("products", Schema = "inventory_db")]
public class Product
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    [MaxLength(80)]
    public required string Name { get; set; }
    [Column("sku")]
    [MaxLength(100)]
    public required string SKU { get; set; }
    [Column("quantity")]
    public int Quantity { get; set; }
    [Column("category_id")]
    public int CategoryId { get; set; }
    [Column("cost_price", TypeName = "decimal(18,2)")]
    public decimal CostPrice { get; set; }
    [Column("selling_price", TypeName = "decimal(18,2)")]
    public decimal SellingPrice { get; set; }
    [Column("is_archived")]
    public bool IsArchived { get; set; }
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    [Column("qr_code_path")]
    [MaxLength(255)]
    public string? QRCodePath { get; set; }
    [Column("image_path")]
    [MaxLength(255)]
    public string? ImagePath { get; set; }
    [Column("unit_of_measure")]
    [MaxLength(20)]
    public string? UnitOfMeasure { get; set; }
    [Column("description")]
    [MaxLength(500)]
    public string? Description { get; set; }

    [ForeignKey("category_id")]
    public Category Category { get; set; } = null!;
};

// public record Product(
//     int Id,
//     string Name,
//     string SKU,
//     int Quantity,
//     bool IsArchived,
//     DateTime CreatedAt,
//     string? QRCodePath,
//     string? ImagePath,
//     string? UnitOfMeasure,
//     string? Description
// );
