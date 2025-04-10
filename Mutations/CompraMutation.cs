using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class CompraMutation
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public CompraMutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Compra> CrearCompra(Compra input)
        {
            var context = _contextFactory.CreateDbContext();
            context.Compras.Add(input);
            await context.SaveChangesAsync();
            return input;
        }

        public async Task<Compra?> ActualizarCompra(int id, Compra input)
        {
            var context = _contextFactory.CreateDbContext();
            var compra = await context.Compras.FindAsync(id);
            if (compra == null) return null;

            compra.CodProveedor = input.CodProveedor;
            compra.IdEmpleado = input.IdEmpleado;
            compra.Monto = input.Monto;
            compra.Fecha = input.Fecha;
            compra.TipoPago = input.TipoPago;

            await context.SaveChangesAsync();
            return compra;
        }

        public async Task<bool> EliminarCompra(int id)
        {
            var context = _contextFactory.CreateDbContext();
            var compra = await context.Compras.FindAsync(id);
            if (compra == null) return false;

            context.Compras.Remove(compra);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
