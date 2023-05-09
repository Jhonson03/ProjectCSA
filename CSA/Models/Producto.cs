using System;
using System.Collections.Generic;

namespace CSA.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; } = null!;

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public int IdProveedor { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
