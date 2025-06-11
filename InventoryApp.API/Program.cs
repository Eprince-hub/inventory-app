// Similar to express server
var builder = WebApplication.CreateBuilder(args);

// Dependencies Injection
builder.Services.AddSingleton<IProductService>(new ProductService());
builder.Services.AddScoped<ProductValidationFilter>();

// App Builder
var app = builder.Build();

app.MapProductRoutes();

app.Run();
