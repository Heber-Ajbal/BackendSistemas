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
        public async Task<Producto> CrearProducto(ProductoCInput input)
        {
            var context = _contextFactory.CreateDbContext();

            byte[]? imagenBytes = null;

            if (!string.IsNullOrEmpty(input.Imagen))
            {
                imagenBytes = Convert.FromBase64String(input.Imagen);
            }

            var producto = new Producto
            {
                Nombre = input.Nombre,
                PrecioCompra = input.PrecioCompra,
                PrecioVenta = input.PrecioVenta,
                IdCategoria = input.IdCategoria,
                Imagen = imagenBytes
            };

            context.Productos.Add(producto);
            await context.SaveChangesAsync();
            return producto;
        }


        // Actualizar un producto existente
        public async Task<Producto?> ActualizarProducto(ProductoCInput input)
        {
            var context = _contextFactory.CreateDbContext();
            var producto = await context.Productos.FindAsync(input.IdProducto);
            if (producto == null) return null;

            byte[]? imagenBytes = null;

            if (!string.IsNullOrEmpty(input.Imagen))
            {
                imagenBytes = Convert.FromBase64String(input.Imagen);
            }

            producto.Nombre = input.Nombre ?? producto.Nombre;
            producto.PrecioCompra = input.PrecioCompra ;
            producto.PrecioVenta = input.PrecioVenta;
            producto.IdCategoria = input.IdCategoria;
            producto.Imagen = imagenBytes;

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
