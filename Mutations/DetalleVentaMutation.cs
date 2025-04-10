using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class DetalleVentaMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public DetalleVentaMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
