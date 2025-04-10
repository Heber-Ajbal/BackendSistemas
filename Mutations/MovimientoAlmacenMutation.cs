using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class MovimientoAlmacenMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public MovimientoAlmacenMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
