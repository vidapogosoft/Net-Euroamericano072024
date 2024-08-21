using BlazorApp1;
using BlazorApp1.Models;
using BlazorApp1.Repositorio;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Runtime.CompilerServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//ConfigureServices(builder.Services);

//builder.Services.AddScoped<CategoriaRepositorio>();

await builder.Build().RunAsync();


//static void ConfigureServices(IServiceCollection services)
//{
//    services.AddScoped<IRepositorio, CategoriaRepositorio>();
//}