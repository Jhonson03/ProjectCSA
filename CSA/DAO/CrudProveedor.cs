using CSA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.DAO
{
    public class CrudProveedor
    {
        CsaContext db = new CsaContext();

        public Proveedor ProveedorIndivi(int Id)
        {
            var Buscar = db.Proveedors.FirstOrDefault(x => x.IdProveedor == Id);
            return Buscar;
        }

        public void AddProveedor(Proveedor Proveedores)
        {
            Proveedor Proveedor = new Proveedor();

            Proveedor.Nombre = Proveedores.Nombre;
            Proveedor.Direccion = Proveedores.Direccion;
            Proveedor.Telefono = Proveedores.Telefono;

            db.Proveedors.Add(Proveedor);
            db.SaveChanges();
        }

        public void UpdateProveedor(Proveedor Proveedor, int Lector)
        {
            var Buscar = ProveedorIndivi(Proveedor.IdProveedor);

            if (Buscar == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                if (Lector == 1)
                {
                    Buscar.Nombre = Proveedor.Nombre;
                }
                else if (Lector == 2)
                {
                    Buscar.Direccion = Proveedor.Direccion;
                }
                else if (Lector == 3)
                {
                    Buscar.Telefono = Proveedor.Telefono;
                }
                db.Update(Buscar);
                db.SaveChanges();
            }
        }

        public string DeleteProveedor(int Id)
        {
            var Buscar = db.Proveedors.Include(x => x.Productos).SingleOrDefault(x => x.IdProveedor == Id);

            if (Buscar == null)
            {
                return "El proveedor no existe";
            }
            else
            {
                foreach (var producto in Buscar.Productos)
                {
                    db.Productos.Remove(producto);
                }

                db.Proveedors.Remove(Buscar);
                db.SaveChanges();
                return "El proveedor se removio correctamente";
            }
        }

        public List<Proveedor> ListarProveedor()
        {
            return db.Proveedors.ToList();
        }
    }
}
