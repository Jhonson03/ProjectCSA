using CSA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.DAO
{
    public class CrudProducto
    {
        CsaContext db = new CsaContext();

        public Producto ProductoIndivi(int Id)
        {
            var Buscar = db.Productos.FirstOrDefault(x => x.IdProducto == Id);
            return Buscar;
        }

        public void AddProducto(Producto Productos)
        {
            Producto Producto = new Producto();

            Producto.Nombre = Productos.Nombre;
            Producto.Precio = Productos.Precio;
            Producto.Stock = Productos.Stock;
            Producto.IdProveedor = Convert.ToInt32(Productos.IdProveedor);

            db.Productos.Add(Producto);
            db.SaveChanges();
        }

        public void UpdateProducto(Producto Producto, int Lector)
        {
            var Buscar = ProductoIndivi(Producto.IdProducto);

            if (Buscar == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                if (Lector == 1)
                {
                    Buscar.Nombre = Producto.Nombre;
                    Buscar.IdProveedor = Convert.ToInt32(Producto.IdProveedor);
                }
                else if (Lector == 2)
                {
                    Buscar.Precio = Producto.Precio;
                }
                else if (Lector == 3)
                {
                    Buscar.Stock = Producto.Stock;
                }
                db.Productos.Update(Producto);
                db.SaveChanges();
            }
        }

        public string DeleteProducto(int Id)
        {
            var Buscar = db.Productos.Include(x => x.Compras).SingleOrDefault(x => x.IdProducto == Id); ;

            if (Buscar == null)
            {
                return "La compra no existe";
            }
            else
            {
                db.Productos.Remove(Buscar);
                db.SaveChanges();
                return "El producto se removio correctamente";
            }
        }

        public List<Producto> ListarProducto()
        {
            return db.Productos.ToList();
        }
    }
}
