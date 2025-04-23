using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Supermercado.Models;
using Supermercado.Mutations;
using Supermercado.Query;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Configura la cadena de conexión desde appsettings.json
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔐 Configura autenticación JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "SupermercadoAPI",
            ValidAudience = "SupermercadoFront",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("CLAVESECRETA_SUPERMERCADO"))
        };
    });

builder.Services.AddAuthorization();

// ✅ CORS para permitir acceso desde Nuxt frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNuxt", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000") // ← tu frontend
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// 🔧 Configura HotChocolate (GraphQL)
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<LoginResponse>()
    .AddType<DecimalType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// 🧭 Middleware
app.UseCors("AllowNuxt"); // 👈 esto va ANTES de Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL(); // GraphQL endpoint

app.Run();
