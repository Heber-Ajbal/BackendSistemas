using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public decimal? Sueldo { get; set; }

    public string? Turno { get; set; }

    public string? Cargo { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<MovimientosAlmacen> MovimientosAlmacens { get; set; } = new List<MovimientosAlmacen>();

    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
