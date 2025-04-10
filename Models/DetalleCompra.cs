using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class DetalleCompra
{
    public int IdDetalleCompra { get; set; }

    public int? IdCompra { get; set; }

    public int? CodProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioProducto { get; set; }

    public virtual Producto? CodProductoNavigation { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }
}
