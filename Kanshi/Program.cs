using Kanshi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KanshiDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddCors(options =>
{
    options.AddPolicy("Svelte", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("Svelte");

app.MapControllers();

var logger = app.Logger;

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<KanshiDbContext>();

    try
    {
        logger.LogInformation("🔌 Test de connexion à PostgreSQL...");

        var connected = await db.Database.CanConnectAsync();

        if (connected)
        {
            logger.LogInformation("✅ Connexion à PostgreSQL réussie !");
        }
        else
        {
            logger.LogError("❌ Impossible de se connecter à PostgreSQL.");
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "❌ Erreur de connexion PostgreSQL.");
    }
}

app.Run();