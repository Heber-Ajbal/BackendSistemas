using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class ProductoMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ProductoMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Crear un nuevo producto
        public async Task<Producto> CrearProducto(Producto input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Productos.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        // Actualizar un producto existente
        public async Task<Producto?> ActualizarProducto(int id, Producto input)
        {
            var context = _contextFactory.CreateDbContext();
            var producto = await context.Productos.FindAsync(id);
            if (producto == null) return null;

            producto.Nombre = input.Nombre ?? producto.Nombre;
            producto.PrecioCompra = input.PrecioCompra ?? producto.PrecioCompra;
            producto.PrecioVenta = input.PrecioVenta ?? producto.PrecioVenta;
            producto.IdCategoria = input.IdCategoria ?? producto.IdCategoria;

            await context.SaveChangesAsync();
            return producto;
        }

        // Eliminar un producto
        public async Task<bool> EliminarProducto(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var producto = await context.Productos.FindAsync(id);
            if (producto == null) return false;

            context.Productos.Remove(producto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
