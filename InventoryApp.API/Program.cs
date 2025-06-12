// Similar to express server
using InventoryApp.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Dependencies Injection
// builder.Services.AddSingleton<IProductService>(new ProductService());
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("InventoryDatabase")));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ProductValidationFilter>();

// App Builder
var app = builder.Build();

app.MapProductRoutes();

app.Run();
