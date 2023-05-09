using CSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.Negocios
{
    public class Logica_Venta
    {
        public decimal Total(Venta venta)
        {
            Venta Venta = new Venta();

            Venta.TotalVenta = venta.Cantidad * venta.Precio;

            return venta.TotalVenta;
        }
    }
}
