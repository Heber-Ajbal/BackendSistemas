﻿using System;
using System.Collections.Generic;

namespace Supermercado.Models;

public partial class Categoria
{
    public int? IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto?> Productos { get; set; } = new List<Producto?>();
}
