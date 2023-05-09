using CSA.DAO;
using CSA.Models;
using CSA.Negocios;
using Microsoft.Data.SqlClient;
using System.ComponentModel.Design;

#region Objetos
Logica_Venta ClsVentas = new Logica_Venta();
Logica_Compra ClsCompras = new Logica_Compra();
ClsAdmin clsUser = new ClsAdmin();

CrudClientes CrudClientes = new CrudClientes();
CrudCompra CrudCompra = new CrudCompra();
CrudProducto CrudProducto = new CrudProducto();
CrudProveedor CrudProveedor = new CrudProveedor();
CrudVenta CrudVenta = new CrudVenta();

Cliente Cliente = new Cliente();
Compra Compra = new Compra();
Producto Producto = new Producto();
Proveedor Proveedor = new Proveedor();
Venta Venta = new Venta();
User user = new User();
#endregion

bool Verificacion1 = true;

while (Verificacion1 == true)
{
    Console.WriteLine("Rol en la aplicacion");

    Console.Write(@"
Porfavor ingrese:
1. Si usted es un  administrador
2. Si usted es un Cliente
3. Salir

-> ");

    var Menu1 = Convert.ToInt32(Console.ReadLine());

    switch (Menu1)
    {
        case 1:
            bool Verificacion2 = true;

            while (Verificacion2 == true)
            {
                Console.WriteLine("\nVerificacion de administrador");
                Console.Write("\nIngresa su usuario -> ");
                user.user = Console.ReadLine();
                Console.Write("\nIngresa su contraseña -> ");
                user.password = Console.ReadLine();

                bool Resultado = clsUser.Autenticacion(user);
                if (Resultado == true)
                {
                    Console.WriteLine("\nBienvenido al administrador de la app");

                    bool Verificacion3 = true;

                    while (Verificacion3 == true)
                    {


                        Console.Write(@"

Porfavor ingrese:
1- Ver, ingresar o actualizar productos almacenados
2- Lista de ventas
3- Hacer una nueva compra
4- Ver, ingresar o actualizar proveedores
5- Lista de clientes
6- Salir

-> ");
                        var Menu2 = Convert.ToInt32(Console.ReadLine());

                        switch (Menu2)
                        {
                            case 1:
                                #region Producto

                                bool verificacion4 = true;

                                while (verificacion4 == true)
                                {
                                    Console.Write("\nSe encuentra en el area de productos");
                                    Console.WriteLine("\nLista de Productos");
                                    var ListProducto = CrudProducto.ListarProducto();
                                    foreach (var i in ListProducto)
                                    {
                                        var proveedor = CrudProveedor.ProveedorIndivi(i.IdProveedor);
                                        Console.WriteLine(@$"
Codigo:{i.IdProducto}
Nombre:{i.Nombre}
Precio:{i.Precio}
Stock:{i.Stock}
Proveedor:{proveedor.Nombre}");
                                    }
                                    Console.Write(@"
Por favor ingrese:
1- Agregar productos
2- Actualizar productos
3- Eliminar productos
4- Salir

-> ");
                                    var menu4 = Convert.ToInt32(Console.ReadLine());

                                    switch (menu4)
                                    {
                                        case 1:
                                            Console.Write("Nombre del producto -> ");
                                            Producto.Nombre = Console.ReadLine();
                                            Console.Write("Precio del producto -> ");
                                            Producto.Precio = Convert.ToDecimal(Console.ReadLine());
                                            Console.Write("Cantidad en el stock del producto -> ");
                                            Producto.Stock = Convert.ToInt32(Console.ReadLine());

                                            var ListProveedor = CrudProveedor.ListarProveedor();
                                            foreach (var i in ListProveedor)
                                            {
                                                Console.WriteLine($@"
Codigo:{i.IdProveedor} 
Nombre:{i.Nombre}");
                                            }

                                            Console.Write("Ingrese el Codigo del proveedor que distribuye el producto -> ");
                                            Producto.IdProveedor = Convert.ToInt32(Console.ReadLine());

                                            CrudProducto.AddProducto(Producto);
                                            break;

                                        case 2:
                                            Console.Write("Ingrese el codigo del producto a actualizar -> ");
                                            var buscarproducto = CrudProducto.ProductoIndivi(Convert.ToInt32((Console.ReadLine())));

                                            if (buscarproducto == null)
                                            {
                                                Console.Write("El producto no existe");
                                            }
                                            else
                                            {
                                                Console.Write(@$"
Ingrese el campo que desea actualizar

1- Nombre: {buscarproducto.Nombre} 
2- Precio: {buscarproducto.Precio}
3- Stock: {buscarproducto.Stock}
4- salir

-> ");
                                                var Lector = Convert.ToInt32(Console.ReadLine());

                                                switch (Lector)
                                                {
                                                    case 1:
                                                        Console.Write("Ingrese el nombre -> ");
                                                        buscarproducto.Nombre = Console.ReadLine();

                                                        var ListProveedores = CrudProveedor.ListarProveedor();
                                                        foreach (var i in ListProveedores)
                                                        {
                                                            Console.WriteLine($@"
Codigo:{i.IdProveedor} 
Nombre:{i.Nombre}");
                                                        }

                                                        Console.Write("Ingrese el Codigo del proveedor que distribuye el producto -> ");
                                                        buscarproducto.IdProveedor = Convert.ToInt32(Console.ReadLine());

                                                        break;

                                                    case 2:
                                                        Console.Write("Ingrese el precio -> ");
                                                        buscarproducto.Precio = Convert.ToDecimal(Console.ReadLine());
                                                        break;

                                                    case 3:
                                                        Console.Write("Cantidad en el stock del producto -> ");
                                                        buscarproducto.Stock = Convert.ToInt32(Console.ReadLine());
                                                        break;
                                                }
                                                CrudProducto.UpdateProducto(buscarproducto, Lector);

                                                Console.Write("Actualizacion completa");
                                            }
                                            break;

                                        case 3:
                                            Console.Write("\nIngrese el codigo del producto a eliminar -> ");

                                            var ProductoIndivi = CrudProducto.ProductoIndivi(Convert.ToInt32(Console.ReadLine()));

                                            if (ProductoIndivi == null)
                                            {
                                                Console.Write("Este producto no existe");
                                            }
                                            else
                                            {
                                                Console.Write("Eliminar Proveedor");

                                                Console.Write(@$"

Nombre: {ProductoIndivi.Nombre} 
Precio: {ProductoIndivi.Precio}
Stock: {ProductoIndivi.Stock}

El producto encontrado es el correcto ingrese 1

-> ");
                                                var Lector = Convert.ToInt32(Console.ReadLine());

                                                if (Lector == 1)
                                                {
                                                    Console.Write("Si esta seguro de eliminar este producto ingrese su codigo -> ");
                                                    var Id = Convert.ToInt32(Console.ReadLine());
                                                    Console.Write(CrudProducto.DeleteProducto(Id));
                                                }

                                            }
                                            break;

                                        case 4:
                                            verificacion4 = false;
                                            break;

                                    }
                                }
                                break;

                            #endregion
                            case 2:
                                #region Ventas
                                bool verificacion7 = true;

                                while (verificacion7 == true)
                                {

                                    Console.Write("\nSe encuentra en el area de ventas");
                                    Console.WriteLine("\nLista de Ventas");
                                    var Listventas = CrudVenta.ListarVenta();
                                    foreach (var i in Listventas)
                                    {
                                        var cliente = CrudClientes.ClienteIndivi(i.IdCliente);
                                        var producto = CrudProducto.ProductoIndivi(i.IdProducto);
                                        Console.Write(@$"
Codigo:{i.IdVenta}
Fecha: {i.FechaVenta}
Nombre Cliente:{cliente.Nombre}
Precio:{i.Precio}
Cantida:{i.Cantidad}
Total: {i.TotalVenta}

");
                                    }
                                    break;
                                }
                                #endregion
                                break;
                            case 3:
                                #region Compra
                                bool verificacion5 = true;

                                while (verificacion5 == true)
                                {

                                    Console.WriteLine("Se encuentra en el area de compras");

                                    Console.WriteLine("\nLista de Productos");
                                    var ListCompra = CrudCompra.ListarCompra();
                                    foreach (var i in ListCompra)
                                    {
                                        var producto = CrudProducto.ProductoIndivi(i.IdProducto);
                                        var proveedor = CrudProveedor.ProveedorIndivi(i.IdProveedor);
                                        Console.WriteLine(@$"
Codigo:{i.IdCompra}
Fecha:{i.FechaCompra}
Producto: {producto.Nombre}
Cantidad:{i.Cantidad}
Precio:{i.Precio}
Total:{i.TotalCompra}
Proveedor:{proveedor.Nombre}");
                                    }
                                    Console.WriteLine(@"

Por favor ingrese:
1- Para hacer una compra a nuestros proveedores
2- Actualizar una compra
3- Eliminar compra
4- Salir

-> ");


                                    var menu5 = Convert.ToInt32(Console.ReadLine());

                                    switch (menu5)
                                    {
                                        case 1:
                                            Console.Write("Fecha de la compra -> ");
                                            Compra.FechaCompra = Convert.ToDateTime(Console.ReadLine());

                                            var ListProducto = CrudProducto.ListarProducto();
                                            foreach (var i in ListProducto)
                                            {
                                                Console.WriteLine(@$"
Codigo:{i.IdProducto}
Nombre:{i.Nombre}
");
                                            }
                                            Console.Write("Ingrese el codigo del producto a comprar -> ");
                                            Compra.IdProducto = Convert.ToInt32(Console.ReadLine());

                                            Console.Write("Cantidad -> ");
                                            Compra.Cantidad = Convert.ToInt32(Console.ReadLine());
                                            Console.Write("Precio -> ");
                                            Compra.Precio = Convert.ToDecimal(Console.ReadLine());
                                            Compra.TotalCompra = ClsCompras.Compra(Compra);
                                            foreach (var i in ListProducto)
                                            {
                                                var proveedor = CrudProveedor.ProveedorIndivi(i.IdProveedor);
                                                Console.WriteLine(@$"
Codigo:{proveedor.IdProveedor}
Proveedor:{proveedor.Nombre}");
                                            }
                                            Console.Write("\nIngrese el codigo del proveedor que distribuye el producto -> ");
                                            Compra.IdProveedor = Convert.ToInt32(Console.ReadLine());
                                            CrudCompra.AddCompra(Compra);
                                            break;
                                        case 2:
                                            Console.Write("\nIngrese el codigo de la compra a actualizar -> ");
                                            var buscarcompra = CrudCompra.CompraIndivi(Convert.ToInt32((Console.ReadLine())));

                                            if (buscarcompra == null)
                                            {
                                                Console.Write("La compra no existe");
                                            }
                                            else
                                            {
                                                var producto = CrudProducto.ProductoIndivi(buscarcompra.IdProducto);
                                                var nombreProducto = producto.Nombre;
                                                Console.Write(@$"
Ingrese el campo que desea actualizar

1- Fecha: {buscarcompra.FechaCompra}
2- Producto: {nombreProducto}
3- Cantidad: {buscarcompra.Cantidad}

-> ");
                                                var Lector = Convert.ToInt32(Console.ReadLine());

                                                switch (Lector)
                                                {
                                                    case 1:
                                                        Console.Write("Ingrese la fecha -> ");
                                                        buscarcompra.FechaCompra = Convert.ToDateTime(Console.ReadLine());
                                                        break;

                                                    case 2:
                                                        var ListProducto2 = CrudProducto.ListarProducto();
                                                        foreach (var i in ListProducto2)
                                                        {
                                                            var producto2 = CrudProducto.ProductoIndivi(i.IdProducto);
                                                            Console.WriteLine(@$"
Codigo:{i.IdProducto}
Nombre:{producto2.Nombre}
");
                                                        }
                                                        Console.Write("Ingrese el codigo del producto a comprar -> ");
                                                        buscarcompra.IdProducto = Convert.ToInt32(Console.ReadLine());

                                                        foreach (var i in ListProducto2)
                                                        {
                                                            var proveedor = CrudProveedor.ProveedorIndivi(i.IdProveedor);
                                                            Console.Write(@$"
Codigo:{proveedor.IdProveedor}
Proveedor:{proveedor.Nombre}");
                                                        }
                                                        Console.Write("Ingrese el codigo del proveedor que distribuye el producto -> ");
                                                        buscarcompra.IdProveedor = Convert.ToInt32(Console.ReadLine());

                                                        break;

                                                    case 3:
                                                        Console.Write("Cantidad en el stock del producto -> ");
                                                        buscarcompra.Cantidad = Convert.ToInt32(Console.ReadLine());
                                                        buscarcompra.TotalCompra = ClsCompras.Compra(buscarcompra);
                                                        break;
                                                }
                                                CrudCompra.UpdateCompra(buscarcompra, Lector);
                                                Console.Write("\nActualizacion completa");
                                            }
                                            break;

                                        case 3:

                                            Console.Write("\nIngrese el codigo de la compra a eliminar -> ");

                                            var comprindivi = CrudCompra.CompraIndivi(Convert.ToInt32(Console.ReadLine()));

                                            if (comprindivi == null)
                                            {
                                                Console.Write("La compra no existe");
                                            }
                                            else
                                            {
                                                Console.Write("Eliminar Compra");
                                                var producto = CrudProducto.ProductoIndivi(comprindivi.IdProducto);
                                                var nombreProducto = producto.Nombre;
                                                Console.Write(@$"


Codigo: {comprindivi.IdCompra}
Fecha: {comprindivi.FechaCompra}
Producto: {nombreProducto}
Cantidad: {comprindivi.Cantidad}

Ingrese 1 si esta es la compra a eliminar -> ");
                                                var Lector = Convert.ToInt32(Console.ReadLine());
                                                if (Lector == 1)
                                                {
                                                    Console.Write("Si esta seguro de eliminar esta compra ingrese su codigo -> ");
                                                    var Id = Convert.ToInt32(Console.ReadLine());
                                                    Console.Write(CrudCompra.DeleteCompra(Id));
                                                }
                                            }
                                            break;

                                        case 4:
                                            verificacion5 = false;
                                            break;
                                    }

                                }
                                #endregion
                                break;
                            case 4:
                                #region Proveedor
                                bool Verificacion4 = true;

                                while (Verificacion4 == true)
                                {
                                    Console.WriteLine("Se encuentra en el area de proveedores");
                                    Console.WriteLine("\nLista de Proveedores");
                                    var ListProveedor = CrudProveedor.ListarProveedor();
                                    foreach (var i in ListProveedor)
                                    {
                                        Console.WriteLine(@$"
Codigo:{i.IdProveedor}
Nombre:{i.Nombre}
Direccion:{i.Direccion}
Telefono:{i.Telefono}");
                                    }

                                    Console.Write(@"
Por favor ingrese:
1- Agregar Proveedor
2- Actualizar Proveedor
3- Eliminar Proveedor 
4- Salir

-> ");

                                    var menu3 = Convert.ToInt32(Console.ReadLine());

                                    switch (menu3)
                                    {
                                        case 1:
                                            Console.Write("Nombre del proveedor -> ");
                                            Proveedor.Nombre = Console.ReadLine();
                                            Console.Write("Direccion del proveedor -> ");
                                            Proveedor.Direccion = Console.ReadLine();
                                            Console.Write("Telefono del proveedor -> ");
                                            Proveedor.Telefono = Console.ReadLine();
                                            CrudProveedor.AddProveedor(Proveedor);
                                            break;

                                        case 2:
                                            Console.Write("Ingrese el codigo del proveedor a actualizar -> ");
                                            var buscarproveedor = CrudProveedor.ProveedorIndivi(Convert.ToInt32((Console.ReadLine())));

                                            if (buscarproveedor == null)
                                            {
                                                Console.Write("El proveedor no existe");
                                            }
                                            else
                                            {


                                                Console.Write(@$"
Ingrese el campo que desea actualizar

1- Nombre: {buscarproveedor.Nombre} 
2- Direccion: {buscarproveedor.Direccion}
3- Telefono: {buscarproveedor.Telefono}
4- salir

-> ");
                                                var Lector = Convert.ToInt32(Console.ReadLine());

                                                switch (Lector)
                                                {
                                                    case 1:
                                                        Console.Write("Ingrese el nombre -> ");
                                                        buscarproveedor.Nombre = Console.ReadLine();
                                                        break;

                                                    case 2:
                                                        Console.Write("Ingrese la direccion -> ");
                                                        buscarproveedor.Direccion = Console.ReadLine();
                                                        break;

                                                    case 3:
                                                        Console.Write("Ingrese el telefono -> ");
                                                        buscarproveedor.Telefono = Console.ReadLine();
                                                        break;
                                                }
                                                CrudProveedor.UpdateProveedor(buscarproveedor, Lector);

                                                Console.Write("Actualizacion completa");
                                            }
                                            break;

                                        case 3:
                                            Console.Write("\nIngrese el codigo del proveedor a eliminar -> ");

                                            var ProveedorIndivi = CrudProveedor.ProveedorIndivi(Convert.ToInt32(Console.ReadLine()));

                                            if (ProveedorIndivi == null)
                                            {
                                                Console.Write("Este proveedor no existe");
                                            }
                                            else
                                            {
                                                Console.Write("Eliminar Proveedor");

                                                Console.Write(@$"

Nombre: {ProveedorIndivi.Nombre} 
Direccion: {ProveedorIndivi.Direccion}
Telefono: {ProveedorIndivi.Telefono}

El proveedor encontrado es el correcto ingrese 1

-> ");
                                                var Lector = Convert.ToInt32(Console.ReadLine());

                                                if (Lector == 1)
                                                {
                                                    Console.Write("Si esta seguro de eliminar este proveedor ingrese su codigo -> ");
                                                    var Id = Convert.ToInt32(Console.ReadLine());
                                                    Console.Write(CrudProveedor.DeleteProveedor(Id));
                                                }
                                            }
                                            break;
                                        case 4:

                                            Verificacion4 = false;
                                            break;
                                    }

                                }
                                break;
                            #endregion
                            case 5:
                                #region Cliente
                                Console.WriteLine("Lista de Cliente");

                                var ListCliente = CrudClientes.ListarCliente();
                                foreach (var i in ListCliente)
                                {
                                    Console.WriteLine(@$"
Codigo:{i.IdCliente}
Nombre:{i.Nombre}
Apellido: {i.Apellido}
Direccion:{i.Direccion}
Telefono:{i.Telefono}

");
                                }
                                #endregion
                                break;

                            case 6:
                                Verificacion3 = false;
                                Verificacion2 = false;
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("\nContraseña incorrecta");
                    Verificacion2 = true;
                }
            }
            break;

        case 2:

            bool verificacion6 = true;

            while (verificacion6 == true)
            {
                Console.WriteLine("\nBienvenido a Tienda Merlin");

                Console.Write(@"
Ya tienes una cuenta con nosotros:

1- Iniciar Sesion
2- Crear Cuenta
3- Cerrar

-> ");

                var menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        #region Verificacion de usuario
                        Console.Write("Verificacion de usuario");

                        var ListCliente = CrudClientes.ListarCliente();
                        foreach (var i in ListCliente)
                        {
                            Console.WriteLine(@$"
Codigo:{i.IdCliente}
Nombre:{i.Nombre}
");
                        }

                        Console.WriteLine("Ingrese el codigo -> ");

                        var buscarcliente = CrudClientes.ClienteIndivi(Convert.ToInt32((Console.ReadLine())));

                        if (buscarcliente == null)
                        {
                            Console.WriteLine("No existe");
                        }
                        else
                        {
                            Venta.IdCliente = buscarcliente.IdCliente;
                            Console.WriteLine("Area de Ventas");

                            Console.WriteLine("\nLista de Productos");
                            var ListProducto = CrudProducto.ListarProducto();
                            foreach (var i in ListProducto)
                            {
                                var proveedor = CrudProveedor.ProveedorIndivi(i.IdProveedor);
                                Console.WriteLine(@$"
Codigo:{i.IdProducto}
Nombre:{i.Nombre}
Precio:{i.Precio}
Stock:{i.Stock}
Proveedor:{proveedor.Nombre}
");
                            }

                            Console.Write("Ingrese el codigo del producto a comprar -> ");

                            Venta.IdProducto = Convert.ToInt32(Console.ReadLine());
                            var producto = CrudProducto.ProductoIndivi(Venta.IdProducto);
                            Venta.FechaVenta = DateTime.Today;
                            Console.WriteLine("Cantidad del producto que lleva -> ");
                            Venta.Cantidad = Convert.ToInt32(Console.ReadLine());
                            Venta.Precio = Convert.ToDecimal(producto.Precio);
                            Venta.TotalVenta = ClsVentas.Total(Venta);

                            CrudVenta.AddVenta(Venta);
                        }
                        #endregion
                        break;

                    case 2:
                        #region Crear Cuenta
                        Console.WriteLine("\nCrear Cuenta");

                        Console.Write("Ingrese su Nombre -> ");
                        Cliente.Nombre = Console.ReadLine();
                        Console.Write("\nIngrese su Apellido -> ");
                        Cliente.Apellido = Console.ReadLine();
                        Console.Write("\nIngrese su Direccion -> ");
                        Cliente.Direccion = Console.ReadLine();
                        Console.Write("\nIngrese su Telefono -> ");
                        Cliente.Telefono = Console.ReadLine();

                        CrudClientes.AddCliente(Cliente);
                        #endregion
                        break;

                    case 3:
                        verificacion6 = false;
                        break;
                }
            }
            break;

        case 3:
            Verificacion1 = false;
            break;
    }
}