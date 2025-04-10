using Microsoft.EntityFrameworkCore;
using Supermercado.Models;

namespace Supermercado.Mutations
{
    public class Mutation
    {
        public ClienteMutation Cliente { get; }
        public EmpleadoMutation Empleado { get; }
        public UsuarioMutation Usuario { get; }
        public AlmacenMutation Almacen { get; }
        public CategoriaMutation Categoria { get; }
        public ProductoMutation Producto { get; }
        public InventarioMutation Inventario { get; }
        public ProveedorMutation Proveedor { get; }
        public CompraMutation Compra { get; }
        public DetalleCompraMutation DetalleCompra { get; }
        public VentaMutation Venta { get; }
        public DetalleVentaMutation DetalleVenta { get; }
        public MovimientoAlmacenMutation MovimientoAlmacen { get; }

        public Mutation(IDbContextFactory<AppDbContext> contextFactory)
        {
            Cliente = new ClienteMutation(contextFactory);
            Empleado = new EmpleadoMutation(contextFactory);
            Usuario = new UsuarioMutation(contextFactory);
            Almacen = new AlmacenMutation(contextFactorycontextF);
            Categoria = new CategoriaMutation(contextFactory);
            Producto = new ProductoMutation(contextFactory);
            Inventario = new InventarioMutation(contextFactory);
            Proveedor = new ProveedorMutation(contextFactory);
            Compra = new CompraMutation(contextFactory);
            DetalleCompra = new DetalleCompraMutation(contextFactory);
            Venta = new VentaMutation(contextFactory);
            DetalleVenta = new DetalleVentaMutation(contextFactory);
            MovimientoAlmacen = new MovimientoAlmacenMutation(contextFactory);
        }
    }
}
