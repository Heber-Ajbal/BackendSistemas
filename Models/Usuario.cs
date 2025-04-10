using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdEmpleado { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ContrasenaHash { get; set; } = null!;

    public bool? Activo { get; set; }

    public string? Rol { get; set; }

    public virtual Empleado? IdEmpleadoNavigation { get; set; }
}
