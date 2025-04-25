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

        public async Task<Compra> CrearCompra(CompraCInput input)
        {
            var context = _contextFactory.CreateDbContext();

            var compra = new Compra
            {
                CodProveedor = input.CodProveedor,
                IdEmpleado = input.IdEmpleado,
                Monto = input.Monto,
                Fecha = input.Fecha,
                TipoPago = input.TipoPago,
                DetalleCompras = input.DetalleCompras.Select(d => new DetalleCompra
                {
                    CodProducto = d.CodProducto,
                    Cantidad = d.Cantidad,
                    PrecioProducto = d.PrecioProducto
                }).ToList()
            };

            context.Compras.Add(compra);
            await context.SaveChangesAsync();
            return compra;
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
