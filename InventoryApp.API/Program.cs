// Similar to express server
using InventoryApp.Shared;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Dependencies Injection
builder.Services.AddSingleton<IProductService>(new ProductService());
builder.Services.AddScoped<ProductValidationFilter>();

// App Builder
var app = builder.Build();

app.MapGet("/products", (IProductService service) => service.GetProducts());

app.MapGet("/products/{id}", Results<Ok<Product>, NotFound> (int id, IProductService service) =>
{
  var product = service.GetProduct(id);
  return product is not null ? TypedResults.Ok(product) : TypedResults.NotFound();
});

app.MapPost("/products", (Product product, IProductService service) =>
{
  var newProduct = product with { Id = service.GetProducts().Count + 1, SKU = Guid.NewGuid().ToString(), IsArchived = false };

  service.AddProduct(newProduct);
  return TypedResults.Created($"/products/{newProduct.Id}", newProduct);
}).AddEndpointFilter<ProductValidationFilter>();

app.Run();
