using Backend.Ventas.Interfaces;
using Backend.Ventas.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = "Demo Token ApiKey Example curso jwt backend";

// Add services to the container.

builder.Services.AddControllers();

builder.Services
             .AddAuthentication(
             x =>
             {
                 x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             }
             )
             .AddJwtBearer(
              x =>
              {
                  x.RequireHttpsMetadata = false;
                  x.SaveToken = true;

                  x.TokenValidationParameters = new TokenValidationParameters
                  {
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                      ValidateAudience = false,
                      ValidateIssuerSigningKey = true,
                      ValidateIssuer = false
                  };

              }
              );

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IJwtAuthentication>(new JwtAuthenticationServices(key));
builder.Services.AddSingleton<ICategorias, CategoriaServices>();
builder.Services.AddSingleton<ITransactions, TransactionsServices>();

var app = builder.Build();

//llamar al middleware de la autrenticacion
app.UseAuthentication();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
