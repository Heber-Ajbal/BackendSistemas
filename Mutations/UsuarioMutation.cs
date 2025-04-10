using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class UsuarioMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UsuarioMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
