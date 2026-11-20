using Kanshi.Data;
using Microsoft.EntityFrameworkCore;
using Kanshi.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Kanshi.Services;


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
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<AuthService>();

var jwtKey = builder.Configuration["Jwt:Key"]!;

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            ),

            RoleClaimType = System.Security.Claims.ClaimTypes.Role
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider
//         .GetRequiredService<KanshiDbContext>();

//     await UserSeeder.SeedAsync(context);
// }

app.UseCors("Svelte");

app.UseAuthentication();
app.UseAuthorization();

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