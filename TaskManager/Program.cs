using Microsoft.EntityFrameworkCore;
using TaskManager.Models;
using Microsoft.OpenApi.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Hinzuf�gen der Swagger-Konfiguration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Task Manager API",
        Version = "v1",
        Description = "Eine API f�r die Verwaltung von Aufgaben und Notizen"
    });
});

// Konfiguriere DbContext mit SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Datenbank und Tabellen erstellen
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        // L�sche die bestehende Datenbank und erstelle sie neu
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        Console.WriteLine("Datenbank wurde neu erstellt!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ein Fehler ist beim Erstellen der Datenbank aufgetreten: " + ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

Console.WriteLine("Anwendung ist gestartet!");
app.Run();