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

        public async Task<DetalleCompra> CrearDetalleCompra(DetalleCompra input)
        {
            var context = _contextFactory.CreateDbContext();
            context.DetalleCompras.Add(input); 
            return input;
        }

        public async Task<DetalleCompra?> ActualizarDetalleCompra(int id, DetalleCompra input)
        {
            var context = _contextFactory.CreateDbContext();
            var detalle = await context.DetalleCompras.FindAsync(id);
            if (detalle == null) return null;

            detalle.IdCompra = input.IdCompra;
            detalle.CodProducto = input.CodProducto;
            detalle.Cantidad = input.Cantidad;
            detalle.PrecioProducto = input.PrecioProducto;

            await context.SaveChangesAsync();
            return detalle;
        }

        public async Task<bool> EliminarDetalleCompra(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var detalle = await context.DetalleCompras.FindAsync(id);
            if (detalle == null) return false;

            context.DetalleCompras.Remove(detalle);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
