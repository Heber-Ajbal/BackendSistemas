using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Query
{
    public class Query
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public Query(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Clientes.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Empleados.ToListAsync();
        }

        public async Task<List<Usuario>> GetUsuarios()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Usuarios.ToListAsync();
        }

        public async Task<List<Almacen>> GetAlmacenes()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Almacens.ToListAsync();
        }

        public async Task<List<Categoria>> GetCategorias()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Categoria.ToListAsync();
        }

        public async Task<List<Producto>> GetProductos()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Productos.Include(c => c.IdCategoriaNavigation).ToListAsync();
        }

        public async Task<List<Inventario>> GetInventarios()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Inventarios.ToListAsync();
        }

        public async Task<List<Proveedore>> GetProveedores()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Proveedores.ToListAsync();
        }

        public async Task<List<Compra>> GetCompras()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Compras
                .Include(c => c.CodProveedorNavigation)
                .Include(c => c.IdEmpleadoNavigation)
                .Include(c => c.DetalleCompras)
                    .ThenInclude(d => d.CodProductoNavigation)
                .ToListAsync();
        }

        public async Task<List<DetalleCompra>> GetDetallesCompra()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.DetalleCompras.ToListAsync();
        }

        public async Task<List<Venta>> GetVentas()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Venta
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdEmpleadoNavigation)
                .Include(v => v.DetalleVenta)
                    .ThenInclude(d => d.CodProductoNavigation)
                .ToListAsync();
        }

        public async Task<List<DetalleVenta>> GetDetallesVenta()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.DetalleVenta.ToListAsync();
        }

        public async Task<List<MovimientosAlmacen>> GetMovimientosAlmacen()
        {
            var context = _contextFactory.CreateDbContext();
            return await context.MovimientosAlmacens.ToListAsync();
        }
    }
}
