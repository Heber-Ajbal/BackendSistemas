using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class VentaMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public VentaMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
