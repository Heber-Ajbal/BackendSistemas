using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class ProductoMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ProductoMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
