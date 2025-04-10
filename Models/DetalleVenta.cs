using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public int? IdVenta { get; set; }

    public int? CodProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Descuento { get; set; }

    public virtual Producto? CodProductoNavigation { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }
}
