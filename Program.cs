using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Agregar Entity Framework
builder.Services.AddDbContext<ToDoApp.Data.ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Inicializar base de datos
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ToDoApp.Data.ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// Configurar puerto para Render
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
var host = Environment.GetEnvironmentVariable("ASPNETCORE_URLS") ?? "http://localhost:5000";

if (Environment.GetEnvironmentVariable("PORT") != null)
{
    // En Render, usar 0.0.0.0 para escuchar en todas las interfaces
    app.Run($"http://0.0.0.0:{port}");
}
else
{
    // En desarrollo local, usar la configuración estándar
    app.Run(host);
}
