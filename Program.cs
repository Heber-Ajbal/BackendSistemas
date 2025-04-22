
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

builder.Services.AddAuthorization(); // habilita uso de [Authorize]

// 🔧 Configura HotChocolate (GraphQL)
builder.Services
    .AddGraphQLServer()
    .AddAuthorization() // importante para [Authorize]
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<LoginResponse>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// 🧭 Middleware
app.UseRouting();
app.UseAuthentication(); // 👈 esto es necesario
app.UseAuthorization();  // 👈 y esto también

// 🔗 Activa GraphQL y Banana Cake Pop en /graphql
app.MapGraphQL();

app.Run();
