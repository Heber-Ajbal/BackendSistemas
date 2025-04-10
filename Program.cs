using Microsoft.EntityFrameworkCore;
using Supermercado.Models;
using Supermercado.Query; // Tu clase Query.cs

var builder = WebApplication.CreateBuilder(args);

// 🔌 Configura la cadena de conexión desde appsettings.json
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔧 Configura el servidor GraphQL con HotChocolate
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    //.AddMutationType<Mutation>() // Descomenta si agregas mutaciones
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// 🧭 Middleware necesario
app.UseRouting(); // importante

// 🔗 Mapeo de GraphQL y activación del playground Banana Cake Pop
app.MapGraphQL(); // disponible en /graphql

app.Run();
