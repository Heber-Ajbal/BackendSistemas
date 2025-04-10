using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class AlmacenMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;
    }
}
