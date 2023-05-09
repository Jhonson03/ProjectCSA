using CSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.DAO
{
    public class CrudVenta
    {
        CsaContext db = new CsaContext();

        public Venta VentaIndivi(int Id)
        {
            var Buscar = db.Ventas.FirstOrDefault(x => x.IdVenta == Id);
            return Buscar;
        }

        public void AddVenta(Venta Ventas)
        {
            Venta Venta = new Venta();

            Venta.FechaVenta = Ventas.FechaVenta;
            Venta.Cantidad = Ventas.Cantidad;
            Venta.Precio = Ventas.Precio;
            Venta.TotalVenta = Venta.Cantidad * Venta.Precio;
            Venta.IdProducto = Convert.ToInt32(Ventas.IdProducto);
            Venta.IdCliente = Convert.ToInt32(Ventas.IdCliente);

            db.Ventas.Add(Venta);
            db.SaveChanges();
        }

        public void UpdateVenta(Venta Venta, int Lector)
        {
            var Buscar = VentaIndivi(Venta.IdVenta);

            if (Buscar == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                if (Lector == 1)
                {
                    Buscar.FechaVenta = Venta.FechaVenta;
                }
                else if (Lector == 2)
                {
                    Buscar.Cantidad = Venta.Cantidad;
                }
                else if (Lector == 3)
                {
                    Buscar.Precio = Venta.Precio;
                }
                else if (Lector == 4)
                {
                    Buscar.TotalVenta = Buscar.Cantidad * Buscar.Precio;
                }
                else if (Lector == 5)
                {
                    Buscar.IdProducto = Convert.ToInt32(Buscar.IdProducto);
                }
                else if (Lector == 6)
                {
                    Buscar.IdCliente = Convert.ToInt32(Buscar.IdCliente);
                }
                db.Ventas.Add(Venta);
                db.SaveChanges();
            }
        }

        public string DeleteVenta(int Id)
        {
            var Buscar = VentaIndivi(Id);

            if (Buscar == null)
            {
                return "La venta no existe";
            }
            else
            {
                db.Ventas.Remove(Buscar);
                db.SaveChanges();
                return "La venta se removio correctamente";
            }
        }

        public List<Venta> ListarVenta()
        {
            return db.Ventas.ToList();
        }
    }
}
