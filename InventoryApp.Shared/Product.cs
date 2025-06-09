namespace InventoryApp.Shared;

public record Product(
    int Id,
    string Name,
    string SKU,
    int Quantity,
    bool IsArchived,
    DateTime CreatedAt,
    string? QRCodePath,
    string? ImagePath,
    string? UnitOfMeasure,
    string? Description
);
