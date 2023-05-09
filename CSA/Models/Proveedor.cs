using System;
using System.Collections.Generic;

namespace CSA.Models;

public partial class Proveedor
{
    public int IdProveedor { get; set; }

    public string? Nombre { get; set; } = null!;

    public string? Direccion { get; set; } = null!;

    public string? Telefono { get; set; } = null!;

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
