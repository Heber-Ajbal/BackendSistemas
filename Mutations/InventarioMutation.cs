using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class InventarioMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public InventarioMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Crear un nuevo inventario
        public async Task<Inventario> CrearInventario(Inventario input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Inventarios.Add(input); 
            await context.SaveChangesAsync();
            return input;
        }

        // Actualizar un inventario existente
        public async Task<Inventario?> ActualizarInventario(int id, Inventario input)
        {
            var context = _contextFactory.CreateDbContext();
            var inventario = await context.Inventarios.FindAsync(id);
            if (inventario == null) return null;

            inventario.CodProducto = input.CodProducto ?? inventario.CodProducto;
            inventario.IdAlmacen = input.IdAlmacen ?? inventario.IdAlmacen;
            inventario.Cantidad = input.Cantidad ?? inventario.Cantidad;
            inventario.Ubicacion = input.Ubicacion ?? inventario.Ubicacion;

            await context.SaveChangesAsync();
            return inventario;
        }

        // Eliminar un inventario
        public async Task<bool> EliminarInventario(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var inventario = await context.Inventarios.FindAsync(id);
            if (inventario == null) return false;

            context.Inventarios.Remove(inventario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
