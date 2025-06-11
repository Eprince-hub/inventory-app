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
      var newProduct = product with { Id = service.GetProducts().Count + 1, SKU = Guid.NewGuid().ToString(), IsArchived = false };

      service.AddProduct(newProduct);
      return TypedResults.Created($"/products/{newProduct.Id}", newProduct);
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
