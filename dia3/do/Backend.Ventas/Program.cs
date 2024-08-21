using Backend.Ventas.Interfaces;
using Backend.Ventas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string MyAllowSpecificOrigins = "appweb";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:5219", "http://localhost:5219/Categoria/Index")
                          .AllowAnyOrigin()
                          .AllowAnyHeader()
                           .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();

builder.Services.AddSingleton<ICategorias, CategoriaServices>();
builder.Services.AddSingleton<ITransactions, TransactionsServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
