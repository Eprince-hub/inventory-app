
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
  private readonly List<Product> _products = [];

  public Product? GetProduct(int productId)
  {
    return _products.FirstOrDefault(product => product.Id == productId);
  }

  public Product AddProduct(Product product)
  {
    _products.Add(product);
    return product;
  }

  public List<Product> GetProducts()
  {
    return _products;
  }

  public Product UpdateProduct(Product product, int productId)
  {
    var existingProduct = GetProduct(productId);
    if (existingProduct == null)
    {
      throw new KeyNotFoundException($"Product with ID {product.Id} not found.");
    }

    // var updatedProduct = existingProduct with
    // {
    //   Name = product.Name,
    //   // Other properties
    // };

    existingProduct.Name = product.Name;

    // _products.Remove(existingProduct);
    // _products.Add(updatedProduct);
    return existingProduct;
  }

  public Product DeleteProduct(int productId)
  {
    var product = GetProduct(productId);
    if (product == null)
    {
      throw new KeyNotFoundException($"Product with ID {productId} not found.");
    }

    _products.Remove(product);
    return product;
  }
}
