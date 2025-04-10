using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int? CodProveedor { get; set; }

    public int? IdEmpleado { get; set; }

    public decimal? Monto { get; set; }

    public DateOnly? Fecha { get; set; }

    public string? TipoPago { get; set; }

    public virtual Proveedore? CodProveedorNavigation { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
