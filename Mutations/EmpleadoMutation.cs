using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class EmpleadoMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public EmpleadoMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
    }
}
