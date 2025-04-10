using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class DetalleCompraMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public DetalleCompraMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
