using CSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSA.DAO
{
    public class CrudClientes
    {
        CsaContext db = new CsaContext();

        public Cliente ClienteIndivi(int Id)
        {
            var Buscar = db.Clientes.FirstOrDefault(x => x.IdCliente == Id);
            return Buscar;
        }

        public void AddCliente(Cliente Clientes)
        {
            Cliente Cliente = new Cliente();

            Cliente.Nombre = Clientes.Nombre;
            Cliente.Apellido = Clientes.Apellido;
            Cliente.Direccion = Clientes.Direccion;
            Cliente.Telefono = Clientes.Telefono;

            db.Clientes.Add(Cliente);
            db.SaveChanges();
        }

        public void UpdateCliente(Cliente Cliente, int Lector)
        {
            var Buscar = ClienteIndivi(Cliente.IdCliente);

            if (Buscar == null)
            {
                Console.WriteLine("El id no existe");
            }
            else
            {
                if (Lector == 1)
                {
                    Buscar.Nombre = Cliente.Nombre;
                }
                else if (Lector == 2)
                {
                    Buscar.Apellido = Cliente.Apellido;
                }
                else if (Lector == 3)
                {
                    Buscar.Direccion = Cliente.Direccion;
                }
                else if (Lector == 4)
                {
                    Buscar.Telefono = Cliente.Telefono;
                }
                db.Clientes.Add(Cliente);
                db.SaveChanges();
            }
        }

        public string DeleteCliente(int Id)
        {
            var Buscar = ClienteIndivi(Id);

            if (Buscar == null)
            {
                return "El usurio no existe";
            }
            else
            {
                db.Clientes.Remove(Buscar);
                db.SaveChanges();
                return "El usuario se remocio correctamente";
            }
        }

        public List<Cliente> ListarCliente()
        {
            return db.Clientes.ToList();
        }
    }
}
