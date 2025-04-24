using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Proveedore
{
    public int? CodProveedor { get; set; }

    public string? Nombre { get; set; }

    public string? Ubicacion { get; set; }

    public string? Telefono { get; set; }

    [GraphQLIgnore]

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
