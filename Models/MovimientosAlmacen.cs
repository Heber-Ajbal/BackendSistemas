using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class MovimientosAlmacen
{
    public int IdMovimiento { get; set; }

    public int? CodProducto { get; set; }

    public int? Cantidad { get; set; }

    public DateTime? FechaMovimiento { get; set; }

    public string? TipoMovimiento { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual Producto? CodProductoNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
