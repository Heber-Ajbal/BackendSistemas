using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Query
{
    public class Query
    {
        private readonly AppDbContext _context;

        public Query(IDbContextFactory<AppDbContext> contextFactory)
        {
           
            _context = contextFactory.CreateDbContext();
        }

        public IQueryable<Cliente> GetClientes() => _context.Clientes;
        public IQueryable<Empleado> GetEmpleados() => _context.Empleados;
        public IQueryable<Usuario> GetUsuarios() => _context.Usuarios;
        public IQueryable<Almacen> GetAlmacenes() => _context.Almacens;
        public IQueryable<Categoria> GetCategorias() => _context.Categoria;
        public IQueryable<Producto> GetProductos() => _context.Productos;
        public IQueryable<Inventario> GetInventarios() => _context.Inventarios;
        public IQueryable<Proveedore> GetProveedores() => _context.Proveedores;
        public IQueryable<Compra> GetCompras() => _context.Compras;
        public IQueryable<DetalleCompra> GetDetallesCompra() => _context.DetalleCompras;
        public IQueryable<Venta> GetVentas() => _context.Venta;
        public IQueryable<DetalleVenta> GetDetallesVenta() => _context.DetalleVenta;
        public IQueryable<MovimientosAlmacen> GetMovimientosAlmacen() => _context.MovimientosAlmacens;
    }
}
