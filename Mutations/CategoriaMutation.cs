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

        public async Task<Categoria> CrearCategoria(Categoria input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Categoria.Add(input); 
            await context.SaveChangesAsync();
            return input;
        }

        public async Task<Categoria?> ActualizarCategoria(int id, Categoria input)
        {
            var context = _contextFactory.CreateDbContext();
            var categoria = await context.Categoria.FindAsync(id);
            if (categoria == null) return null;

            categoria.Nombre = input.Nombre;
            categoria.Descripcion = input.Descripcion;

            await context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> EliminarCategoria(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var categoria = await context.Categoria.FindAsync(id);
            if (categoria == null) return false;

            context.Categoria.Remove(categoria);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
