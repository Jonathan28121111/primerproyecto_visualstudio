using Microsoft.Data.Sqlite;
using primerproyecto.Components;
using primerproyecto.Components.Data;
using primerproyecto.Components.Servicio;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddSingleton<ServicioControlador>();
builder.Services.AddSingleton<ServicioJuegos>();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

string ruta = "mibase.db";

using var conexion = new SqliteConnection($"DataSource={ruta}");
conexion.Open();
var comando = conexion.CreateCommand();
comando.CommandText = @"
CREATE TABLE IF NOT EXISTS Juegos ( Identificador integer, nombre text, jugado integer )";
comando.ExecuteNonQuery();


app.Run();