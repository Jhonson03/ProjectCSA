using CSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.Negocios
{
    public class Logica_Compra
    {
        public decimal Compra(Compra compra)
        {
            Compra Compra = new Compra();

            Compra.TotalCompra = compra.Cantidad * compra.Precio;

            return Convert.ToDecimal(compra.TotalCompra);
        }
    }
}
