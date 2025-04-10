using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Inventario
{
    public int IdInventario { get; set; }

    public int? CodProducto { get; set; }

    public int? IdAlmacen { get; set; }

    public int? Cantidad { get; set; }

    public string? Ubicacion { get; set; }

    public virtual Producto? CodProductoNavigation { get; set; }

    public virtual Almacen? IdAlmacenNavigation { get; set; }
}
