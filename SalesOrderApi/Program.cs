using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Registrar la fábrica de conexión a la base de datos
builder.Services.AddSingleton<DbConnectionFactory>(sp =>
    new DbConnectionFactory(builder.Configuration.GetConnectionString("DefaultConnection")!));

// Registrar repositorio y servicio de empleados
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<EmployeesService>();

// Registrar repositorio y servicio de órdenes
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<OrdersService>();

// Registrar repositorio y servicio de productos
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ProductsService>();

// Registrar repositorio y servicio de transportistas (shippers)
builder.Services.AddScoped<IShippersRepository, ShippersRepository>();
builder.Services.AddScoped<ShippersService>();

// Registrar repositorio y servicio de predicción de ventas
builder.Services.AddScoped<ISalesPredictionRepository, SalesPredictionRepository>();
builder.Services.AddScoped<SalesPredictionService>();

// Configurar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Nserio",
        Version = "v1",
        Description = "API prueba tecnica Nserio",
    });
});

var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Nserio v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();