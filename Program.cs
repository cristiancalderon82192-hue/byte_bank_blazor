using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using byte_bank_blazor;
using ByteBank.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configurar HttpClient para la API
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:8000") 
});

// Registrar servicios
builder.Services.AddScoped<CuentaService>();
builder.Services.AddScoped<CuentahabienteService>();
builder.Services.AddScoped<MovimientoService>();
builder.Services.AddScoped<PrestamoService>();
builder.Services.AddScoped<CatalogoService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();