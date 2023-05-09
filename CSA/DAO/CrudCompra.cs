using CSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.DAO
{
    public class CrudCompra
    {
        CsaContext db = new CsaContext();

        public Compra CompraIndivi(int Id)
        {
            var Buscar = db.Compras.FirstOrDefault(x => x.IdCompra == Id);

            return Buscar;
        }

        public void AddCompra(Compra Compras)
        {
            Compra Compra = new Compra();

            Compra.FechaCompra = Compras.FechaCompra;
            Compra.Cantidad = Compras.Cantidad;
            Compra.Precio = Compras.Precio;
            Compra.TotalCompra = Compra.Cantidad * Compra.Precio;
            Compra.IdProducto = Convert.ToInt32(Compras.IdProducto);
            Compra.IdProveedor = Convert.ToInt32(Compras.IdProveedor);

            db.Compras.Add(Compra);
            db.SaveChanges();
        }

        public void UpdateCompra(Compra compra, int Lector)
        {
            var Buscar = CompraIndivi(compra.IdCompra);

            if (Buscar == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                if (Lector == 1)
                {
                    Buscar.FechaCompra = compra.FechaCompra;
                }
                else if (Lector == 2)
                {
                    Buscar.Cantidad = compra.Cantidad;
                    Buscar.TotalCompra = Buscar.Cantidad * Buscar.Precio;
                }
                else if (Lector == 3)
                {
                    Buscar.Precio = compra.Precio;
                    Buscar.TotalCompra = Buscar.Precio * Buscar.Cantidad;
                }

                else if (Lector == 4)
                {
                    Buscar.IdProducto = Convert.ToInt32(Buscar.IdProducto);
                    Buscar.IdProveedor = Convert.ToInt32(Buscar.IdProveedor);
                }
                db.Compras.Update(compra);
                db.SaveChanges();
            }
        }

        public string DeleteCompra(int Id)
        {
            var Buscar = CompraIndivi(Id);

            if (Buscar == null)
            {
                return "La compra no existe";
            }
            else
            {
                db.Compras.Remove(Buscar);
                db.SaveChanges();
                return "La compra se removio correctamente";
            }
        }

        public List<Compra> ListarCompra()
        {
            return db.Compras.ToList();
        }
    }
}
