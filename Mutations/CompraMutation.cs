using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class CompraMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public CompraMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
