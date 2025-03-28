using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using STPS.Components;

var builder = WebApplication.CreateBuilder(args);

// Agregar HttpClient a los servicios
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services
    .AddBlazorise(options =>
    {
        // Si deseas otras configuraciones, agrégalas aquí
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons(); // Para usar iconos de Font Awesome, opcional


// Agregar Razor Components con renderizado interactivo
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
