using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Producto
{
    public int? CodProducto { get; set; }

    public string? Nombre { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? IdCategoria { get; set; }

    [GraphQLIgnore] // 👈 Esto oculta el campo original del schema
    public byte[]? Imagen { get; set; }

    [GraphQLName("imagen")]
    public string? ImagenBase64 => Imagen != null ? Convert.ToBase64String(Imagen) : null;

    public virtual ICollection<DetalleCompra?> DetalleCompras { get; set; } = new List<DetalleCompra?>();

    public virtual ICollection<DetalleVenta?> DetalleVenta { get; set; } = new List<DetalleVenta?>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual ICollection<Inventario?> Inventarios { get; set; } = new List<Inventario?>();

    public virtual ICollection<MovimientosAlmacen?> MovimientosAlmacens { get; set; } = new List<MovimientosAlmacen?>();
}
