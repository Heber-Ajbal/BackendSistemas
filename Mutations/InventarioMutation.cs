using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class InventarioMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public InventarioMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
