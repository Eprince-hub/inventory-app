
using InventoryApp.Shared;

// Todo: Maybe not necessary as ProductService class can supplement
interface IProductService
{
  List<Product> GetProducts();
  Product? GetProduct(int productId);

  Product AddProduct(Product product);
}

class ProductService : IProductService
{
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

}
