using Microsoft.AspNetCore.Http.HttpResults;
using InventoryApp.Shared;

public static class ProductRoutes
{
  public static IEndpointRouteBuilder MapProductRoutes(this IEndpointRouteBuilder app)
  {
    var productRouteGroup = app.MapGroup("/api/products");


    productRouteGroup.MapGet("/", (IProductService service) => service.GetProducts());

    productRouteGroup.MapGet("/{id}", Results<Ok<Product>, NotFound> (int id, IProductService service) =>
    {
      var product = service.GetProduct(id);
      return product is not null ? TypedResults.Ok(product) : TypedResults.NotFound();
    });

    productRouteGroup.MapPost("/create", (Product product, IProductService service) =>
    {
      // var newProduct = new Product
      // {
      //   Id = service.GetProducts().Count + 1,
      //   SKU = Guid.NewGuid().ToString(),
      //   Name = product.Name,
      //   Quantity = product.Quantity,
      //   IsArchived = false, // Default value for new products
      //   CreatedAt = DateTime.UtcNow, // Set the creation time to now
      //   QRCodePath = product.QRCodePath,
      //   ImagePath = product.ImagePath,
      //   UnitOfMeasure = product.UnitOfMeasure,
      //   Description = product.Description
      // };
      // var newProduct = product with { Id = service.GetProducts().Count + 1, SKU = Guid.NewGuid().ToString(), IsArchived = false };

      service.AddProduct(product);
      return TypedResults.Created($"/products/{product.Id}", product);
    }).AddEndpointFilter<ProductValidationFilter>();

    productRouteGroup.MapPut("/{id}", (Product product, int id, IProductService service) =>
    {
      return service.UpdateProduct(product, id);
    });

    productRouteGroup.MapDelete("/{id}", (int id, IProductService service) =>
    {
      var product = service.DeleteProduct(id);
    });

    return app;
  }
}
