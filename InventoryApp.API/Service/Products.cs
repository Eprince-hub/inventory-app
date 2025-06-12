
using InventoryApp.API.Data;
using InventoryApp.Shared;

// Todo: Maybe not necessary as ProductService class can supplement
public interface IProductService
{
  List<Product> GetProducts();
  Product? GetProduct(int productId);

  Product AddProduct(Product product);

  Product UpdateProduct(Product product, int productId);

  Product DeleteProduct(int productId);
}

class ProductService : IProductService
{
  // Source of truth for products
  // In-memory data persistence for simplicity
  // private readonly List<Product> _products = [];

  // Postgres database context
  private readonly InventoryDbContext _db;

  public ProductService(InventoryDbContext db)
  {
    _db = db;
  }

  public List<Product> GetProducts()
  {
    return _db.Products.ToList();
  }

  public Product? GetProduct(int productId)
  {
    return _db.Products.Find(productId);
  }

  public Product AddProduct(Product product)
  {
    _db.Products.Add(product);
    _db.SaveChanges();
    return product;
  }

  public Product UpdateProduct(Product product, int productId)
  {
    var existingProduct = GetProduct(productId);
    if (existingProduct == null)
    {
      throw new KeyNotFoundException($"Product with ID {product.Id} not found.");
    }
    existingProduct.Name = product.Name;
    existingProduct.Quantity = product.Quantity;

    _db.SaveChanges();
    return existingProduct;
  }

  public Product DeleteProduct(int productId)
  {
    var product = GetProduct(productId);
    if (product == null)
    {
      throw new KeyNotFoundException($"Product with ID {productId} not found.");
    }

    _db.Products.Remove(product);
    _db.SaveChanges();
    return product;
  }
}
