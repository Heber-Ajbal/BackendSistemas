using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class DetalleVentaMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public DetalleVentaMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<DetalleVenta> CrearDetalleVenta(DetalleVenta input)
        {
            var context = _contextFactory.CreateDbContext();
            context.DetalleVenta.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        public async Task<DetalleVenta?> ActualizarDetalleVenta(int id, DetalleVenta input)
        {
            var context = _contextFactory.CreateDbContext();
            var detalle = await context.DetalleVenta.FindAsync(id);
            if (detalle == null) return null;

            detalle.IdVenta = input.IdVenta;
            detalle.CodProducto = input.CodProducto;
            detalle.Cantidad = input.Cantidad;
            detalle.Descuento = input.Descuento;

            await context.SaveChangesAsync();
            return detalle;
        }

        public async Task<bool> EliminarDetalleVenta(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var detalle = await context.DetalleVenta.FindAsync(id);
            if (detalle == null) return false;

            context.DetalleVenta.Remove(detalle);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
