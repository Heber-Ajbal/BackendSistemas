using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class MovimientoAlmacenMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public MovimientoAlmacenMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        // Crear un nuevo movimiento de almacén
        public async Task<MovimientosAlmacen> CrearMovimiento(MovimientosAlmacen input)
        {
            var context = _contextFactory.CreateDbContext();
            context.MovimientosAlmacens.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        // Actualizar un movimiento existente
        public async Task<MovimientosAlmacen?> ActualizarMovimiento(int id, MovimientosAlmacen input)
        {
            var context = _contextFactory.CreateDbContext();
            var movimiento = await context.MovimientosAlmacens.FindAsync(id);
            if (movimiento == null) return null;

            movimiento.CodProducto = input.CodProducto ?? movimiento.CodProducto;
            movimiento.Cantidad = input.Cantidad ?? movimiento.Cantidad;
            movimiento.FechaMovimiento = input.FechaMovimiento ?? movimiento.FechaMovimiento;
            movimiento.TipoMovimiento = input.TipoMovimiento ?? movimiento.TipoMovimiento;
            movimiento.IdEmpleado = input.IdEmpleado ?? movimiento.IdEmpleado;

            await context.SaveChangesAsync();
            return movimiento;
        }

        // Eliminar un movimiento
        public async Task<bool> EliminarMovimiento(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var movimiento = await context.MovimientosAlmacens.FindAsync(id);
            if (movimiento == null) return false;

            context.MovimientosAlmacens.Remove(movimiento);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
