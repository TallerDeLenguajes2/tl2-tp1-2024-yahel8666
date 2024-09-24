using cadeteria;

string carpeta = @"Archivos\" ;
string rutaCadetes = carpeta + "datosCadetes.csv";
string rutaCadeteria = carpeta + "datosCadeteria.csv";

var manejoArchivos = new ManejoArchivos();

if (!manejoArchivos.Existe(rutaCadeteria) && !manejoArchivos.Existe(rutaCadetes))
{
    Console.WriteLine("No se encontraron los datos"); 
    return;
} else
{
    var menu = new Menu();
    var pedido = new Pedido();

    List<Cadete> listaCadetes = manejoArchivos.obtenerCadetes(rutaCadetes);
    var cadeteria = manejoArchivos.CargarCadeteria(rutaCadeteria, listaCadetes);
    List<Pedido> listaPedidosPendientes = new List<Pedido>();

    cadeteria.presentacionCadeteria();
    int opcion;
    int nroPedido = 1;
    do
    {
        menu.mostrarMenu();
        opcion = menu.LeerYValidarOpcion(6);
        int opcionIterar;
        switch (opcion)
        {
            case 1:
                do
                {
                    Pedido nuevoPedido = pedido.NuevoPedido(nroPedido);
                    listaPedidosPendientes.Add(nuevoPedido);
                    nroPedido++;
                    Console.WriteLine("¿Quiere cargar otro pedido? \n 1) Sí \n 2) No");
                    opcionIterar = menu.LeerYValidarOpcion(2);
                } while (opcionIterar == 1);
                break;
            case 2:
                do
                {
                    cadeteria.asignarPedidoACadete(listaPedidosPendientes);
                    Console.WriteLine("¿Quiere asignar otro pedido? \n 1) Sí \n 2) No");
                    opcionIterar = menu.LeerYValidarOpcion(2);
                } while (opcionIterar == 1);
                break;
            case 3:
                do
                {
                    cadeteria.CambiarEstadoPedido( listaPedidosPendientes);
                    Console.WriteLine("¿Quiere cambiar el estado de otro pedido? \n 1) Sí \n 2) No");
                    opcionIterar = menu.LeerYValidarOpcion(2);
                } while (opcionIterar == 1);
                break;
            case 4:
                do
                {
                    cadeteria.reasignarPedidos();
                    Console.WriteLine("¿Quiere reasignar otro pedido? \n 1) Sí \n 2) No");
                    opcionIterar = menu.LeerYValidarOpcion(2);
                } while (opcionIterar == 1);
                break;
            case 5: 
                cadeteria.MostrarInforme(); 
            break;
        }
        // if (opcion!=6) Console.WriteLine("Presione una tecla para volver al menu"); Console.ReadKey(); 
    } while (opcion != 6);
}

