using System;
using System.Collections.Generic;

namespace CSA.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal TotalVenta { get; set; }

    public int IdProducto { get; set; }

    public int IdCliente { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
