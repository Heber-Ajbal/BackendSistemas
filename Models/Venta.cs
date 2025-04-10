using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEmpleado { get; set; }

    public DateOnly? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public decimal? Monto { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
