using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class CategoriaMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public CategoriaMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
