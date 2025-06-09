using InventoryApp.Shared;

public class ProductValidationFilter : IEndpointFilter
{
  // Use Service to avoid trailing data in the List<Product>
  // private readonly List<Product> _products;
  private readonly IProductService _productService;

  public ProductValidationFilter(IProductService productService)
  {
    _productService = productService;
  }

  public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
  {
    var productArgument = context.GetArgument<Product>(0);

    var errors = new Dictionary<string, string[]>();

    if (productArgument.Name == "")
    {
      errors.Add(nameof(Product.Name), ["Product name is required!"]);
    }

    var existingProduct = _productService.GetProducts()
            .FirstOrDefault(product => product.Name.Equals(productArgument.Name, StringComparison.CurrentCultureIgnoreCase));

    if (existingProduct is not null)
    {
      errors.Add(nameof(Product.Name), ["Product already exists!"]);
    }

    if (errors.Count > 0)
    {
      return Results.ValidationProblem(errors);
    }

    return await next(context);
  }

}
