using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class ProveedoreMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ProveedoreMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Crear un nuevo proveedor
        public async Task<Proveedore> CrearProveedor(Proveedore input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Proveedores.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        // Actualizar un proveedor existente
        public async Task<Proveedore?> ActualizarProveedor(int id, Proveedore input)
        {
            var context = _contextFactory.CreateDbContext();
            var proveedor = await context.Proveedores.FindAsync(id);
            if (proveedor == null) return null;

            proveedor.Nombre = input.Nombre ?? proveedor.Nombre;
            proveedor.Ubicacion = input.Ubicacion ?? proveedor.Ubicacion;
            proveedor.Telefono = input.Telefono ?? proveedor.Telefono;

            await context.SaveChangesAsync();
            return proveedor;
        }

        // Eliminar un proveedor
        public async Task<bool> EliminarProveedor(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var proveedor = await context.Proveedores.FindAsync(id);
            if (proveedor == null) return false;

            context.Proveedores.Remove(proveedor);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
