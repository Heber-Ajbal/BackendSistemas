using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class VentaMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public VentaMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Crear una nueva venta
        public async Task<Venta> CrearVenta(Venta input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Ventas.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        // Actualizar una venta existente
        public async Task<Venta?> ActualizarVenta(int id, Venta input)
        {
            var context = _contextFactory.CreateDbContext();
            var venta = await context.Ventas.FindAsync(id);
            if (venta == null) return null;

            venta.IdCliente = input.IdCliente ?? venta.IdCliente;
            venta.IdEmpleado = input.IdEmpleado ?? venta.IdEmpleado;
            venta.Fecha = input.Fecha ?? venta.Fecha;
            venta.Hora = input.Hora ?? venta.Hora;
            venta.Monto = input.Monto ?? venta.Monto;

            await context.SaveChangesAsync();
            return venta;
        }

        // Eliminar una venta
        public async Task<bool> EliminarVenta(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var venta = await context.Ventas.FindAsync(id);
            if (venta == null) return false;

            context.Ventas.Remove(venta);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
