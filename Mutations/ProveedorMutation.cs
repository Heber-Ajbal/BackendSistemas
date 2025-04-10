using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class ProveedorMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ProveedorMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
