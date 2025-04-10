using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Almacen
{
    public int IdAlmacen { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public int? Capacidad { get; set; }

    public virtual ICollection<Inventario> Inventarios { get; set; } = new List<Inventario>();
}
